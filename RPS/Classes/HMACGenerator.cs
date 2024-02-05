using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Classes
{
    internal class HMACGenerator
    {
        public byte[] HMAC { get; private set; }
        public byte[] HMAC_KEY { get; private set; }
        private string secretKey;
        public HMACGenerator(int keySize=32)
        {
            HMAC = new byte[keySize];
            HMAC_KEY = GenerateKey(keySize);
            secretKey = HashEncode(HMAC_KEY);
        }
        public string GenerateHMAC(string message)
        {
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
            {
                HMAC = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                return BitConverter.ToString(HMAC).Replace("-", "");
            }
        }

        public string GetHMACKey()
        {
            return secretKey;
        }

        private static byte[] GenerateKey(int size)
        {
            byte[] secretkey = new Byte[32];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(secretkey);
            }
            return secretkey;
        }

        private static string HashEncode(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}
