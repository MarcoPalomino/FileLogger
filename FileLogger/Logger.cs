using System;
using System.Text;
using System.Configuration;
using System.IO;

namespace FileLogger
{
    public class Logger: ILogger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="logMessage"></param>
        public bool DoLog(string logType, string logMessage)
        {
            try
            {
                //Build the message for log
                var strLog = string.Empty;
                strLog = PrepareLogMessage(logType, logMessage);

                //Saving the log in the File, create a new one if there is no file
                var path = GetPath();
                
                if (!File.Exists(path))
                    File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path,true))
                {
                    tw.WriteLine(strLog.ToString());
                    tw.Close();
                }
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="logMessage"></param>
        /// <returns></returns>
        public string PrepareLogMessage(string logType, string logMessage) {

            var strLog = new StringBuilder();

            strLog.Append(string.Format("Time: {0}/{1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));
            strLog.Append(Environment.NewLine);

            strLog.Append(string.Format("Type: {0}", logType));
            strLog.Append(Environment.NewLine);

            strLog.Append(string.Format("Message: {0}", logMessage));
            strLog.Append(Environment.NewLine);

            return strLog.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetPath()
        {
            return ConfigurationManager.AppSettings["LogFilePath"] + "LogFile" + DateTime.Now.ToShortDateString().Replace("/", "") + ".txt";
        }
    }
}
