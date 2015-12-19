using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;

namespace WoWAddonUpdater
{
    class AddonMeta
    {
        private static string patternPostfix = @": ([^\n\r]+?)(\r|\n|#)";

        public event Action<AddonMeta, string> PatternNotFound;

        private static Dictionary<string, Regex> patterns = new Dictionary<string, Regex>
        {
            {"Title", new Regex("Title" + patternPostfix) },
            {"Author", new Regex("Author" + patternPostfix) },
            {"Interface", new Regex("Interface" + patternPostfix) },
            {"Notes", new Regex("Notes" + ": ([.\n])+?#") },
            {"Version", new Regex("Version" + patternPostfix) },
            {"XEmail", new Regex("X-Email" + patternPostfix) },
            {"OptionalDeps", new Regex("OptionalDeps" + patternPostfix) },
            {"LoadOnDemand", new Regex("LoadOnDemand" + patternPostfix) },
            {"SavedVariables", new Regex("SavedVeriables" + patternPostfix) },
            {"XCurseRepositoryID", new Regex("X-Curse-Repository-ID" + patternPostfix) },
            {"XCurseProjectName", new Regex("X-Curse-Project-Name" + patternPostfix) },
            {"XCurseProjectID", new Regex("X-Curse-Project-ID" + patternPostfix)},
            {"XCursePackagedVersion", new Regex("X-Curse-Packaged-Version" + patternPostfix) },
            {"XWebsite", new Regex("X-Website" + patternPostfix) },
            {"XCategory", new Regex("X-Category" + patternPostfix) },
        };

        // TODO: customize
        private static Dictionary<Sites, Dictionary<string, Regex>> patternsHTML = new Dictionary<Sites, Dictionary<string, Regex>>()
        {
            {Sites.WoWAce, new Dictionary<string, Regex>()
            {
                {"Title", new Regex("Title" + patternPostfix) },
                {"Author", new Regex("Author" + patternPostfix) },
                {"Interface", new Regex("Interface" + patternPostfix) },
                {"Notes", new Regex("Notes" + ": ([.\n])+?#") },
                {"Version", new Regex("Version" + patternPostfix) },
                {"XEmail", new Regex("X-Email" + patternPostfix) },
                {"OptionalDeps", new Regex("OptionalDeps" + patternPostfix) },
                {"LoadOnDemand", new Regex("LoadOnDemand" + patternPostfix) },
                {"SavedVariables", new Regex("SavedVeriables" + patternPostfix) },
                {"XCurseRepositoryID", new Regex("X-Curse-Repository-ID" + patternPostfix) },
                {"XCurseProjectName", new Regex("X-Curse-Project-Name" + patternPostfix) },
                {"XCurseProjectID", new Regex("X-Curse-Project-ID" + patternPostfix)},
                {"XCursePackagedVersion", new Regex("X-Curse-Packaged-Version" + patternPostfix) },
                {"XWebsite", new Regex("X-Website" + patternPostfix) },
                {"XCategory", new Regex("X-Category" + patternPostfix) }
            }
            }
        };



        private  Dictionary<string, string> matches = new Dictionary<string, string>();


        public AddonMeta(string toc)
        {
            Parse(toc);
        }

        public AddonMeta()
        {
        }


        public string GetMeta(string key)
        {
            string value;
            matches.TryGetValue(key, out value);
            return value == null ? "" : value;
        }


        public void SetMeta(string key, string value)
        {
            matches[key] = value;
        }


        public Addon CreateAddon()
        {
            Addon addon = new Addon();

            foreach(KeyValuePair<string, string> match in matches)
            {
                var field = addon.GetType().GetField(match.Key);
                if (field != null)
                {
                    field.SetValue(addon, match.Value);
                }
            }

            addon.sites = new List<Sites> { Defaults.SITE_DEFAULT };
            return addon;
        }


        private void Parse(string text, params string[] keys)
        {
            if(keys.Length == 0)
            {
                keys = patterns.Keys.ToArray<string>();
            }
            foreach (string key in keys)
            {
                ParseText(text, key);
            }
        }

        private void ParseText(string text, string key)
        {
            Regex pattern;
            patterns.TryGetValue(key, out pattern);
            if (pattern != null)
            {
                try
                {
                    matches[key] = pattern.Match(text).Groups[1].Value;
                }
                catch
                {
                    if (PatternNotFound != null)
                    {
                        PatternNotFound(this, key);
                    }
                }
            }
        }

    }

}
