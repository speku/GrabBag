using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WoWAddonUpdater
{
    [Serializable]
    class Config
    {

        internal static event Action<Results, string> SettingsLoaded;
        internal static event Action<Results, string> SettingsSaved;

        internal static Config Settings;

        internal  List<Addon> allAddons = new List<Addon>();
        internal  List<string> invalidAddonTitles = new List<string>();
        internal  List<string> parsedTitles = new List<string>();

        internal  Dictionary<Sites, Dictionary<int, ParseDetail>> siteToPattern = new Dictionary<Sites, Dictionary<int, ParseDetail>>();
        internal  Dictionary<Sites, Func<string, string>> siteToSearchStringReplacement = new Dictionary<Sites, Func<string, string>>();

        internal  double similarity = Defaults.SIMILARITY_DEFAULT;
        internal  Sites site = Defaults.SITE_DEFAULT;
        internal  Types type = Types.Alpha;

         internal static string wowBasePath = Environment.GetEnvironmentVariable("WoW");
         internal string addonAbsolutePath = wowBasePath != null && Directory.Exists(wowBasePath) ? wowBasePath + Defaults.ADDON_RELATIVE_PATH_FROM_BASE_DIRECTORY :
            Directory.Exists(Defaults.ADDON_ABSOLUTE_PATH_DEFAULT) ? Defaults.ADDON_ABSOLUTE_PATH_DEFAULT :
            null;
         internal string tocPattern;

        internal Config()
        {
        }

        static Config()
        {
            Directory.CreateDirectory(Defaults.UPDATER_SETTINGS_ABSOLUTE_PATH);

        }

        private static void LoadSettings()
        {
            string error;
            Results result;
            Config settings = Deserialize<Config>(Defaults.UPDATER_SETTINGS_FILE_ABSOLUTE_PATH, out result, out error);
            if (settings != null)
            {
                Config.Settings = settings;
                if (SettingsLoaded != null)
                {
                    SettingsLoaded(Results.SettingsLoaded, error);
                }
            }
            else
            {

                Config.Settings = new Config();
                if (SettingsLoaded != null)
                {
                    SettingsLoaded(result, error);
                }
            }
        }


        private static void SaveSettings()
        {
            Results res = Serialize<Config>(Settings, Defaults.UPDATER_SETTINGS_FILE_ABSOLUTE_PATH);

        }


        private static Results Serialize<T>(T obj, string filePath)
        {

            if (!Utils.Permissions(filePath))
            {
                return Results.NoWritePermissions;
            }

            using (Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                try
                {
                    new BinaryFormatter().Serialize(stream, obj);
                    return Results.SerializationSuccess;
                } catch
                {
                    return Results.SerializationError;
                }
            }
        }


        private static T Deserialize<T>(string filePath, out Results result, out string error)
        {

            if (!File.Exists(filePath))
            {
                result = Results.FileNotExisting;
                error = null;
                return default(T);
            }

            using (Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                try
                {
                    result = Results.SerializationSuccess;
                    error = null;
                    return (T)new BinaryFormatter().Deserialize(stream);
                } catch(Exception ex)
                {
                    result = Results.SerializationError;
                    error = ex.Message;
                    return default(T);
                }
            }
        }


    }
}
