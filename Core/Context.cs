using Core.Enums;
using static System.Enum;
using static System.Environment;

namespace Core
{
    public static class Context
    {
        public static readonly Browser Browser;
        public static readonly bool BrowserHeadless;
        public static readonly Environment Environment;

        static Context()
        {
            Browser = !string.IsNullOrEmpty(GetEnvironmentVariable("Browser")) 
                ? (Browser)Parse(typeof(Browser), GetEnvironmentVariable("Browser")!, true) 
                : Browser.Chrome;

            Environment = !string.IsNullOrEmpty(GetEnvironmentVariable("Environment"))
                ? (Environment)Parse(typeof(Environment), GetEnvironmentVariable("Environment")!, true)
                : Environment.Test;

            BrowserHeadless = !string.IsNullOrEmpty(GetEnvironmentVariable("BrowserHeadless"))
                ? bool.Parse(GetEnvironmentVariable("BrowserHeadless"))
                : true;
        }
    }
}
