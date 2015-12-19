using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWAddonUpdater
{
    enum Types { Alpha, Beta, Release, Unspecified}

    enum Sites { Curse, WoWInterface, WoWAce, CurseForge, Unspecified}

    enum Results { NotFound, Success, DirectoryNotExisting, FileNotExisting, NoWritePermissions, InProgress, ExtractionError,
        Pending, InsufficientSimilarity, ParsingMismatch, SettingsNotFound, SettingsLoaded, SettingsNotSavable, SettingsSaved,
    SerializationError, SerializationSuccess}

    enum States { Downloading, Extracting, Cancelled, DownloadError, ExtractionError, Queued, Downloaded, Extracted, All,
         Enabled, ToBeDeleted, Parsing, ParsingError}
   
}
