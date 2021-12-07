using System;

using System.Security.Cryptography;
using System.Text;

namespace Alquerque.User.Authorization
{
    public static class PasswordHash
    {
        private static string GetHash(string input)
        {
            if (input == null)
                return null;
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(
                Encoding.UTF8.GetBytes(input)
                );
            return Convert.ToBase64String(hash);
        }
        public static string CryptMessage(string password,string login)
        {
            return GetHash(login + GetHash(password));
        }
    }
}
