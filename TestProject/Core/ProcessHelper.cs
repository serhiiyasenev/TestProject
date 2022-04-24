﻿using System.Diagnostics;

namespace TestProject.Core
{
    public static class ProcessHelper
    {
        public static void KillAllProcesses(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                try
                {
                    process.Kill();
                }
                catch
                {
                    // ignored
                }
            }
        }
    }
}
