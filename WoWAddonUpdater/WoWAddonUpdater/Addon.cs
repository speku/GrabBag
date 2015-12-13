using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace WoWAddonUpdater
{
    class Addon
    {

        public event Action<Addon, Exception, bool> DownloadCompleted;
        public event Action<Addon, Exception, bool, Results> ParsingCompleted;
        public event Action<Addon, float> DownloadProgressChanged;
        public event Action<Addon, float, Exception> ParsingProgressChanged;
        public event Action<Addon, float> TotalProgressChanged;
        public event Action<Addon, bool> UnzippingSuccessful;
        public event Action<Addon> Deleted;

        const string NAME_DEFAULT = "";
        const Types TYPE_DEFAULT = Types.Unspecified;
        const Sites SITE_DEFAULT = Sites.Unspecified;
        const string DOWNLOAD_DEFAULT = null;
        const string IMAGE_DEFAULT = null;
        const string DESCRIPTION_DEFAULT = null;
        static readonly DateTime LAST_CHECKED_DEFAULT = DateTime.MinValue;
        static readonly DateTime LAST_UPDATED_DEFAULT = DateTime.MinValue;
        const string GAME_VERSION_DEFAULT = "1.0.0";


        string name;

        string parsedName;

        Types type;

        List<Sites> sites;

        string downloadLink;

        string image;

        string description;

        DateTime lastChecked;

        DateTime lastUpdated;

        string gameVersion;

        Action cancelDownload;

        States state;

        bool selected;

        bool enabled;

        double size;

        string author;

        string sizeUnit = "MB";

        string downloadedBy;

        int id;

        List<string> absolutePaths = new List<string>();


        public string DownloadLink
        {
            get
            {
                return downloadLink;
            }

            set
            {
                downloadLink = value;
            }
        }

        public string Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        internal Types Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        internal List<Sites> Site
        {
            get
            {
                return sites;
            }

            set
            {
                sites = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public DateTime LastChecked
        {
            get
            {
                return lastChecked;
            }

            set
            {
                lastChecked = value;
            }
        }

        public DateTime LastUpdated
        {
            get
            {
                return lastUpdated;
            }

            set
            {
                lastUpdated = value;
            }
        }

        public string GameVersion
        {
            get
            {
                return gameVersion;
            }

            set
            {
                gameVersion = value;
            }
        }

        internal States State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }

        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        
        public List<string> AbsolutePaths
        {
            get
            {
                return absolutePaths;
            }

            set
            {
                absolutePaths = value;
            }
        }

        public bool Selected
        {
            get
            {
                return selected;
            }

            set
            {
                selected = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return enabled;
            }

            set
            {
                enabled = value;
            }
        }

        public double Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }

        public string SizeUnit
        {
            get
            {
                return sizeUnit;
            }

            set
            {
                sizeUnit = value;
            }
        }

        public string DownloadedBy
        {
            get
            {
                return downloadedBy;
            }

            set
            {
                downloadedBy = value;
            }
        }

        public string ParsedName
        {
            get
            {
                return parsedName;
            }

            set
            {
                parsedName = value;
            }
        }

        internal Addon(String name, Types type = Types.Unspecified, List<Sites> sites = null, string downloadLink = DOWNLOAD_DEFAULT, string image = IMAGE_DEFAULT, string description = DESCRIPTION_DEFAULT, string gameVersion = GAME_VERSION_DEFAULT)
        {
            if (sites == null)
            {
                sites = new List<Sites> { Sites.Unspecified };
            }
            this.Name = name;
            this.Type = type;
            this.Site = sites;
            this.DownloadLink = downloadLink;
            this.Image = image;
            this.Description = description;
            this.GameVersion = gameVersion;
        }


        public void TryDownloadAsync()
        {
            Task.Factory.StartNew(TryDownload);
        }


        public void TryDownload()
        {
            string url = null;
            int total = Site.Count;
            int current = 1;
            foreach (Sites s in Site)
            {
                url = Utils.GetDownloadURL(s, Name, Callback_ParsingProgressChanged, Callback_ParsingCompleted);
                if (url != null)
                {
                    downloadLink = url;
                    Download();
                    return;
                }
                current++;
            }
        }


        public Results Download(string path = null)
        {
            if (path == null || path == "")
            {
                path = Defaults.DOWNLOAD_ABSOLUTE_PATH_DEFAULT;
            }
            return Utils.Download(downloadLink, path, out cancelDownload, Callback_DownloadProgressChanged, Callback_DownloadCompleted);

        }


        private void Callback_DownloadProgressChanged(float percentage, string from, string to)
        {
            State = States.Downloading;
            if(DownloadProgressChanged != null)
            {
                DownloadProgressChanged(this, percentage);
            }
        }


        private void Callback_DownloadCompleted(Exception error, bool cancelled, string from, string to)
        {
            cancelDownload = null;
            if (error == null && !cancelled)
            {
                State = States.Downloaded;
                Utils.Unzip(to, Actual.addonAbsolutePath, Callback_UnzippingSuccessful);
            }
            if (cancelled)
            {
                State = States.Cancelled;
            }
            else if (error != null)
            {
                State = States.DownloadError;
            }
            if (DownloadCompleted != null)
            {
               
                DownloadCompleted(this, error, cancelled);
            }
        }


        private void Callback_UnzippingSuccessful(bool success)
        {
            if (!success)
            {
                State = States.ExtractionError;
            } else
            {
                State = States.Extracted;
            }
            if(UnzippingSuccessful != null)
            {
                UnzippingSuccessful(this, success);
            }
        }


        private void Callback_ParsingProgressChanged(int currentStage, int totalStages, Exception error)
        {
            State = States.Parsing;
            if(DownloadProgressChanged != null)
            {
                ParsingProgressChanged(this, (currentStage / totalStages) * 100, error);
            }
        }


        private void Callback_ParsingCompleted(bool success, Exception error, Results result)
        {
            if(ParsingCompleted != null)
            {
                ParsingCompleted(this, error, success, result);
            }
        }


        public bool CancelDownload()
        {
            if(cancelDownload != null)
            {
                cancelDownload();
                return true;
            }
            return false;
        }


        public void Delete(List<Addon> addons = null)
        {
            foreach (string path in AbsolutePaths)
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path);
                }
            }

            if (addons != null)
            {
                addons.Remove(this);
            }

            if(Deleted != null)
            {
                Deleted(this);
            }
        }


      



    }
}
