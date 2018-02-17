using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSS.Logger
{
    public class Logger
    {
        private string sLogDirectory;
        private string sLogFileName;
        private bool isDateWiseLogs;
        private string sLogPath;

        public Logger()
        {
            sLogDirectory = ConfigurationManager.AppSettings["LogDirectory"].ToString();
            sLogFileName = ConfigurationManager.AppSettings["LogFileName"].ToString();
            isDateWiseLogs = ConfigurationManager.AppSettings["isDateWiseLogs"].ToString() == "1" ? true : false;
            if (isDateWiseLogs)
            {
                sLogPath = sLogDirectory + DateTime.Now.Date.ToString("yyyy-MM-dd") + "-" + sLogFileName;
            }
            else
            {
                sLogPath = sLogDirectory + sLogFileName;
            }
            if (!Directory.Exists(sLogDirectory))
            {
                Directory.CreateDirectory(sLogDirectory);
            }
            if (!File.Exists(sLogPath))
            {
                File.Create(sLogPath).Close();
            }
        }
        public void Log(string sClass, string sFunction, string sMessage)
        {
            string logPath = this.sLogPath;
            string sLogMessage;

            
            sLogMessage = DateTime.Now + " || " + sClass + "." + sFunction + " || " + sMessage;

            File.AppendAllLines(logPath, new[] { sLogMessage });
            
        }
        public void Initialize(string sLogDirectory, string sLogFileName, bool isDateWiseLogs)
        {
            this.sLogDirectory = sLogDirectory;
            this.sLogFileName = sLogFileName;
            this.isDateWiseLogs = isDateWiseLogs;

            if (isDateWiseLogs)
            {
                sLogPath = sLogDirectory + DateTime.Now.Date.ToString("yyyy-MM-dd") + "-" + sLogFileName;
            }
            else
            {
                sLogPath = sLogDirectory + sLogFileName;
            }
            if (!Directory.Exists(sLogDirectory))
            {
                Directory.CreateDirectory(sLogDirectory);
            }
            if (!File.Exists(sLogPath))
            {
                File.Create(sLogPath).Close();
            }
        }
    }
}
