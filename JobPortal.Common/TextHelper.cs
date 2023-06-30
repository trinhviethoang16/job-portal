using System.Text;
using System.Text.RegularExpressions;

namespace JobPortal.Common
{
    public class TextHelper
    {
        public static string ToUnsignString(string input)
        {
            input = input.Trim();
            input = input.Replace("+", "p");
            input = input.Replace("#", "sharp");
            input = input.Replace(".", "dot");
            for (int i = 0x20; i < 0x30; i++)
            {
                input = input.Replace(((char)i).ToString(), " ");
            }
            input = input.Replace(" ", "-");
            input = input.Replace(",", "-");
            input = input.Replace(";", "-");
            input = input.Replace(":", "-");
            input = input.Replace("  ", "-");
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string str = input.Normalize(NormalizationForm.FormD);
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            while (str2.Contains("--"))
            {
                str2 = str2.Replace("--", "-").ToLower();
            }
            return str2;
        }
        public static String GetFullTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("mmssffff");
        }

    }
}