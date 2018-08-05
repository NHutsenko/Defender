using UnityEngine;

public static class Logger {

    private static readonly ILogger _logger = new UnityDebugLogger();

    public static void LogMessage(string msg) {
        _logger.Info(msg);
    }

    public static void LogError(string msg) {
        _logger.Error(msg);
    }

    public static void LogWarning(string msg) {
        _logger.Warning(msg);
    }
}
