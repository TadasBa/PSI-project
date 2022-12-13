using Android.Media;
using System;
using System.Diagnostics;
using System.IO;
using Android.App;
using static Android.Graphics.ImageDecoder;
using Xamarin.CommunityToolkit.Converters;
using Android;
using System.Reflection;
using Stream = System.IO.Stream;

namespace Pantry.Utilities
{
    public static class ExceptionLogger
    {
        private static string name, type, location, message, stackTrace;
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
            stackTrace = st.ToString();

            string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ExceptionLog.txt");

            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLine("Date: " + DateTime.Now.ToString()
                            + "\nName: " + name
                            + "\nType: " + type
                            + "\nLocation: " + location
                            + "\nLine: " + line
                            + "\nMessage: " + message
                            + "\nStack trace: " + stackTrace
                            + "\n------------------------------------------------------");
               
                sw.Flush();
                sw.Close();
            }

            //string text = File.ReadAllText(file);
            //Debug.WriteLine(text);
        }
    }
}
