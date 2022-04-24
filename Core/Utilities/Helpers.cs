using System.Diagnostics;

namespace Core.Utilities
{
    public static class Helpers
    {
        public static int GetFactorial(int fact)
        {
            if (fact == 0)
                return 1;
            return fact * GetFactorial(fact - 1);
        }

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
