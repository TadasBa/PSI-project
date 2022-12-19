namespace BackendAPI.Middleware
{
    public class LogService : ILogService
    {

        private readonly string path = "~/logs/";
        public LogService()
        {
            Directory.CreateDirectory(path);   
        }
        public void Log(string message)
        {
            string localpath = path + DateTime.Today.Date.ToString("yyyyMMdd");
            if (File.Exists(localpath))
            {
                StreamWriter sw = new StreamWriter(localpath, true);
                sw.WriteLine(DateTime.Now.TimeOfDay.ToString() + " " + message);
                sw.Flush();
                sw.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter(localpath);
                sw.WriteLine(DateTime.Now.TimeOfDay.ToString() + " " + message);
                sw.Flush();
                sw.Close();
            }
        }

        public void LogMethod(Exception exception, string message)
        {
            string localpath = path + DateTime.Today.Date.ToString("yyyyMMdd" + "METHOD");
            if (File.Exists(localpath))
            {
                StreamWriter sw = new StreamWriter(localpath, true);
                sw.WriteLine(DateTime.Now.TimeOfDay.ToString() + " " + message);
                if (exception != null) sw.WriteLine(exception.Message);
                if (exception != null) sw.WriteLine(exception.StackTrace);
                sw.Flush();
                sw.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter(localpath);
                sw.WriteLine(DateTime.Now.TimeOfDay.ToString() + " " +  message);
                if (exception != null) sw.WriteLine(exception.Message);
                if (exception != null) sw.WriteLine(exception.StackTrace);
                sw.Flush();
                sw.Close();
            }
        }

        public void LogDatabase(string message)
        {
            string localpath = path + DateTime.Today.Date.ToString("yyyyMMdd") + "DB";
            if (File.Exists(localpath))
            {
                StreamWriter sw = new StreamWriter(localpath, true);
                sw.WriteLine(DateTime.Now.TimeOfDay.ToString() + " " + message);
                sw.Flush();
                sw.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter(localpath);
                sw.WriteLine(DateTime.Now.TimeOfDay.ToString() + " " + message);
                sw.Flush();
                sw.Close();
            }
        }

    }
}
