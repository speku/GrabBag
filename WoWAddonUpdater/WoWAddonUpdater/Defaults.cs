using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WoWAddonUpdater
{
    class Defaults
    {
        static Defaults()
        {
            Utils.CreateDirectory(DOWNLOAD_ABSOLUTE_PATH_DEFAULT);
        }

        static public readonly string ADDON_RELATIVE_PATH_DEFAULT = "World of Warcraft/Interface/Addons";

        static public readonly string DOWNLOAD_RELATIVE_PATH_DEFAULT = "/WoWAddonUpdater/Downloads";

        static public readonly string ADDON_RELATIVE_PATH_FROM_BASE_DIRECTORY = "/Interface/Addons";

        static public readonly string DOWNLOAD_ABSOLUTE_PATH_DEFAULT = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + DOWNLOAD_RELATIVE_PATH_DEFAULT;

        static public readonly string ADDON_ABSOLUTE_PATH_DEFAULT = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + ADDON_RELATIVE_PATH_DEFAULT;

        static public readonly string TOC_PATTERN_DEFAULT = "Title: (.+?)(\\n|#)";

        static public readonly Sites SITE_DEFAULT = Sites.WoWAce;

        static public readonly Types TYPE_DEFAULT = Types.Alpha;

        static public readonly double SIMILARITY_DEFAULT = 0.5;

        static public readonly string BLIZZARD_ADDON_PREFIX = "Blizzard_";

        static public readonly string[] ACCEPTED_EXTENSIONS = { ".rar", ".zip" };

        static public readonly Dictionary<string, string> TOC_PATTERNS_DEFAULT = new Dictionary<string, string>
        {
            {"title",  "Title: (.+?)(\\n|#)"},
            {"author",  "Author: (.+?)(\\n|#)"},
            {"version",  "Version: (.+?)(\\n|#)"},
            {"notes",  "Notes: (.+?)(\\n|#)"},
            {"interface",  "Interface: (.+?)(\\n|#)"},

        };

        static public readonly Dictionary<Sites, Dictionary<int, ParseDetail>> SITE_TO_PATTERN_DEFAULT = new Dictionary<Sites, Dictionary<int, ParseDetail>>
        {
            {Sites.Curse, new Dictionary<int, ParseDetail>
            {
                {1, new ParseDetail(new List<int> { 0 },"","") }
            } },
             {Sites.CurseForge, new Dictionary<int, ParseDetail>
            {
                {1, new ParseDetail(new List<int> { 0 },"","") }
            } },
              {Sites.WoWAce, new Dictionary<int, ParseDetail>
            {
                {1, new ParseDetail(new List<int> { 0 }, "http://www.wowace.com/search/?search={0}", "<td class=\"col-search-entry\"><h2><a href=\"/addons/(.+?)/\"><mark>" ) },
                  {2, new ParseDetail(new List<int> { 1 }, "http://www.wowace.com/addons/{0}/", "<dt>Recent files</dt>.*\n+.+?<a href=\"/addons/.+?/files/(.+?)/\">") },
                  {3,  new ParseDetail(new List<int> { 1, 2 },"http://www.wowace.com/addons/{0}/files/{1}/","<dt>Filename</dt>\n+.+?<dd><a href=\"(.+?)\">") }
            } },
               {Sites.WoWInterface, new Dictionary<int, ParseDetail>
            {
                {1, new ParseDetail(new List<int> { 0 },"","") }
            }}
        };

        public static Dictionary<Sites, Func<string, string>> SITE_TO_SEARCH_STRING_REPLACEMENT_FUNCTION = new Dictionary<Sites, Func<string, string>>
        {
            {Sites.WoWAce, (str) =>  str.Replace(" ", "+") }
        };
    }

  
}

