using System;
using System.Text;
using System.Security.Cryptography;

namespace Shifr
{
    class Program
    {
        static string hmac1(char[] secretKey, char[] signatureString)
        {
            var enc = Encoding.ASCII;
            HMACSHA1 hmac = new HMACSHA1(enc.GetBytes(secretKey));
            hmac.Initialize();
            byte[] buffer = enc.GetBytes(signatureString);
            return BitConverter.ToString(hmac.ComputeHash(buffer)).Replace("-", "").ToLower();
        }
        static void Main(string[] args)
        {
            char[] secretKey = { '1', '5', '8' };
            char[] signatureString = { '1', '1', '5' };
            string pasHash = hmac1(secretKey, signatureString);
            Console.WriteLine(pasHash);
            Console.ReadKey();
        }
    }
}
