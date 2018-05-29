using System;
using System.IO;
using System.Linq;

namespace DXExampleUpdater
{
    public static class PathHelper
    {
        public static string RootFolder {
            get {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DXExampleUpdater");
            }
        }
        public static string GetExamplePath(string id)
        {
            var path = EnsureDir(Path.Combine(RootFolder, "Examples", id));
            return path;
        }

        private static string EnsureDir(string dir)
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return dir;
        }

        public static string GetConfigurationPath()
        {
            var dir = EnsureDir(Path.Combine(RootFolder, "Configuration"));
            return Path.Combine(dir, "Config.xml");
        }
        public static string GetExampleUrl(string id)
        {
            return $"https://www.devexpress.com/Support/Center/Question/Details/{id}";
        }

    }
}
