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
using Microsoft.VisualBasic.FileIO;

namespace WoWAddonUpdater
{
    class Utils
    {

        public static List<Addon> allAddons = new List<Addon>();
        public static List<string> invalidAddonNames = new List<string>();
        public static List<string> parsedNames = new List<string>();

        public static Dictionary<Sites, Dictionary<int, ParseDetail>> siteToPattern = new Dictionary<Sites, Dictionary<int, ParseDetail>>();
        public static Dictionary<Sites, Func<string, string>> siteToSearchStringReplacement = new Dictionary<Sites, Func<string, string>>();

        public static event Action<bool, Action<string>> AddonDirectoryFound;
        public static event Action<Exception, string> DownloadCompletedString;
        public static event Action<float> DownloadProgressString;

        public static double similarity = Defaults.SIMILARITY_DEFAULT;
        public static Sites site = Defaults.SITE_DEFAULT;
        public static Types type = Types.Alpha;


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
                to = to + "/" + from.Split('/').Last();

                if (callbackProgress != null)
                {
                    wc.DownloadProgressChanged += (object s, DownloadProgressChangedEventArgs e) => callbackProgress(e.ProgressPercentage, from, to);
                }

                if (callbackCompleted != null)
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

            Task.Factory.StartNew(() => Extract(from, to, callbackSuccess));

            return Results.InProgress;
        }

