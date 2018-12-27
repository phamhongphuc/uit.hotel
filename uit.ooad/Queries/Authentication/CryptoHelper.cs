using System.Security.Cryptography;
using System.Text;

namespace uit.ooad.Queries.Authentication
{
    public static class CryptoHelper
    {
        public static string Encrypt(string password)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (var theByte in crypto) hash.Append(theByte.ToString("x2"));
            return hash.ToString();
        }
    }
}
