using System;

namespace ShapeDrawer.Client.Logger
{
    public class Logger
    {
        private static Logger instance;

        private Logger()
        {
        }

        public static Logger Instance
        {
            get { return instance ?? (instance = new Logger()); }
        }

        public void Debug(string message)
        {
            WriteLine("Debug", message);
        }

        public void Debug(string message, System.Exception ex)
        {
            WriteLine("Debug", message, ex);
        }

        public void Error(string message)
        {
            WriteLine("Error", message);
        }

        public void Error(string message, System.Exception ex)
        {
            WriteLine("Error", message, ex);
        }

        public void Fatal(string message)
        {
            WriteLine("Fatal", message);
        }

        public void Fatal(string message, System.Exception ex)
        {
            WriteLine("Fatal", message, ex);
        }

        public void Info(string message)
        {
            WriteLine("Info", message);
        }

        public void Info(string message, System.Exception ex)
        {
            WriteLine("Info", message, ex);
        }

        public void Trace(string message)
        {
            WriteLine("Trace", message);
        }

        public void Trace(string message, System.Exception ex)
        {
            WriteLine("Trace", message, ex);
        }

        public void Warn(string message)
        {
            WriteLine("Warn", message);
        }


        public void Warn(string message, System.Exception ex)
        {
            WriteLine("Warn", message, ex);
        }

        private void WriteLine(string methodType, string message)
        {
            Console.WriteLine(string.Format("{0}:{1}", methodType, message));
        }

        private void WriteLine(string methodType, string message, System.Exception exception)
        {
            if (exception == null)
                WriteLine(methodType, message);
            else
                WriteLine(methodType, string.Format("{0}:{1}", message, exception?.Message));
        }
    }
}
