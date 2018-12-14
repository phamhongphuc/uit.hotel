using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace uit.ooad.Queries.Authentication
{
    public static class CryptoHelper
    {
        public static string Encrypt(string password)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
