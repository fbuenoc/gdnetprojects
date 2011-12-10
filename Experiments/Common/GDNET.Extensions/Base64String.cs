using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDNET.Extensions
{
    public sealed class Base64String
    {
        public static string Encrypt(string source)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(source));
        }

        public static string Decrypt(string base64)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }
    }
}
