using System.Diagnostics;

namespace Infrastructure.Utils;

public static class Logger
{
    private static readonly string LogFilePath = "../../../../log.txt";

    public static void Log(string message)
    {
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}---------------------------{Environment.NewLine}";

        Console.WriteLine(logEntry);
        Debug.WriteLine(message);

        File.AppendAllText(LogFilePath, logEntry);
    }
}
