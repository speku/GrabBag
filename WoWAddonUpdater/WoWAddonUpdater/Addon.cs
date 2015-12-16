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

        public string Title;
        public string Author;
        public string Interface;
        public string Notes;
        public string Version;
        public string XEmail;
        public string OptionalDeps;
        public string LoadOnDemand;
        public string SavedVariables;
        public string XCurseRepositoryID;
        public string XCurseProjectName;
        public string XCurseProjectID;
        public string XCursePackagedVersion;
        public string XWebsite;
        public string XCategory;


        public string parsedTitle;

        public Types type;

        public List<Sites> sites;

        public string downloadLink;

        public string image;

        public string description;

        public DateTime lastChecked;

        public DateTime lastUpdated;

        public Action cancelDownload;

        public States state;

        public bool selected;

        public bool enabled;

        public double size;

        public string sizeUnit = "MB";

        public string downloadedBy;

        public List<string> absolutePaths = new List<string>();


       


        internal Addon()
        {
        }

        internal Addon(String title, Types type = Types.Unspecified, List<Sites> sites = null, string downloadLink = Defaults.DOWNLOAD_DEFAULT, string image = Defaults.IMAGE_DEFAULT, string description = Defaults.DESCRIPTION_DEFAULT, string Interface = Defaults.INTERFACE_DEFAULT)
        {
            if (sites == null)
            {
                sites = new List<Sites> { Sites.Unspecified };
            }
            this.Title = title;
            this.type = type;
            this.sites = sites;
            this.downloadLink = downloadLink;
            this.image = image;
            this.description = description;
            this.Interface = Interface;
        }


        public void TryDownloadAsync()
        {
            Task.Factory.StartNew(TryDownload);
        }


        public void TryDownload()
        {
            string url = null;
            int total = sites.Count;
            int current = 1;
            foreach (Sites s in sites)
            {
                url = Utils.GetDownloadURL(s, Title, Callback_ParsingProgressChanged, Callback_ParsingCompleted);
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
            state = States.Downloading;
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
                state = States.Downloaded;
                Utils.Unzip(to, Utils.addonAbsolutePath, Callback_UnzippingSuccessful);
            }
            if (cancelled)
            {
                state = States.Cancelled;
            }
            else if (error != null)
            {
                state = States.DownloadError;
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
                state = States.ExtractionError;
            } else
            {
                state = States.Extracted;
            }
            if(UnzippingSuccessful != null)
            {
                UnzippingSuccessful(this, success);
            }
        }


        private void Callback_ParsingProgressChanged(int currentStage, int totalStages, Exception error)
        {
            state = States.Parsing;
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
            foreach (string path in absolutePaths)
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
