namespace BackendAPI.Middleware
{
    public interface ILogService
    {
        void Log(string message);
        void LogMethod(Exception exception, string message);

        void LogDatabase(string command);
    }
}
