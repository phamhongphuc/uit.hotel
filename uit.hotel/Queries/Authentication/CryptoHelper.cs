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

        public static string EncryptSHA256(this string content, string key)
        {
            using (var crypt = new HMACSHA256(key.ToBytes()))
                return crypt.ComputeHash(content.ToBytes()).ToHash();
        }

        public static string ToHash(this byte[] bytes)
            => BitConverter.ToString(bytes).Replace("-", "").ToLower();

        public static byte[] ToBytes(this string str)
            => Encoding.UTF8.GetBytes(str);

        public static string ToAlphabet(this long number)
        {
            var baseChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            // 32 is the worst cast buffer size for base 2 and int.MaxValue
            int i = 32;
            char[] buffer = new char[i];
            int targetBase = baseChars.Length;

            do
            {
                buffer[--i] = baseChars[number % targetBase];
                number = number / targetBase;
            }
            while (number > 0);

            char[] result = new char[32 - i];
            Array.Copy(buffer, i, result, 0, 32 - i);

            return new String(result);
        }
    }
}
