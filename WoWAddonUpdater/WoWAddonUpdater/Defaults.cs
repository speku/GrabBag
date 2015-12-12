using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWAddonUpdater
{
    class Defaults
    {
        static public readonly string ADDON_RELATIVE_PATH_DEFAULT = "World of Warcraft/Interface/Addons";

        static public readonly string DOWNLOAD_RELATIVE_PATH_DEFAULT = "WoWAddonUpdater/Downloads";

        static public readonly string DOWNLOAD_ABSOLUTE_PATH_DEFAULT = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + DOWNLOAD_RELATIVE_PATH_DEFAULT;

        static public readonly string ADDON_ABSOLUTE_PATH_DEFAULT = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + ADDON_RELATIVE_PATH_DEFAULT;

        static public readonly string TOC_PATTERN_DEFAULT = "Title: ([\\W ]+?[\n#]";

        static public readonly Dictionary<Sites, Dictionary<int, ParseDetail>> SITE_TO_PATTERN_DEFAULT = new Dictionary<Sites, Dictionary<int, ParseDetail>>
        {
            {Sites.Curse, new Dictionary<int, ParseDetail>
            {
                {1, new ParseDetail(0,"","") }
            } },
             {Sites.CurseForge, new Dictionary<int, ParseDetail>
            {
                {1, new ParseDetail(0,"","") }
            } },
              {Sites.WoWAce, new Dictionary<int, ParseDetail>
            {
                {1, new ParseDetail(0, "http://www.curse.com/addons/wow/{0}", "<td class=\"col-search-entry\"><h2><a href=\"/addons/(.+?)/\"><mark>" ) },
                  {2, new ParseDetail(1, "http://www.wowace.com/addons/{0}/", "<dt>Recent files</dt>\\[\\n.]+?<a href = \"/addons/.+?/files/(.+?)/\">") },
                  {3,  new ParseDetail(1,"http://www.wowace.com/addons/{0}/files/{1}/","<dt>Filename</dt>[\\n.]+?<dd><a href=\"(.+?)\">") }
            } },
               {Sites.WoWInterface, new Dictionary<int, ParseDetail>
            {
                {1, new ParseDetail(0,"","") }
            }}
        };
    }

    class Actual
    { 

        static public string addonAbsolutePath;

        static public string tocPattern;

    }
}
