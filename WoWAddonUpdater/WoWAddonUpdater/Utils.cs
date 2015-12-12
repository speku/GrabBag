﻿using System;
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

        public static List<Addon> allAddons = new List<Addon>();
        public static List<string> invalidAddonNames = new List<string>();

        public static Dictionary<Sites, Dictionary<int, ParseDetail>> siteToPattern = new Dictionary<Sites, Dictionary<int, ParseDetail>>();

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


        public static void URLToStringAsync(string URL, Action<float> callbackProgress, Action<Exception, string> callbackCompleted)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadStringCompleted += (object o, DownloadStringCompletedEventArgs e) => callbackCompleted(e.Error, e.Result);
                wc.DownloadProgressChanged += (object o, DownloadProgressChangedEventArgs e) => callbackProgress(e.ProgressPercentage);
                wc.DownloadStringAsync(new Uri(URL));
            }
        }

        public static string URLToString(string URL)
        {

            using (WebClient wc = new WebClient())
            {
                return wc.DownloadString(new Uri(URL));
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


        public static void AssociatePatternWithSite(Sites site, int stage, int input, string basePage, string pattern)
        {
            if (!siteToPattern.ContainsKey(site))
            {
                siteToPattern[site] = new Dictionary<int, ParseDetail>() { { stage, new ParseDetail(input, basePage, pattern) } };
            } else
            {
                siteToPattern[site][stage] = new ParseDetail(input, basePage, pattern);
            }
        }



        public static string GetDownloadURL(Sites site, string addon, Action<int, int, Exception> callbackProgress, Action<bool, Exception> callbackCompleted)
        {
            Dictionary<int, ParseDetail> stageToParseDetail = siteToPattern.ContainsKey(site) ? siteToPattern[site] : Defaults.SITE_TO_PATTERN_DEFAULT[site];
            Dictionary<int, string> inputs = new Dictionary<int, string>();

            for (int i = 1; i <= stageToParseDetail.Count; i++)
            {
                var detail = stageToParseDetail[i];
                if (detail.input >= 0)
                {
                    detail.basePage = detail.input == 0 ? String.Format(detail.basePage, addon) : String.Format(detail.basePage, inputs[detail.input]);
                }
                try
                {
                    string newInput = Regex.Match(URLToString(detail.basePage), detail.pattern).Groups[1].Value;
                    if (i == stageToParseDetail.Count)
                    {
                        callbackCompleted(true, null);
                        return newInput;
                    } else
                    {
                        inputs[i] = newInput;
                        callbackProgress(i, stageToParseDetail.Count, null);
                    }
                } catch(Exception e)
                {
                    callbackProgress(i, stageToParseDetail.Count, e);
                    return null;
                }
            }
            return null;
        }


        public static string ParseToc(string dir)
        {
            foreach(string file in Directory.GetFiles(dir))
            {
                if (file.EndsWith(".toc"))
                {
                    try
                    {
                        string text = File.ReadAllText(file);
                        return Regex.Match(text, Actual.tocPattern != null ? Actual.tocPattern : Defaults.TOC_PATTERN_DEFAULT).Groups[1].Value;
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            return null;
        }


        public static List<string> GetAddonNames()
        {
            string addonDirectory = Directory.Exists(Actual.addonAbsolutePath) ? Actual.addonAbsolutePath : Directory.Exists(Defaults.ADDON_ABSOLUTE_PATH_DEFAULT) ? Defaults.ADDON_ABSOLUTE_PATH_DEFAULT : null;

            if (addonDirectory == null)
            {
                return null;
            }

            List<string> addons = new List<string>();

            foreach (string dir in Directory.GetDirectories(addonDirectory))
            {
                string preciseName = ParseToc(dir);
                if (preciseName != null)
                {
                    addons.Add(preciseName);
                } else
                {
                    addons.Add(dir);
                }
            }

            return addons;
        }

    }
}