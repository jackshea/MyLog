namespace YezhStudio.Base
{
    public interface IFormater
    {
        string FormatString(string message, string category, LogLevel logLevel);
    }
}