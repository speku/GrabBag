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
    }

    class Actual
    { 

        static public string addonAbsolutePath;

    }
}
