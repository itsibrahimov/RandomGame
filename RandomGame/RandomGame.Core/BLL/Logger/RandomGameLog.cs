using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RandomGame.Core.BLL.Logger
{
    public enum LogType
    {
        Insert,
        Update,
        Delete,
        Error,
        NotFound,
        Success,
        Warning,
        NonValidation
    }
    public static class RandomGameLog
    {
        public static void LogAdd(string message,LogType logType)
        {
            FileStream fs = new FileStream("RandomGameLog.txt", FileMode.Append);
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine("Log Tarihi: "+DateTime.Now+" Log Türü: "+logType+" Log Mesajı: "+message);
            writer.Flush();
            writer.Close();
        }
    }
}
