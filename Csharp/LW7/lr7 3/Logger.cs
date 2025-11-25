public class Logger
{
    private readonly string filePath = "log.txt";

    public void Log(string message)
    {
        File.AppendAllText(filePath, $"{DateTime.Now}: {message}\n");
    }
}