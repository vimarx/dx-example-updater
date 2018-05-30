using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXExampleUpdater.Infrastructure
{
    public class GitUtils
    {
        public string Path { get; set; }

        public GitUtils(string path)
        {
            Path = path;
        }

        public void Clone(string gitUri, string targetDir)
        {
            Cmd($"clone {gitUri} \"{targetDir}\"");
        }

        public void Cmd(string cmd)
        {
            ProcessStartInfo info = new ProcessStartInfo("cmd.exe")
            {
                Arguments = $"/K git {cmd}",
                UseShellExecute = false,
                WorkingDirectory = Path
            };
            Process p = new Process()
            {
                StartInfo = info
            };
            p.Start();
            p.WaitForExit();
        }

        public void CreateSelectBranch(string branchName)
        {
            Cmd($"checkout -b {branchName}");
        }
        public void AddAll()
        {
            Cmd($"add -A");
        }

        public void Status()
        {
            Cmd("status");
        }
        public void Commit(string text)
        {
            Cmd($"commit - a - m \"{text}\"");
        }


    }
}
