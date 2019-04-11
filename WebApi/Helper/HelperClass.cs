using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Helper
{
    public static class HelperClass
    {
        public static string Base64ToString(this string Base64)
        {
            byte[] decodedBytes = Convert.FromBase64String(Base64);
            var decoded = System.Text.Encoding.UTF8.GetString(decodedBytes);
            return decoded;
        }

        public static string StringToBase64(this string text)
        {
            byte[] encodedBytes = System.Text.Encoding.UTF8.GetBytes(text);
            string encodedTxt = Convert.ToBase64String(encodedBytes);
            return encodedTxt;
        }
    }
}
