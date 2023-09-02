using System.Security.Cryptography;
using System.Text;
using System;
using System.Text.RegularExpressions;

namespace HelpDesk.Common
{
    public class Methods
    {
        public static string GetHashMD5(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        public static bool isValidEmail(string email)
        {
            var pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";

            return Regex.Match(email, pattern, RegexOptions.IgnoreCase).Success;
        }
    }
}
