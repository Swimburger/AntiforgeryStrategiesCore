using System;
using System.Security.Cryptography;

namespace AntiForgeryStrategiesCore
{
    public class TokenGenerator
    {
        public static string GetRandomToken()
        {
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                byte[] tokenData = new byte[32];
                rng.GetBytes(tokenData);

                return Convert.ToBase64String(tokenData);
            }
        }
    }
}
