using System;
using System.Security.Cryptography;
using System.Text;

namespace Task_3
{
    static class Key
    {
        internal static string HMACKey { get; set; }
        internal static string HMAC { get; set; }

        internal static void CreateKey()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] buff = new byte[32];
                rng.GetBytes(buff);
                HMACKey = Convert.ToBase64String(buff);
            }
        }

        internal static void CreateHMAC(string computerMove)
        {
            using (var shaAlgorithm = new HMACSHA256(Encoding.UTF8.GetBytes(HMACKey)))
            {
                var signatureBytes = Encoding.UTF8.GetBytes(computerMove);
                var signatureHashBytes = shaAlgorithm.ComputeHash(signatureBytes);
                HMAC = string.Concat(Array.ConvertAll(signatureHashBytes, b => b.ToString("X2"))).ToLower();
            }
        }
    }
}
