using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_1
{
    static class Logging
    {
        static string errorFileName = "errorlog.txt";
        static string logFileName = "log.txt";

        public static void WriteToFile(string logStr, string fileName)
        {
            using (FileStream aFile = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(aFile))
            {
                sw.WriteLine(logStr);
            }
        }

        // Used for logging errors
        public static void Error(string logStr)
        {
            WriteToFile(DateTime.Now + " - Error: " + logStr, errorFileName);
        }

        // For debugging
        public static void Debug(string logStr)
        {
            WriteToFile(DateTime.Now + " - Debug: " + logStr, errorFileName);
        }

        // For logging purposes
        public static void Log(string logStr)
        {
            WriteToFile(DateTime.Now + " - Log: " + logStr, logFileName);
        }
    }
}
