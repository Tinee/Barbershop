using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLogicLayout.Functions.DataHandlers
{
    public static class PasswordHandler
    {
        public static string CreateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[7];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public static string GenerateHash(this string password, string salt)
        {
            var bytes = Encoding.UTF8.GetBytes(password + salt);
            var sha256Hashstring = new SHA256Managed();
            var hash = sha256Hashstring.ComputeHash(bytes);
            return BitConverter.ToString(hash);
        } 
    }
}