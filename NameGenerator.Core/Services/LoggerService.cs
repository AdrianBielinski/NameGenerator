using Serilog;

namespace MyApplication.Core.Logging
{
    public class LoggerService
    {
        public void LogError(Exception ex, string message)
        {
            Log.Error(ex, message);
        }

        public void LogWarning(string message)
        {
            Log.Warning(message);
        }

        public void LogInformation(string message)
        {
            Log.Information(message);
        }

        public void LogDebug(string message)
        {
            Log.Debug(message);
        }

        public void LogTrace(string message)
        {
            Log.Verbose(message);
        }
    }
}