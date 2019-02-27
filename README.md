# KeyloggerRemake
A complete object-oriented remake of a keylogger I've built in 2016, this time in C#.

In order to make the keylogger work, the following is needed to be done:
1. Get [KeyloggerController](https://github.com/outerme/KeyloggerController)
2. Edit its local json file as well as where to encrypt it to
   - In classJsonObj: Change `strJsonDir = @"ADDYOURDIRECTORYHERE"` to a directory with an empty Json file.
   - In classJsonObj: Change `strEncryptDir = @"ADDYOURDIRECTORYHERE"` to a directory to save that Json file, encrypted.
3. Change KeyloggerRemake's encrypted key to the public link of the specified encrypted directory in the Controller
   - In classGetEncryption: Change `strEncryptedFile = "ADDYOURURLHERE` to the public URL of that encrypted Json file (Must auto download!).
4. Change settings in KeyloggerController upon runtime.

## Packages used:
- Newtonsoft.Json
