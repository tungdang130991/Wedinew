
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using WebEDI.Common.Core;

namespace WebEDI.Common.Core
{
    public static class Utility
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            const string pattern = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            return Regex.IsMatch(email, pattern);
        }

        #region Convert data

        public static string ConvertToString(object value)
        {
            return null == value ? string.Empty : value.ToString();
        }
        public static int ConvertToInt(object value)
        {
            int returnValue;
            if (null == value || !int.TryParse(value.ToString(), out returnValue))
            {
                returnValue = 0;
            }
            return returnValue;
        }
        public static long ConvertToLong(object value)
        {
            long returnValue;
            if (null == value || !long.TryParse(value.ToString(), out returnValue))
            {
                returnValue = 0;
            }
            return returnValue;
        }
        public static short ConvertToShort(object value)
        {
            short returnValue;
            if (null == value || !short.TryParse(value.ToString(), out returnValue))
            {
                returnValue = 0;
            }
            return returnValue;
        }
        public static decimal ConvertToDecimal(object value)
        {
            decimal returnValue;
            if (null == value || !decimal.TryParse(value.ToString(), out returnValue))
            {
                returnValue = 0;
            }
            return returnValue;
        }
        public static double ConvertToDouble(object value)
        {
            double returnValue;
            if (null == value || !double.TryParse(value.ToString(), out returnValue))
            {
                returnValue = 0;
            }
            return returnValue;
        }
        public static DateTime ConvertToDateTime(object value)
        {
            DateTime returnValue;

            //var ci = new CultureInfo("en-US");
            //var dtf = new DateTimeFormatInfo { ShortDatePattern = "dd/MM/yyyy", ShortTimePattern = "HH:mm:ss" };
            //ci.DateTimeFormat = dtf;
            //System.Threading.Thread.CurrentThread.CurrentCulture = ci;

            if (null == value || !DateTime.TryParse(value.ToString(), out returnValue))
            {
                returnValue = DateTime.MinValue;
            }
            return returnValue;
        }

        public static TimeSpan ConvertToTimeSpan(object value)
        {
            TimeSpan timeSpan;
            if (null == value || !TimeSpan.TryParse(value.ToString(), out timeSpan))
            {
                timeSpan = TimeSpan.MinValue;
            }
            return timeSpan;

        }

        public static bool ConvertToBoolean(object value)
        {
            bool returnValue;
            if (null == value || !bool.TryParse(value.ToString(), out returnValue))
            {
                returnValue = false;
            }
            return returnValue;
        }

        public static byte ConvertToByte(object value)
        {
            byte returnValue;
            if (null == value || !byte.TryParse(value.ToString(), out returnValue))
            {
                returnValue = 0;
            }
            return returnValue;
        }

        #endregion

        #region Old functions

        public static long ConvertToInt(object obj, long defaultValue = 0)
        {
            long result;
            return long.TryParse(obj.ToString(), out result) ? result : defaultValue;
        }

        public static int ConvertToInt(object obj, int defaultValue = 0)
        {
            int result;
            return int.TryParse(obj.ToString(), out result) ? result : defaultValue;
        }

        public static string JavaScriptSring(string input)
        {
            input = input.Replace("'", "\\u0027");
            input = input.Replace("\"", "\\u0022");
            return input;
        }

        const string UniChars = "àáảãạâầấẩẫậăằắẳẵặèéẻẽẹêềếểễệđìíỉĩịòóỏõọôồốổỗộơờớởỡợùúủũụưừứửữựỳýỷỹỵÀÁẢÃẠÂẦẤẨẪẬĂẰẮẲẴẶÈÉẺẼẸÊỀẾỂỄỆĐÌÍỈĨỊÒÓỎÕỌÔỒỐỔỖỘƠỜỚỞỠỢÙÚỦŨỤƯỪỨỬỮỰỲÝỶỸỴÂĂĐÔƠƯ";
        const string KoDauChars = "aaaaaaaaaaaaaaaaaeeeeeeeeeeediiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAAEEEEEEEEEEEDIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYAADOOU";

        public static string UnicodeToKoDau(string s)
        {
            var retVal = "";
            for (int i = 0; i < s.Length; i++)
            {
                var pos = UniChars.IndexOf(s[i].ToString());
                if (pos >= 0)
                    retVal += KoDauChars[pos];
                else
                    retVal += s[i];
            }
            return retVal;
        }

        public static string ConvertToUnsignChar(string inputString)
        {
            return ConvertTextToLink(inputString, " ");
        }

        public static string UnicodeToKoDauAndGach(string s)
        {
            const string strChar = "abcdefghijklmnopqrstxyzuvxw0123456789/- ";
            s = UnicodeToKoDau(s.ToLower().Trim());
            var sReturn = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (strChar.IndexOf(s[i]) > -1)
                {
                    if (s[i] != ' ')
                        sReturn += s[i];
                    else if (i > 0 && s[i - 1] != ' ' && s[i - 1] != '-')
                        sReturn += "-";
                }
            }
            return sReturn.Replace("--", "-").Replace("/", "-");
        }

        #endregion

        #region new functions

        public static string AddSlash(string input)
        {
            var str = !string.IsNullOrEmpty(input) ? input.Trim() : "";
            if (str != "")
            {
                str = str.Replace("'", "'").Replace("\"", "\\\"");
            }
            return str;
        }

        public static string ReplaceSpaceToPlus(string input)
        {
            return string.IsNullOrEmpty(input) ? input : Regex.Replace(input, "\\s+", "+", RegexOptions.IgnoreCase);
        }

        public static string ConvertCurentce(string sNumber)
        {
            var num = 3;
            var num2 = 0;
            for (int i = 1; i <= (sNumber.Length / 3); i++)
            {
                if ((num + num2) < sNumber.Length)
                {
                    sNumber = sNumber.Insert((sNumber.Length - num) - num2, ".");
                }
                num += 3;
                num2++;
            }
            return sNumber;
        }

        public static string ConvertTextToLink(string inputString, params string[] paternList)
        {
            if (inputString == "")
            {
                return "";
            }
            var input = inputString.Trim().ToLower();
            var replacement = "-";
            if (paternList.Length > 0)
            {
                replacement = paternList[0];
            }
            var str = Regex.Replace(input, "^[0-9]+", string.Empty);
            str = Regex.Replace(str, "\x00e1|\x00e0|ạ|ả|\x00e3|ă|ắ|ằ|ặ|ẳ|ẵ|\x00e2|ấ|ầ|ậ|ẩ|ẫ", "a");
            str = Regex.Replace(str, "đ|Đ", "d");
            str = Regex.Replace(str, "\x00f3|\x00f2|ọ|ỏ|\x00f5|ơ|ớ|ờ|ợ|ở|ỡ|\x00f4|ố|ồ|ộ|ổ|ỗ", "o");
            str = Regex.Replace(str, "\x00fa|\x00f9|ụ|ủ|ũ|ư|ứ|ừ|ự|ử|ữ", "u");
            str = Regex.Replace(str, "\x00e9|\x00e8|ẹ|ẻ|ẽ|\x00ea|ế|ề|ệ|ể|ễ", "e");
            str = Regex.Replace(str, "\x00ed|\x00ec|ị|ỉ|ĩ", "i");
            str = Regex.Replace(str, "\x00fd|ỳ|ỵ|ỷ|ỹ", "y");
            str = Regex.Replace(str, "\"|'|_+|\\.+", string.Empty);

            str = Regex.Replace(str, @"[^\w\-]", " ");
            str = Regex.Replace(str, @"-$|-+|\s+", replacement);
            return str;
        }

        public static string ConvertTextToUnsignName(string inputString, params string[] paternList)
        {
            if (inputString == "")
            {
                return "";
            }
            var input = inputString.Trim().ToLower();
            var replacement = " ";
            if (paternList.Length > 0)
            {
                replacement = paternList[0];
            }
            var str = Regex.Replace(input, "^[0-9]+", string.Empty);
            str = Regex.Replace(str, "\x00e1|\x00e0|ạ|ả|\x00e3|ă|ắ|ằ|ặ|ẳ|ẵ|\x00e2|ấ|ầ|ậ|ẩ|ẫ", "a");
            str = Regex.Replace(str, "đ|Đ", "d");
            str = Regex.Replace(str, "\x00f3|\x00f2|ọ|ỏ|\x00f5|ơ|ớ|ờ|ợ|ở|ỡ|\x00f4|ố|ồ|ộ|ổ|ỗ", "o");
            str = Regex.Replace(str, "\x00fa|\x00f9|ụ|ủ|ũ|ư|ứ|ừ|ự|ử|ữ", "u");
            str = Regex.Replace(str, "\x00e9|\x00e8|ẹ|ẻ|ẽ|\x00ea|ế|ề|ệ|ể|ễ", "e");
            str = Regex.Replace(str, "\x00ed|\x00ec|ị|ỉ|ĩ", "i");
            str = Regex.Replace(str, "\x00fd|ỳ|ỵ|ỷ|ỹ", "y");
            str = Regex.Replace(str, "\"|'|_+|\\.+", string.Empty);

            str = Regex.Replace(str, @"[^\w\-]", " ");
            str = Regex.Replace(str, @"-$|-+|\s+", replacement);
            return str;
        }

        public static string QuoteString(string inputString)
        {
            var str = inputString.Trim();
            if (str != "")
            {
                str = str.Replace("'", "''");
            }
            return str;
        }

        public static string RemoveStrHtmlTags(string inputString)
        {
            var input = inputString.Trim();
            if (input != "")
            {
                input = Regex.Replace(input, @"<(.|\n)*?>", string.Empty);
            }
            return input;
        }

        public static string ReplaceSpecialCharater(string inputString)
        {
            inputString = inputString.Trim();
            inputString = inputString.Replace(@"\", @"\\");
            inputString = inputString.Replace("\"", "&quot;");
            inputString = inputString.Replace("“", "&ldquo;");
            inputString = inputString.Replace("”", "&rdquo;");
            inputString = inputString.Replace("‘", "&lsquo;");
            inputString = inputString.Replace("’", "&rsquo;");
            inputString = inputString.Replace("'", "&#39;");
            return inputString;
        }

        public static string WrapString(string inputString, int length)
        {
            var str = string.Empty;
            var startIndex = 0;
            for (var i = (int)Math.Ceiling(inputString.Length / ((double)length)); (startIndex < inputString.Length) && (i > 1); i--)
            {
                str = str + inputString.Substring(startIndex, length) + ' ';
                startIndex += length;
            }
            return (str + inputString.Substring(startIndex));
        }

        public enum Browser { MozilaFirefox = 1, InternetExplorer = 2, AppleSafari = 3, NetScapeOpera = 4, Other = 5 }

        public static bool DetectBrowser(Browser browser, string browserType)
        {
            int result;
            switch (browserType.ToLower())
            {
                case "ie":
                    result = (int)Browser.InternetExplorer;
                    break;
                case "firefox":
                    result = (int)Browser.MozilaFirefox;
                    break;
                case "safari":
                    result = (int)Browser.AppleSafari;
                    break;
                default:
                    result = (int)Browser.Other;
                    break;
            }
            return (int)browser == result;
        }

        public static string CreateMD5Checksum(string data)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checksumBytes = md5.ComputeHash(Encoding.Unicode.GetBytes(data));
            return BitConverter.ToString(checksumBytes).Replace("-", string.Empty);
        }
        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }
        public static string GenerateRandomString(int length)
        {
            //Initiate objects & vars    
            var random = new Random();
            var randomString = "";

            //Loop ‘length’ times to generate a random number or character
            for (var i = 0; i < length; i++)
            {
                var randNumber = random.Next(1, 3) == 1 ? random.Next(97, 123) : random.Next(48, 58);

                //append random char or digit to random string
                randomString = randomString + (char)randNumber;
            }
            //return the random string
            return randomString;
        }

        public static string GetMACAddress()
        {
            var nics = NetworkInterface.GetAllNetworkInterfaces();
            var sMacAddress = string.Empty;
            foreach (var adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    var properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

        /// <summary>
        /// Compares two instances of System.DateTime and returns an integer that indicates
        /// where the dateFrom earlier or same as or later the dateTo.<br />
        /// <example>
        /// dateFrom = new DateTime(2009, 8, 1, 0, 0, 0);
        /// dateTo = new DateTime(2009, 8, 1, 12, 0, 0);
        /// result = 1 (dateFrom is earlier than dateTo)
        /// </example> 
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns>integer</returns>
        public static int CompareDiffirenceDate(DateTime dateFrom, DateTime dateTo)
        {
            var date1 = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, dateFrom.Hour, dateFrom.Minute, 0);
            var date2 = new DateTime(dateTo.Year, dateTo.Month, dateTo.Day, dateTo.Hour, dateTo.Minute, 0);
            return DateTime.Compare(date1, date2);
        }

        public static double DateDiff(DateTime dateFrom, DateTime dateTo, string instant)
        {
            var diff = dateTo - dateFrom;
            double result = 0;
            switch (instant.ToLower())
            {
                case "d":
                    result = diff.TotalDays;
                    break;
                case "h":
                    result = diff.TotalHours;
                    break;
                case "m":
                    result = diff.TotalMinutes;
                    break;
                case "s":
                    result = diff.TotalSeconds;
                    break;
            }
            return result;
        }

        public static int CountWords(string stringInput)
        {
            if (string.IsNullOrEmpty(stringInput)) return 0;
            // Replaces all HTML tags
            stringInput = RemoveStrHtmlTags(stringInput);
            // Counts all words
            var collection = Regex.Matches(stringInput, @"[\S]+");
            // Returns number words.
            return collection.Count;
        }

        public static long SetPublishedDate(DateTime dateTime)
        {
            const string formatDate = "yyyyMMddHHmmssFFF";
            var dt = dateTime;
            if (dt <= DateTime.MinValue)
            {
                dt = DateTime.Now;
            }

            var dateToString = dt.ToString(formatDate);
            while (dateToString.Length < formatDate.Length)
            {
                dateToString += "0";
            }
            return long.Parse(dateToString);
        }

        public static long SetPublishedDate()
        {
            const string format = "yyyyMMddHHmmssFFF";
            var stringNewsId = DateTime.Now.ToString(format);
            while (stringNewsId.Length < format.Length)
            {
                stringNewsId += "0";
            }
            return long.Parse(stringNewsId);
        }

        /// <summary>
        /// compress script content
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string StripWhitespace(string content)
        {
            var lines = content.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var emptyLines = new StringBuilder();
            foreach (var s in lines.Select(line => line.Trim()).Where(s => s.Length > 0 && !s.StartsWith("//")))
            {
                emptyLines.AppendLine(s.Trim());
            }
            content = emptyLines.ToString();

            // remove C styles comments
            content = Regex.Replace(content, "/\\*.*?\\*/", String.Empty, RegexOptions.Compiled | RegexOptions.Singleline);
            // remove line comments
            //content = Regex.Replace(content, "//.*\r\n", String.Empty, RegexOptions.Compiled | RegexOptions.Singleline);
            var reg = new Regex("//([^/]+)//([^/]+)[\r\t\n]+", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            const string http = "http:";
            content = reg.Replace(content, delegate (System.Text.RegularExpressions.Match m)
            {
                var length = m.Groups[1].Value.Length;
                if (length > http.Length)
                {
                    var h = m.Groups[1].Value.Substring(length - http.Length);
                    return h.Equals(http) ? m.Groups[0].Value : m.Groups[1].Value;
                }
                return m.Groups[1].Value;
            });
            //// trim left
            content = Regex.Replace(content, "^\\s*", String.Empty, RegexOptions.Compiled | RegexOptions.Multiline);
            //// trim right
            content = Regex.Replace(content, "\\s*[\\r\\n]", "\r\n", RegexOptions.Compiled | RegexOptions.ECMAScript);
            // remove whitespace beside of left curly braced
            content = Regex.Replace(content, "\\s*{\\s*", "{", RegexOptions.Compiled | RegexOptions.ECMAScript);
            // remove whitespace beside of coma
            content = Regex.Replace(content, "\\s*,\\s*", ",", RegexOptions.Compiled | RegexOptions.ECMAScript);
            // remove whitespace beside of semicolon
            content = Regex.Replace(content, "\\s*;\\s*", ";", RegexOptions.Compiled | RegexOptions.ECMAScript);
            // remove newline after keywords
            content = Regex.Replace(content, "\\r\\n(?<=\\b(abstract|boolean|break|byte|case|catch|char|class|const|continue|default|delete|do|double|else|extends|false|final|finally|float|for|function|goto|if|implements|import|in|instanceof|int|interface|long|native|new|null|package|private|protected|public|return|short|static|super|switch|synchronized|this|throw|throws|transient|true|try|typeof|var|void|while|with)\\r\\n)", " ", RegexOptions.Compiled | RegexOptions.ECMAScript);
            content = Regex.Replace(content, @"[\n\r]+\s*", string.Empty); // space
            return content;
        }

        public static string SubWordInString(string inputString, int maxWord)
        {
            if (string.IsNullOrEmpty(inputString)) return inputString;
            inputString = Regex.Replace(inputString, "\\s+", " ");
            string[] words = Regex.Split(inputString, " ");
            if (words.Length <= maxWord) return inputString;
            else
            {
                inputString = string.Empty;
                for (int i = 0; i < maxWord; i++)
                {
                    inputString += words[i] + " ";
                }
                return inputString.Trim() + "...";
            }
        }
        private static readonly Dictionary<string, string> DicChar = new Dictionary<string, string>();
        private static string ConvertWindown1525ToUnicode(System.Text.RegularExpressions.Match match)
        {
            var c = match.ToString();
            return c.Replace(c, DicChar[c]);
        }
        public static string ConvertWindown1525ToUnicode(string txt)
        {
            if (!DicChar.Any())
            {
                var char1252 =
                    "à|á|ả|ã|ạ|ầ|ấ|ẩ|ẫ|ậ|ằ|ắ|ẳ|ẵ|ặ|è|é|ẻ|ẽ|ẹ|ề|ế|ể|ễ|ệ|ì|í|ỉ|ĩ|ị|ò|ó|ỏ|õ|ọ|ồ|ố|ổ|ỗ|ộ|ờ|ớ|ở|ỡ|ợ|ù|ú|ủ|ũ|ụ|ừ|ứ|ử|ữ|ự|ỳ|ý|ỷ|ỹ|ỵ|À|Á|Ả|Ã|Ạ|Ầ|Ấ|Ẩ|Ẫ|Ậ|Ằ|Ắ|Ẳ|Ẵ|Ặ|È|É|Ẻ|Ẽ|Ẹ|Ề|Ế|Ể|Ễ|Ệ|Ì|Í|Ỉ|Ĩ|Ị|Ò|Ó|Ỏ|Õ|Ọ|Ồ|Ố|Ổ|Ỗ|Ộ|Ờ|Ớ|Ở|Ỡ|Ợ|Ù|Ú|Ủ|Ũ|Ụ|Ừ|Ứ|Ử|Ữ|Ự|Ỳ|Ý|Ỷ|Ỹ|Ỵ"
                        .Split('|');
                var charutf8 =
                    "à|á|ả|ã|ạ|ầ|ấ|ẩ|ẫ|ậ|ằ|ắ|ẳ|ẵ|ặ|è|é|ẻ|ẽ|ẹ|ề|ế|ể|ễ|ệ|ì|í|ỉ|ĩ|ị|ò|ó|ỏ|õ|ọ|ồ|ố|ổ|ỗ|ộ|ờ|ớ|ở|ỡ|ợ|ù|ú|ủ|ũ|ụ|ừ|ứ|ử|ữ|ự|ỳ|ý|ỷ|ỹ|ỵ|À|Á|Ả|Ã|Ạ|Ầ|Ấ|Ẩ|Ẫ|Ậ|Ằ|Ắ|Ẳ|Ẵ|Ặ|È|É|Ẻ|Ẽ|Ẹ|Ề|Ế|Ể|Ễ|Ệ|Ì|Í|Ỉ|Ĩ|Ị|Ò|Ó|Ỏ|Õ|Ọ|Ồ|Ố|Ổ|Ỗ|Ộ|Ờ|Ớ|Ở|Ỡ|Ợ|Ù|Ú|Ủ|Ũ|Ụ|Ừ|Ứ|Ử|Ữ|Ự|Ỳ|Ý|Ỷ|Ỹ|Ỵ"
                        .Split('|');
                for (var i = 0; i < char1252.Count(); i++)
                {
                    if (!DicChar.ContainsKey(char1252[i]))
                        DicChar.Add(char1252[i], charutf8[i]);
                }
            }
            return Regex.Replace(txt, @"(?:à|á|ả|ã|ạ|ầ|ấ|ẩ|ẫ|ậ|ằ|ắ|ẳ|ẵ|ặ|è|é|ẻ|ẽ|ẹ|ề|ế|ể|ễ|ệ|ì|í|ỉ|ĩ|ị|ò|ó|ỏ|õ|ọ|ồ|ố|ổ|ỗ|ộ|ờ|ớ|ở|ỡ|ợ|ù|ú|ủ|ũ|ụ|ừ|ứ|ử|ữ|ự|ỳ|ý|ỷ|ỹ|ỵ|À|Á|Ả|Ã|Ạ|Ầ|Ấ|Ẩ|Ẫ|Ậ|Ằ|Ắ|Ẳ|Ẵ|Ặ|È|É|Ẻ|Ẽ|Ẹ|Ề|Ế|Ể|Ễ|Ệ|Ì|Í|Ỉ|Ĩ|Ị|Ò|Ó|Ỏ|Õ|Ọ|Ồ|Ố|Ổ|Ỗ|Ộ|Ờ|Ớ|Ở|Ỡ|Ợ|Ù|Ú|Ủ|Ũ|Ụ|Ừ|Ứ|Ử|Ữ|Ự|Ỳ|Ý|Ỷ|Ỹ|Ỵ)", ConvertWindown1525ToUnicode);
        }
        #endregion

    }
}
