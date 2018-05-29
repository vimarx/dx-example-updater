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
        public static void Clone(string gitUri, string targetDir)
        {
            Cmd($"clone {gitUri} \"{targetDir}\"");
        }

        public static void Cmd(string cmd)
        {
            ProcessStartInfo info = new ProcessStartInfo("cmd.exe");
            info.Arguments = $"/C git {cmd}";
            info.UseShellExecute = false;
          
            Process p = new Process();
            p.StartInfo = info;
            p.Start();
            p.WaitForExit();
        }

        public static void CreateSelectBranch(string branchName)
        {
            Cmd($"checkout -b {branchName}");
        }

       
    }
}
