using Serilog;
using Serilog.Events;
using System;
using System.IO;

namespace TestProject.Core
{
    public static class Logger
    {
        private static readonly string LogTo = Environment.GetEnvironmentVariable("LogTo") ?? "Console";

        static Logger()
        {
            switch (LogTo)
            {
                case "File":
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .Enrich.FromLogContext()
                        .WriteTo.File(Path.Combine(Environment.CurrentDirectory, "Log.txt"))
                        .CreateLogger();
                    break;
                case "Console":
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .CreateLogger();
                    break;
                default:
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                        .Enrich.FromLogContext()
                        .WriteTo.Debug()
                        .CreateLogger();
                    break;
            }
        }

        public static void LogInformation(string info)
        {
            Log.Information("==========INFO==========");
            Log.Information(info);
        }

        public static void LogError(string info)
        {
            Log.Error("==========ERROR==========");
            Log.Error(info);
        }
    }
}
