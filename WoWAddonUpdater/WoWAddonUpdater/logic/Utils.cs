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
using System.Threading;

namespace WoWAddonUpdater
{

    class Utils
    {

        internal static event Action<bool, Action<string>> AddonDirectoryFound;
        internal static event Action<Exception, string> DownloadCompletedString;
        internal static event Action<float> DownloadProgressString;

        internal static Results Download(string from, string to, out Action cancel, Action<float, string, string> callbackProgress = null, Action<Exception, bool, string, string> callbackCompleted = null)
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




        internal static Results Unzip(string from, string to, Action<bool> callbackSuccess)
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
                Directory.CreateDirectory(temp);
                ZipFile.ExtractToDirectory(from, temp);
                FileSystem.CopyDirectory(temp, to, true);
                FileSystem.DeleteDirectory(temp, DeleteDirectoryOption.DeleteAllContents);
                callbackSuccess(true);
            } catch
            {
                callbackSuccess(false);
            }
        }


        internal static bool Permissions(string to)
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


        internal static Results Initialize()
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


        internal static bool Initialized()
        {
            if (Config.Settings.addonAbsolutePath != null)
            {
                return true;
            }
            return false;
        }

        internal static void Callback_SetAddonDirectory(string path)
        {
            if (Directory.Exists(path) && path.EndsWith(Defaults.ADDON_RELATIVE_PATH_DEFAULT))
            {
                Config.Settings.addonAbsolutePath = path;
            }
            else
            {
                if (AddonDirectoryFound != null)
                {
                    AddonDirectoryFound(false, Callback_SetAddonDirectory);
                }
            }
        }


        internal static IEnumerable<Addon> Addons(States state)
        {
            return Config.Settings.allAddons.Where(a => a.state == state);
        }


        internal static IEnumerable<Addon> Addons(List<States> states)
        {
            return Config.Settings.allAddons.Where(a => states.Contains(a.state));
        }


        internal static IEnumerable<Addon> Addons(Func<Addon, bool> predicate)
        {
            return Config.Settings.allAddons.Where(predicate);
        }


        internal static void DeleteAddons(States state)
        {

            foreach (Addon addon in Config.Settings.allAddons.Where(a => a.state == state))
            {
                addon.Delete();
            }
        }


        internal static void DeleteAddons(string name)
        {
            foreach (Addon addon in Config.Settings.allAddons.Where(a => a.Title == name))
            {
                addon.Delete();
            }
        }


        internal static void DeleteAddonsByID(string id)
        {
            foreach (Addon addon in Config.Settings.allAddons.Where(a => a.XCurseProjectID == id))
            {
                addon.Delete();
            }
        }


        internal static void DeleteAddons(Func<Addon, bool> predicate)
        {
            foreach (Addon addon in Config.Settings.allAddons.Where(predicate))
            {
                addon.Delete();
            }
        }


        internal static List<Addon> Purge()
        {
            List<Addon> purged = new List<Addon>();

            foreach (Addon addon in Config.Settings.allAddons)
            {
                addon.absolutePaths.RemoveAll(p => !File.Exists(p));
                if (addon.absolutePaths.Count < 1)
                {
                    purged.Add(addon);
                }

            }

            Config.Settings.allAddons.RemoveAll(a => purged.Contains(a));
            return purged;
        }


        internal static void DeleteOnDisk(IEnumerable<Addon> addons)
        {
            foreach (Addon addon in addons)
            {
                foreach (string path in addon.absolutePaths)
                {
                    if (Directory.Exists(path))
                    {
                        Directory.Delete(path);
                    }
                }
            }
        }


        internal static void URLToStringAsync(string URL, Action<float> callbackProgress, Action<Exception, string> callbackCompleted)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadStringCompleted += (object o, DownloadStringCompletedEventArgs e) => callbackCompleted(e.Error, e.Result);
                wc.DownloadProgressChanged += (object o, DownloadProgressChangedEventArgs e) => callbackProgress(e.ProgressPercentage);
                wc.DownloadStringAsync(new Uri(URL));
            }
        }

        internal static string URLToString(string URL)
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


        internal static List<string> Matches(string text, string pattern)
        {
            try
            {
                return (from Group g in Regex.Match(text, pattern).Groups select g.Value).ToList<string>();
            } catch
            {
                return null;
            }
        }


        internal static void AssociatePatternWithSite(Sites site, int stage, List<int> inputs, string basePage, string pattern)
        {
            if (!Config.Settings.siteToPattern.ContainsKey(site))
            {
                Config.Settings.siteToPattern[site] = new Dictionary<int, ParseDetail>() { { stage, new ParseDetail(inputs, basePage, pattern) } };
            } else
            {
                Config.Settings.siteToPattern[site][stage] = new ParseDetail(inputs, basePage, pattern);
            }
        }



        internal static string GetDownloadURL(Sites site, Addon addon, Action<int, int, Exception> callbackProgress, Action<bool, Exception, Results> callbackCompleted)
        {
            Dictionary<int, ParseDetail> stageToParseDetail = Config.Settings.siteToPattern.ContainsKey(site) ? Config.Settings.siteToPattern[site] : Defaults.SITE_TO_PATTERN_DEFAULT[site];
            Dictionary<int, string> inputs = null;
            int start = 1;
            if (addon.inputs != null)
            {
                addon.inputs.TryGetValue(site, out inputs);
            }
            if (inputs == null)
            {
                inputs = new Dictionary<int, string>();
            }
            else
            {
                start = stageToParseDetail.ToList().Where((kv) => kv.Value.entryPoint).ToList()[0].Key;
            }

            for (int i = start; i <= stageToParseDetail.Count; i++)
            {
                var detail = stageToParseDetail[i];
                if (detail.inputs.Count > 0)
                {
                    InjectInputIntoBasePage(site, ref detail, inputs, addon.Title);
                }
                try
                {
                    string newInput = Regex.Match(URLToString(detail.basePage), detail.pattern).Groups[1].Value;
                    if (Config.Settings.parsedTitles.Contains(newInput))
                    {
                        return null;
                    }
                    else
                    {
                        Config.Settings.parsedTitles.Add(newInput);
                    }

                    if (i == 1 && SimilarityTester.CompareStrings(addon.Title, newInput) < Config.Settings.similarity)
                    {
                        Config.Settings.invalidAddonTitles.Add(addon.Title);
                        callbackCompleted(false, null, Results.InsufficientSimilarity);
                        return null;
                    }
                    if (i == stageToParseDetail.Count)
                    {
                        callbackCompleted(true, null, Results.Success);
                        if (HasProperExtension(newInput))
                        {
                            if (addon.inputs == null)
                            {
                                addon.inputs = new Dictionary<Sites, Dictionary<int, string>>();
                            }
                            addon.inputs[site] = inputs;
                            return newInput;
                        }
                        else
                        {
                            Config.Settings.invalidAddonTitles.Add(addon.Title);
                            return null;
                        }
                    }
                    else
                    {
                        inputs[i] = newInput;
                        callbackProgress(i, stageToParseDetail.Count, null);
                    }
                }
                catch (Exception e)
                {
                    Config.Settings.invalidAddonTitles.Add(addon.Title);
                    callbackProgress(i, stageToParseDetail.Count, e);
                    return null;
                }
            }
            return null;
        }

        //internal static string GetDownloadURL(Sites site, Addon addon, Action<int, int, Exception> callbackProgress, Action<bool, Exception, Results> callbackCompleted)
        //{
        //    Dictionary<int, ParseDetail> stageToParseDetail = Config.Settings.siteToPattern.ContainsKey(site) ? Config.Settings.siteToPattern[site] : Defaults.SITE_TO_PATTERN_DEFAULT[site];
        //    Dictionary<int, string> inputs = null;
        //    int start = 1;
        //    if (addon.inputs != null)
        //    {
        //        addon.inputs.TryGetValue(site, out inputs);
        //    }
        //    if (inputs == null)
        //    {
        //        inputs = new Dictionary<int, string>();
        //    } else
        //    {
        //        start = stageToParseDetail.ToList().Where((kv) => kv.Value.entryPoint).ToList()[0].Key;
        //    }

        //    for (int i = start; i <= stageToParseDetail.Count; i++)
        //    {
        //        var detail = stageToParseDetail[i];
        //        if (detail.inputs.Count > 0)
        //        {
        //            InjectInputIntoBasePage(site, ref detail, inputs, addon.Title);
        //        }
        //        try
        //        {
        //            string newInput = Regex.Match(URLToString(detail.basePage), detail.pattern).Groups[1].Value;
        //            if (Config.Settings.parsedTitles.Contains(newInput))
        //            {
        //                return null;
        //            } else
        //            {
        //                Config.Settings.parsedTitles.Add(newInput);
        //            }

        //            if (i == 1 && SimilarityTester.CompareStrings(addon.Title, newInput) < Config.Settings.similarity)
        //            {
        //                Config.Settings.invalidAddonTitles.Add(addon.Title);
        //                callbackCompleted(false, null, Results.InsufficientSimilarity);
        //                return null;
        //            }
        //            if (i == stageToParseDetail.Count)
        //            {
        //                callbackCompleted(true, null, Results.Success);
        //                if (HasProperExtension(newInput))
        //                {
        //                    if (addon.inputs == null)
        //                    {
        //                        addon.inputs = new Dictionary<Sites, Dictionary<int, string>>();
        //                    }
        //                    addon.inputs[site] = inputs;
        //                    return newInput;
        //                } else
        //                {
        //                    Config.Settings.invalidAddonTitles.Add(addon.Title);
        //                    return null;
        //                }
        //            } else
        //            {
        //                inputs[i] = newInput;
        //                callbackProgress(i, stageToParseDetail.Count, null);
        //            }
        //        } catch (Exception e)
        //        {
        //            Config.Settings.invalidAddonTitles.Add(addon.Title);
        //            callbackProgress(i, stageToParseDetail.Count, e);
        //            return null;
        //        }
        //    }
        //    return null;
        //}


        private static bool HasProperExtension(string downloadLink)
        {
            foreach (string extension in Defaults.ACCEPTED_EXTENSIONS)
            {
                if (downloadLink.EndsWith(extension))
                {
                    return true;
                }
            }
            return false;
        }


        private static void InjectInputIntoBasePage(Sites site, ref ParseDetail detail, Dictionary<int, string> inputs, string addon)
        {
            if (detail.inputs.Count == 1 && detail.inputs[0] == 0)
            {
                Func<string, string> replacer = Config.Settings.siteToSearchStringReplacement.ContainsKey(site) ? Config.Settings.siteToSearchStringReplacement[site] :
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



        internal static AddonMeta ParseMetaData(string dir)
        {
            foreach (string file in Directory.GetFiles(dir))
            {
                if (file.EndsWith(".toc"))
                {
                    return new AddonMeta(File.ReadAllText(file));
                }
            }
            return null;
        }


        internal static List<AddonMeta> GetAddonMetaData()
        {
            List<AddonMeta> addons = new List<AddonMeta>();

            string addonDirectory = Directory.Exists(Config.Settings.addonAbsolutePath) ? Config.Settings.addonAbsolutePath :
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
                }
                else
                {
                    return addons;
                }
            }



            foreach (string dir in Directory.GetDirectories(addonDirectory))
            {
                if (!dir.Contains(Defaults.BLIZZARD_ADDON_PREFIX))
                {
                    AddonMeta data = ParseMetaData(dir);
                    if (data != null)
                    {
                        if (data.GetMeta("Title") == "")
                        {
                            string temp = SplitAndGet(dir);
                            data.SetMeta("Title", SplitAndGet(dir));
                        }
                        addons.Add(data);
                    }
                }
            }

            return addons;
        }


        internal static List<AddonMeta> RemoveInvalidAddonMetaData(List<AddonMeta> metaData)
        {
            List<AddonMeta> addonNamesToBePurged = new List<AddonMeta>(metaData);
            addonNamesToBePurged.RemoveAll((a) => Config.Settings.invalidAddonTitles.Contains(a.GetMeta("Title")));
            return addonNamesToBePurged;
        }


        internal static List<AddonMeta> GetValidAddonMetaData()
        {
            return RemoveInvalidAddonMetaData(GetAddonMetaData());
        }


        internal static List<Addon> CreateDisctinctAddons(List<AddonMeta> metaData)
        {
            return (from data in metaData
                   where !(from addon in Config.Settings.allAddons select addon.parsedTitle).Contains(data.GetMeta("title")) &&
                   !(from addon in Config.Settings.allAddons select addon.Title).Contains(data.GetMeta("title"))
                   select data.CreateAddon()).ToList();
        }


        internal static List<Addon> CreateValidDistinctAddons()
        {
            return CreateDisctinctAddons(GetValidAddonMetaData());
        }



        internal static void start()
        {
            ThreadPool.SetMinThreads(40, 40);

            foreach (Addon addon in CreateValidDistinctAddons())
            {
                addon.TryDownloadAsync();
            }

        }


        internal static void Save()
        {

        }

        
        internal static string SplitAndGet(string str, int index = -1, string delim = null)
        {
            List<string> delimiters = delim == null ? new List<string> {"\\" } : new List<string> { delim };

            foreach (string delimiter in delimiters)
            {
                if (str.Contains(delimiter))
                {
                    string[] splits = str.Split((Convert.ToChar(delimiter)));

                    if (index >= 0 && splits.Length > index)
                    { 
                        return splits[index];
                    } else if (splits.Length > 0)
                    {
                        return splits.Last();
                    } else
                    {
                        continue;
                    }
                }
            }
            return null;
        }


     

        

    }
}
