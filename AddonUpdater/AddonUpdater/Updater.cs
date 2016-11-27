using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.IO.Compression;
using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;

namespace AddonUpdater
{
    static class Updater
    {
        public static Tuple<string, IEnumerable<string>> parseFile()
        {
            var addonList = "UpdateAddons.txt";
            var addonDir = @"\Interface\AddOns";
            if (File.Exists(addonList)) {
                var lines = File.ReadLines(addonList);
                var addonFolder = lines.First(l => l.Contains(addonDir));
                var urls = lines.Where(l => l.Contains("http"));
                urls = urls.Select(url => 
                url.Contains("wowace") || url.Contains("curseforge") ? url.Replace("/addons/", "/projects/") + "files/latest" :
                url.Contains("curse.com") ? url + "download" :
                url.Contains("wowinterface") ? url.Replace("/info", "/download").Replace(".html", "") :
                url);
                return Tuple.Create(addonFolder, urls);
            }
            return null;
        }

        public static string download(string url, string location, bool initial = true)
        {
            string uri = url;
            try
            {
                string filePath;
                HttpWebRequest r = (HttpWebRequest)WebRequest.Create(url);
                r.MaximumAutomaticRedirections = 10;
                r.AllowAutoRedirect = true;
                HttpWebResponse re = (HttpWebResponse)r.GetResponse();
                using (var c = new WebClient())
                {
                    uri = re.ResponseUri.ToString();
                    re.Close();
                    var fileName = uri.Split('/').Last();
                    handleWowinterface(ref uri, ref fileName, c);
                    filePath = Path.Combine(location, fileName);
                    c.DownloadFile(uri, filePath);
                }
                return filePath;
            } catch
            {
                if (initial)
                {
                    return download(url.Replace("www.wowace.com", "wow.curseforge.com"), location, false);
                } else
                {
                    Console.WriteLine("download failure :" + uri);
                    return null;
                }
            }
        }

        public static void handleWowinterface(ref string url, ref string name, WebClient client)
        {
            if (!url.Contains("wowinterface")) return;
            var source = client.DownloadString(url);
            var pattern = @"Problems with the download\? <a href=""(http:\/\/cdn\.wowinterface\.com\/downloads\/file\d+\/.+\.zip)";
            var match = Regex.Match(source, pattern);
            url = Regex.Match(source, pattern).Groups[1].Value;
            name = url.Split('/').Last();
        }

        public static string createTempDirectory()
        {
            var path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(path);
            return path;
        }

        public static void deleteDirectory(string path)
        {
            FileSystem.DeleteDirectory(path, DeleteDirectoryOption.DeleteAllContents);
        }


        public static void unzip(string file, string to)
        {
            if (file == null)
            {
                return;
            }
            try
            {
                var tempLocation = createTempDirectory();
                ZipFile.ExtractToDirectory(file, tempLocation);
                FileSystem.CopyDirectory(tempLocation, to, true);
                deleteDirectory(tempLocation);
                Console.WriteLine("updated " + file.Split('\\').Last());
            } catch
            {

            }
        }



        public static void update()
        {
            var downloadLocation = createTempDirectory();
            var addonFolderAndUrls = parseFile();
            if (addonFolderAndUrls != null)
            {
                Action<string> downloadUnzip = url => unzip(download(url, downloadLocation), addonFolderAndUrls.Item1);

                addonFolderAndUrls.Item2.AsParallel().ForAll(downloadUnzip);
            }
            deleteDirectory(downloadLocation);
            Console.WriteLine("\ndone :-)");

            Console.ReadKey();
        }
    }
}
