using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.ComponentModel;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace WoWAddonUpdater
{
    class Utils
    {

        private static List<Addon> allAddons = new List<Addon>();
        public static List<string> invalidAddonNames = new List<string>();

        private static Dictionary<Sites, Dictionary<int, string>> siteToPattern = new Dictionary<Sites, Dictionary<int, string>>();

        private static Dictionary<Sites, string> siteToBasePage = new Dictionary<Sites, string>();


        public static event Action<bool, Action<string>> AddonDirectoryFound;
        public static event Action<Exception, string> DownloadCompletedString;
        public static event Action<float> DownloadProgressString;
        

        public static Results Download(string from, string to, out Action cancel, Action<float, string, string> callbackProgress = null, Action<Exception, bool, string, string> callbackCompleted = null)
        {
            if (!Directory.Exists(to))
            {
                cancel = null;
                return Results.DirectoryNotExisting;
            }

            if (!Permissions(to))
            {
                cancel = null;
                return Results.NoWritePermissions;
            }

            using (WebClient wc = new WebClient())
            {
                if(callbackProgress != null)
                {
                    wc.DownloadProgressChanged += (object s, DownloadProgressChangedEventArgs e) => callbackProgress(e.ProgressPercentage, from, to);
                }

                if(callbackCompleted != null)
                {
                    wc.DownloadFileCompleted += (object s, AsyncCompletedEventArgs e) => callbackCompleted(e.Error, e.Cancelled, from, to);
                }

                wc.DownloadFileAsync(new Uri(from), to);

                cancel = wc.CancelAsync;

            }

            return Results.InProgress;
        }


        public static Results Unzip(string from, string to, Action<bool> callbackSuccess)
        {
            if (!Directory.Exists(to))
            {
                return Results.DirectoryNotExisting;
            }

            if (!File.Exists(from))
            {
                return Results.FileNotExisting;
            }

            if (!Permissions(to))
            {
                return Results.NoWritePermissions;
            }

            System.Threading.ThreadPool.QueueUserWorkItem((object o) => Extract(from, to, callbackSuccess));
           
            return Results.InProgress;
        }

    private static void Extract(string from, string to, Action<bool> callbackSuccess)
    {
        try
        {
            ZipFile.ExtractToDirectory(from, to);
            callbackSuccess(true);
        } catch
        {
            callbackSuccess(false);
        }
    }


        public static bool Permissions(string to)
        {
            try
            {
                System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(to);
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }


        public static Results Initialize()
        {
            if(!Directory.Exists(Defaults.ADDON_ABSOLUTE_PATH_DEFAULT))
            {
                if(AddonDirectoryFound != null) {
                    AddonDirectoryFound(false, Callback_SetAddonDirectory);
                }
                return Results.DirectoryNotExisting;
            } else
            {
                if (AddonDirectoryFound != null)
                {
                    AddonDirectoryFound(true, null);
                }
                return Results.Success;
            }
        }


        public static bool Initialized()
        {
            if(Actual.addonAbsolutePath != null)
            {
                return true;
            }
            return false;
        }

        public static void Callback_SetAddonDirectory(string path)
        {
            if(Directory.Exists(path) && path.EndsWith(Defaults.ADDON_RELATIVE_PATH_DEFAULT))
            {
                Actual.addonAbsolutePath = path;
            }
            else
            {
                if (AddonDirectoryFound != null)
                {
                    AddonDirectoryFound(false, Callback_SetAddonDirectory);
                }
            }
        }


        public static IEnumerable<Addon> Addons(States state)
        {
            return allAddons.Where(a => a.State == state);
        }


        public static IEnumerable<Addon> Addons(Func<Addon, bool> predicate)
        {
            return allAddons.Where(predicate);
        }


        public static void DeleteAddons(States state)
        {

           foreach (Addon addon in allAddons.Where(a => a.State == state))
            {
                addon.Delete();
            }
        }


        public static void DeleteAddons(string name)
        {
            foreach (Addon addon in allAddons.Where(a => a.Name == name))
            {
                addon.Delete();
            }
        }


        public static void DeleteAddons(int id)
        {
            foreach(Addon addon in allAddons.Where(a => a.ID == id))
            {
                addon.Delete();
            }
        }


        public static void DeleteAddons(Func<Addon, bool> predicate)
        {
            foreach(Addon addon in allAddons.Where(predicate))
            {
                addon.Delete();
            }
        }


        public static List<Addon> Purge()
        {
            List<Addon> purged = new List<Addon>();

            foreach  (Addon addon in allAddons)
            {
                addon.AbsolutePaths.RemoveAll(p => !File.Exists(p));
                if(addon.AbsolutePaths.Count < 1)
                {
                    purged.Add(addon);
                }

            }

            allAddons.RemoveAll(a => purged.Contains(a));
            return purged;
        }


        public static void DeleteOnDisk(IEnumerable<Addon> addons)
        {
            foreach(Addon addon in addons)
            {
                foreach(string path in addon.AbsolutePaths)
                {
                    if (Directory.Exists(path))
                    {
                        Directory.Delete(path);
                    }
                }
            }
        }


        public static void URLToString(string URL, Action<float> callbackProgress, Action<Exception, string> callbackCompleted)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadStringCompleted += (object o, DownloadStringCompletedEventArgs e) => callbackCompleted(e.Error, e.Result);
                wc.DownloadProgressChanged += (object o, DownloadProgressChangedEventArgs e) => callbackProgress(e.ProgressPercentage);
                wc.DownloadStringAsync(new Uri(URL));
            }
        }


        private void Callback_DownloadCompletedString(Exception e, string text)
        {
            if(DownloadCompletedString != null)
            {
                DownloadCompletedString(e, text);
            }
        }


        private void Callback_DownloadProgressString(float percentage)
        {
            if(DownloadProgressString != null)
            {
                DownloadProgressString(percentage);
            }
        }
    

        public static List<string> Matches(string text, string pattern)
        {
            try
            {
                return (from Group g in Regex.Match(text, pattern).Groups select g.Value).ToList<string>();
            } catch
            {
                return null;
            }  
        }


        public static void AssociatePatternWithSite(Sites site, int stage, string pattern)
        {
            if (!siteToPattern.ContainsKey(site))
            {
                siteToPattern[site] = new Dictionary<int, string>() { { stage, pattern } };
            } else
            {
                siteToPattern[site][stage] = pattern;
            }
        }

        public static void AssociateBasePageWithSite(Sites site, string basePage)
        {
            siteToBasePage[site] = basePage;
        }


        public static string BasePage(Sites site)
        {
            string val = null;
            siteToBasePage.TryGetValue(site, out val);
            return val;
        }


        public static string Pattern(Sites site, int stage)
        {
            try
            {
                return siteToPattern[site][stage];
            }
            catch
            {
                return null;
            }

        }


        public static Dictionary<int, string> Patterns(Sites site)
        {
            try
            {
                return siteToPattern[site];
            } catch
            {
                return null;
            }
        }

    }
}
