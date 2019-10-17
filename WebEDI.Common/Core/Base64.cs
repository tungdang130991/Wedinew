using System;
using System.Text;

namespace WebEDI.Common.Core
{
    public class Base64
    {
        public static string Decode(string data)
        {
            string str2 = "";
            try
            {
                var decoder = new UTF8Encoding().GetDecoder();
                var bytes = Convert.FromBase64String(data);
                var chars = new char[decoder.GetCharCount(bytes, 0, bytes.Length)];
                decoder.GetChars(bytes, 0, bytes.Length, chars, 0);
                var str = new string(chars);
                str2 = str;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return str2;
        }

        public static string Encode(string data)
        {
            string str2 = "";
            try
            {
                str2 = Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return str2;
        }
    }
}
