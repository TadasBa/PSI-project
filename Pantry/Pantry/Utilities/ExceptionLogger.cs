using System;
using System.Diagnostics;
using System.IO;


namespace Pantry.Utilities
{
    public static class ExceptionLogger
    {
        private static string name, type, location, message;
        private static int line;
        public static void LogExceptionToFile(Exception e, String eMessage = "no specified message")
        {
            StackTrace st = new StackTrace(e, true);
            StackFrame sf = st.GetFrame(0);

            name = e.GetType().Name;
            type = e.GetType().ToString();
            location = e.Message;
            line = sf.GetFileLineNumber();
            message = eMessage;

            string path = Path.GetFullPath("ExceptionLog.txt");

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine("Date: " + DateTime.Now.ToString() 
                            + "\nName: " + name
                            + "\nType: " + type
                            + "\nLocation: " + location
                            + "\nLine: " + line
                            + "\nMessage: " + message
                            + "\n------------------------------------------------------");

                sw.Flush();
                sw.Close();
            }

               

        }
    }
}
