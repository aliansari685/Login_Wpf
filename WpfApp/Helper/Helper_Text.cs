using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WpfApp
{
    public static class Helper_Text
    {
        public static string Hash(string data, string key)
        {
            string temp;
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                temp = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
            return temp;
        }
        public static bool IsPersianText(string text) => text.Any(c => c >= 0x0600 && c <= 0x06FF);
        public static bool IsEnglishText(string text) => text.All(x => char.IsLetter(x));
        //   public static bool IsText(string text) => IsPersianText(text) || IsEnglishText(text);

    }
}