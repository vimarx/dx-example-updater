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
        public GitUtils Git { get;  }

        public ExampleProcessor(string id)
        {
            Id = id.Trim().ToLower();
            ExamplePath = PathHelper.GetExamplePath(Id);
            Git = new GitUtils(ExamplePath); ;
        }

     
        public async Task PreProcessExample()
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
            Git.CreateSelectBranch(BranchName);
        }


        public void Commit(string message)
        {
            Git.Status();
            Git.AddAll();
            Git.Status();
            Git.Commit(message);
        }

        void CloneRepo()
        {
            Git.Clone(gitUri, ExamplePath);
            Logger.Log($"Cloned to {ExamplePath}");
        }
    }
}
