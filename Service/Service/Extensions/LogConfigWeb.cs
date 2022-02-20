using Serilog;
using System.Configuration;

namespace Service.Extensions
{
    public class LogConfigWeb
    {
        public static ILogger GetLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(ConfigurationManager.AppSettings["log"],
                    outputTemplate:
                    "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();
            return Log.Logger;
        }
    }
}