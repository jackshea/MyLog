namespace YezhStudio.Base
{
    public interface IOutput
    {
        void Output(string message, string category, LogLevel logLevel);
    }
}