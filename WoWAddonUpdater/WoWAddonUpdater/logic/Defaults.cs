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
            Directory.CreateDirectory(UPDATER_DOWNLOAD_ABSOLUTE_PATH);
        }

        internal static readonly string SETTINGS_FILE_NAME = "wowaddonupdater.bin";

        internal static readonly string APP_DATA = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        internal static readonly string UPDATER_RELATIVE_ROOT_DIRECTORY = "/WoWAddonUpdater";

        internal static readonly string UPDATER_ABSOLUTE_ROOT_DIRECTORY = APP_DATA + UPDATER_RELATIVE_ROOT_DIRECTORY;

        internal static readonly string ADDON_RELATIVE_PATH_DEFAULT = "World of Warcraft/Interface/Addons";

        internal static readonly string UPDATER_DOWNLOAD_RELATIVE_PATH = "/Downloads";

        internal static readonly string UPDATER_SETTINGS_RELATIVE_PATH = "/Settings";

        internal static readonly string UPDATER_SETTINGS_ABSOLUTE_PATH = UPDATER_ABSOLUTE_ROOT_DIRECTORY + UPDATER_SETTINGS_RELATIVE_PATH;

        internal static readonly string UPDATER_SETTINGS_FILE_ABSOLUTE_PATH = UPDATER_SETTINGS_ABSOLUTE_PATH + "/" + SETTINGS_FILE_NAME;

        internal static readonly string ADDON_RELATIVE_PATH_FROM_BASE_DIRECTORY = "/Interface/Addons";

        internal static readonly string UPDATER_DOWNLOAD_ABSOLUTE_PATH = UPDATER_ABSOLUTE_ROOT_DIRECTORY + UPDATER_DOWNLOAD_RELATIVE_PATH;

        internal static readonly string ADDON_ABSOLUTE_PATH_DEFAULT = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + ADDON_RELATIVE_PATH_DEFAULT;

        internal static readonly string TOC_PATTERN_DEFAULT = "Title: (.+?)(\\n|#)";

        internal static readonly Sites SITE_DEFAULT = Sites.WoWAce;

        internal static readonly Types TYPE_DEFAULT = Types.Alpha;

        internal static readonly double SIMILARITY_DEFAULT = 0.5;

        internal static readonly string BLIZZARD_ADDON_PREFIX = "Blizzard_";

        internal static readonly string[] ACCEPTED_EXTENSIONS = { ".rar", ".zip" };

        internal const string NAME_DEFAULT = "";
        internal const string DOWNLOAD_DEFAULT = null;
        internal const string IMAGE_DEFAULT = null;
        internal const string DESCRIPTION_DEFAULT = null;
        internal static readonly DateTime LAST_CHECKED_DEFAULT = DateTime.MinValue;
        internal static readonly DateTime LAST_UPDATED_DEFAULT = DateTime.MinValue;
        internal const string INTERFACE_DEFAULT = "1.0.0";

        internal static readonly Dictionary<string, string> TOC_PATTERNS_DEFAULT = new Dictionary<string, string>
        {
            {"title",  "Title: (.+?)(\\n|#)"},
            {"author",  "Author: (.+?)(\\n|#)"},
            {"version",  "Version: (.+?)(\\n|#)"},
            {"notes",  "Notes: (.+?)(\\n|#)"},
            {"interface",  "Interface: (.+?)(\\n|#)"},

        };

        internal static readonly Dictionary<Sites, Dictionary<int, ParseDetail>> SITE_TO_PATTERN_DEFAULT = new Dictionary<Sites, Dictionary<int, ParseDetail>>
        {
            {Sites.Curse, new Dictionary<int, ParseDetail>
            {
                {1, new ParseDetail(new List<int> { 0 },"http://www.curse.com/addons/wow/{0}","") }
            } },
             {Sites.CurseForge, new Dictionary<int, ParseDetail>
            {
                {1, new ParseDetail(new List<int> { 0 },"http://wow.curseforge.com/search/?search={0}&site=all","<tr class=\"odd row-joined-to-next\">(.|\n)+?<a href=\"(.+?)\"><mark>", true, 10) },
                {2, new ParseDetail(new List<int> { 1 },"http://wow.curseforge.com/addons/{0}/","<dt>Recent files</dt>(.|\n)+?<a href=\"/addons/.+?/files/(.+?)/\">", false, 1, true) },
                {3, new ParseDetail(new List<int> { 1, 2 },"http://wow.curseforge.com/addons/{0}/files/{1}/","<dt>Filename</dt>(.|\n)+?<a href=\"(.+?)\">") }
            } },
              {Sites.WoWAce, new Dictionary<int, ParseDetail>
            {
                {1, new ParseDetail(new List<int> { 0 }, "http://www.wowace.com/search/?search={0}&site=all", "<td class=\"col-search-entry\"><h2><a href=\"/addons/(.+?)/\"><mark>", true, 10 ) },
                  {2, new ParseDetail(new List<int> { 1 }, "http://www.wowace.com/addons/{0}/", "<dt>Recent files</dt>.*\n+.+?<a href=\"/addons/.+?/files/(.+?)/\">", false, 1, true) },
                  {3,  new ParseDetail(new List<int> { 1, 2 },"http://www.wowace.com/addons/{0}/files/{1}/","<dt>Filename</dt>\n+.+?<dd><a href=\"(.+?)\">") }
            } },
               {Sites.WoWInterface, new Dictionary<int, ParseDetail>
            {
                {1, new ParseDetail(new List<int> { 0 },"","") }
            }}
        };

        internal static Dictionary<Sites, Func<string, string>> SITE_TO_SEARCH_STRING_REPLACEMENT_FUNCTION = new Dictionary<Sites, Func<string, string>>
        {
            {Sites.WoWAce, (str) =>  str.Replace(" ", "+") }
        };
    }

  
}

