using System;
using System.Text;
using System.Security.Cryptography;

namespace Shifr
{
    class Program
    {
        static string sha1(string input)
        {
            byte[] hash;
            using (var sha1 = new SHA1CryptoServiceProvider()) // System.Security.Cryptography.SHA1CryptoServiceProvider
                hash = sha1.ComputeHash(Encoding.Unicode.GetBytes(input));
            var sb = new StringBuilder();
            foreach (byte b in hash) sb.AppendFormat("{0:x2}", b);
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            string pasHash = sha1("Apply Hash sha1");
            Console.WriteLine(pasHash);
            Console.ReadKey();
        }
    }
}