        private static void Extract(string from, string to, Action<bool> callbackSuccess)
        {
            try
            {
                string temp = from + DateTime.Now.ToString().Replace(":", "").Replace("/", "").Replace("\\", "");
                CreateDirectory(temp);
                ZipFile.ExtractToDirectory(from, temp);
                FileSystem.CopyDirectory(temp, to, true);
                FileSystem.DeleteDirectory(temp, DeleteDirectoryOption.DeleteAllContents);
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
            if (!Directory.Exists(Defaults.ADDON_ABSOLUTE_PATH_DEFAULT))
            {
                if (AddonDirectoryFound != null) {
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
            if (Actual.addonAbsolutePath != null)
            {
                return true;
            }
            return false;
        }

        public static void Callback_SetAddonDirectory(string path)
        {
            if (Directory.Exists(path) && path.EndsWith(Defaults.ADDON_RELATIVE_PATH_DEFAULT))
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
            foreach (Addon addon in allAddons.Where(a => a.ID == id))
            {
                addon.Delete();
            }
        }


        public static void DeleteAddons(Func<Addon, bool> predicate)
        {
            foreach (Addon addon in allAddons.Where(predicate))
            {
                addon.Delete();
            }
        }


        public static List<Addon> Purge()
        {
            List<Addon> purged = new List<Addon>();

            foreach (Addon addon in allAddons)
            {
                addon.AbsolutePaths.RemoveAll(p => !File.Exists(p));
                if (addon.AbsolutePaths.Count < 1)
                {
                    purged.Add(addon);
                }

            }

            allAddons.RemoveAll(a => purged.Contains(a));
            return purged;
        }


        public static void DeleteOnDisk(IEnumerable<Addon> addons)
        {
            foreach (Addon addon in addons)
            {
                foreach (string path in addon.AbsolutePaths)
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
            if (DownloadCompletedString != null)
            {
                DownloadCompletedString(e, text);
            }
        }


        private void Callback_DownloadProgressString(float percentage)
        {
            if (DownloadProgressString != null)
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


        public static void AssociatePatternWithSite(Sites site, int stage, List<int> inputs, string basePage, string pattern)
        {
            if (!siteToPattern.ContainsKey(site))
            {
                siteToPattern[site] = new Dictionary<int, ParseDetail>() { { stage, new ParseDetail(inputs, basePage, pattern) } };
            } else
            {
                siteToPattern[site][stage] = new ParseDetail(inputs, basePage, pattern);
            }
        }



        public static string GetDownloadURL(Sites site, string addon, Action<int, int, Exception> callbackProgress, Action<bool, Exception, Results> callbackCompleted)
        {
            Dictionary<int, ParseDetail> stageToParseDetail = siteToPattern.ContainsKey(site) ? siteToPattern[site] : Defaults.SITE_TO_PATTERN_DEFAULT[site];
            Dictionary<int, string> inputs = new Dictionary<int, string>();

            for (int i = 1; i <= stageToParseDetail.Count; i++)
            {
                var detail = stageToParseDetail[i];
                if (detail.inputs.Count > 0)
                {
                    InjectInputIntoBasePage(site, ref detail, inputs, addon);
                }
                try
                {
                    string newInput = Regex.Match(URLToString(detail.basePage), detail.pattern).Groups[1].Value;
                    if (parsedNames.Contains(newInput))
                    {
                        return null;
                    } else
                    {
                        parsedNames.Add(newInput);
                    }

                    if (i == 1 && SimilarityTester.CompareStrings(addon, newInput) < similarity)
                    {
                        callbackCompleted(false, null, Results.InsufficientSimilarity);
                        return null;
                    }
                    if (i == stageToParseDetail.Count)
                    {
                        callbackCompleted(true, null, Results.Success);
                        return newInput;
                    } else
                    {
                        inputs[i] = newInput;
                        callbackProgress(i, stageToParseDetail.Count, null);
                    }
                } catch (Exception e)
                {
                    callbackProgress(i, stageToParseDetail.Count, e);
                    return null;
                }
            }
            return null;
        }


        private static void InjectInputIntoBasePage(Sites site, ref ParseDetail detail, Dictionary<int, string> inputs, string addon)
        {
            if (detail.inputs.Count == 1 && detail.inputs[0] == 0)
            {
                Func<string, string> replacer = siteToSearchStringReplacement.ContainsKey(site) ? siteToSearchStringReplacement[site] :
                    Defaults.SITE_TO_SEARCH_STRING_REPLACEMENT_FUNCTION.ContainsKey(site) ? Defaults.SITE_TO_SEARCH_STRING_REPLACEMENT_FUNCTION[site] : null;
                if (replacer != null)
                {
                    detail.basePage = String.Format(detail.basePage, replacer(addon));
                }
            } else
            {
                detail.basePage = String.Format(detail.basePage, (from input in detail.inputs select inputs[input]).ToArray());
            }
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
                        return Regex.Match(text, Actual.tocPattern != null ? Actual.tocPattern : Defaults.TOC_PATTERN_DEFAULT).Groups[1].Value.Replace("\r","");
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
            List<string> addons = new List<string>();

            string addonDirectory = Directory.Exists(Actual.addonAbsolutePath) ? Actual.addonAbsolutePath : 
                Directory.Exists(Defaults.ADDON_ABSOLUTE_PATH_DEFAULT) ? Defaults.ADDON_ABSOLUTE_PATH_DEFAULT : null;

            if (addonDirectory == null)
            {
                string envPath = Environment.GetEnvironmentVariable("WoW");
                if (envPath != null)
                {
                    addonDirectory = envPath + Defaults.ADDON_RELATIVE_PATH_FROM_BASE_DIRECTORY;
                    if (!Directory.Exists(addonDirectory))
                    {
                        return addons;
                    }
                } else
                {
                    return addons;
                }
            }

            

            foreach (string dir in Directory.GetDirectories(addonDirectory))
            {
                if (!dir.Contains(Defaults.BLIZZARD_ADDON_PREFIX))
                {
                    string preciseName = ParseToc(dir);
                    if (preciseName != null)
                    {
                        addons.Add(preciseName);
                    }
                    else
                    {
                        addons.Add(dir.Split('\\').Last());
                    }
                }
            }

            return addons;
        }


        public static List<string> RemoveInvalidAddonNames(List<string> addonNames)
        {
            List<string> addonNamesToBePurged = new List<string>(addonNames);
            addonNamesToBePurged.RemoveAll((a) => invalidAddonNames.Contains(a));
            return addonNamesToBePurged;
        }


        public static List<string> GetValidAddonNames()
        {
            return RemoveInvalidAddonNames(GetAddonNames());
        }


        public static List<Addon> CreateDisctinctAddons(List<string> names)
        {
            return (from name in names
                    where !(from addon in allAddons
                           select addon.ParsedName).Contains(name)
                    select new Addon(name, type, new List<Sites> { site })).ToList();
        }


        public static List<Addon> CreateValidDistinctAddons()
        {
            return CreateDisctinctAddons(GetValidAddonNames());
        }



        public static void start()
        {
            foreach (Addon addon in CreateValidDistinctAddons())
            {
                // addon.TryDownloadAsync();
                 addon.TryDownload();
            }
        }


        public static void Save()
        {

        }


        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }


    }
}
