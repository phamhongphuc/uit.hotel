using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace uit.ooad.Queries.Authentication
{
    public static class CryptoHelper
    {
        private const string EncryptionKey = "PassOOAD";

        public static string Encrypt(string password)
        {
            var clearBytes = Encoding.Unicode.GetBytes(password);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[]
                {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }

                    password = Convert.ToBase64String(ms.ToArray());
                }
            }

            return password;
        }

        public static string Decrypt(string ciphertext)
        {
            ciphertext = ciphertext.Replace(" ", "+");
            var cipherBytes = Convert.FromBase64String(ciphertext);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[]
                {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }

                    ciphertext = Encoding.Unicode.GetString(ms.ToArray());
                }
            }

            return ciphertext;
        }
    }
}
