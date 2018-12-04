namespace ShapeDrawer.Server.Logger
{
    public interface ILogger
    {
        void Debug(string message);
        void Debug(string message, System.Exception ex);
        void Error(string message);
        void Error(string message, System.Exception ex);
        void Fatal(string message);
        void Fatal(string message, System.Exception ex);
        void Info(string message);
        void Info(string message, System.Exception ex);
        void Trace(string message);
        void Trace(string message, System.Exception ex);
        void Warn(string message);
        void Warn(string message, System.Exception ex);
    }
}