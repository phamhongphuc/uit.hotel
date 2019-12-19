using System;
using System.Security.Cryptography;
using System.Text;

namespace uit.hotel.Queries.Authentication
{
    public static class CryptoHelper
    {
        public static string EncryptPassword(string password)
        {
            using (var crypt = new SHA256Managed())
                return crypt.ComputeHash(Encoding.UTF8.GetBytes(password)).ToHash();
        }

        public static string ToHash(this byte[] bytes)
            => BitConverter.ToString(bytes).Replace("-", "").ToLower();

        public static byte[] ToBytes(this string str)
            => Encoding.UTF8.GetBytes(str);
    }
}
