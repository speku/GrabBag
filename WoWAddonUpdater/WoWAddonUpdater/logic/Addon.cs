using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace WoWAddonUpdater
{
    [Serializable]
    class Addon
    {

        internal event Action<Addon, Exception, bool> DownloadCompleted;
        internal event Action<Addon, Exception, bool, Results> ParsingCompleted;
        internal event Action<Addon, float> DownloadProgressChanged;
        internal event Action<Addon, float, Exception> ParsingProgressChanged;
        internal event Action<Addon, float> TotalProgressChanged;
        internal event Action<Addon, bool> UnzippingSuccessful;
        internal event Action<Addon> Deleted;

        internal string Title;
        internal string Author;
        internal string Interface;
        internal string Notes;
        internal string Version;
        internal string XEmail;
        internal string OptionalDeps;
        internal string LoadOnDemand;
        internal string SavedVariables;
        internal string XCurseRepositoryID;
        internal string XCurseProjectName;
        internal string XCurseProjectID;
        internal string XCursePackagedVersion;
        internal string XWebsite;
        internal string XCategory;


        internal string parsedTitle;

        internal Types type;

        internal List<Sites> sites;

        internal string downloadLink;

        internal string image;

        internal string description;

        internal DateTime lastChecked;

        internal DateTime lastUpdated;

        internal Action cancelDownload;

        internal States state;

        internal bool selected;

        internal bool enabled;

        internal double size;

        internal string sizeUnit = "MB";

        internal string downloadedBy;

        internal List<string> absolutePaths = new List<string>();


       


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


        public override bool Equals(object obj)
        {
            if (obj == null){
                return false;
            }

            Addon a = obj as Addon;
            if (a == null)
            {
                return false;
            }

            if (Title == a.Title)
            {
                return true;
            } else
            {
                return false;
            }
        }

        internal void TryDownloadAsync()
        {
            Task.Factory.StartNew(TryDownload);
        }


        internal void TryDownload()
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


        internal Results Download(string path = null)
        {
            if (path == null || path == "")
            {
                path = Defaults.UPDATER_DOWNLOAD_ABSOLUTE_PATH;
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
                Utils.Unzip(to, Config.Settings.addonAbsolutePath, Callback_UnzippingSuccessful);
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


        internal bool CancelDownload()
        {
            if(cancelDownload != null)
            {
                cancelDownload();
                return true;
            }
            return false;
        }


        internal void Delete(List<Addon> addons = null)
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
