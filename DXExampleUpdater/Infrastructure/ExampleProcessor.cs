using DXExampleUpdater.Infrastructure;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DXExampleUpdater
{
    public class ExampleProcessor
    {
        string gitUri;
        public string Id { get; }
        public string BranchName { get; set; } = "18.1.4+";

        public string ExamplePath { get;  }

        public ExampleProcessor(string id)
        {
            Id = id.Trim().ToLower();
            ExamplePath = PathHelper.GetExamplePath(Id);
        }

     
        public async Task ProcessExample()
        {
            Logger.Log($"===Processing Example: {Id} ===");
            gitUri = await GetGitUri();
            Logger.Log($"Uri: {gitUri}");
            Logger.Log("Cloning..");
            CloneRepo();
            CreateBranch();
            DeleteVB();
            OpenFolder();
            Logger.Log("Done!");
        }

        async Task<string> GetGitUri()
        {
            return await Task.Run(() => NetworkUtils.GetRedirectUrl(PathHelper.GetExampleUrl(Id)));
        }

        void DeleteVB()
        {
            var vbPath = Path.Combine(ExamplePath, "VB");
            if (Directory.Exists(vbPath))
            {
                Logger.Log($"Deleting VB: {vbPath}");
                Directory.Delete(vbPath, true);
            }
        }
        void OpenFolder()
        {
            Process.Start(ExamplePath);
        }

        void CreateBranch()
        {
            GitUtils.CreateSelectBranch(BranchName);
        }


        void CloneRepo()
        {
            GitUtils.Clone(gitUri, ExamplePath);
            Logger.Log($"Cloned to {ExamplePath}");
        }
    }
}
