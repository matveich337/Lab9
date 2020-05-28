using System;
using System.Text;
using System.Security.Cryptography;

namespace Shifr
{
    class Program
    {
        public static object MessageBox { get; private set; }
        static string Sha256(string input)
        {
            string rethash = "";
            try
            {
                SHA256 hash = SHA256.Create();
                UTF8Encoding encoder = new UTF8Encoding();
                byte[] combined = encoder.GetBytes("Hello World");
                hash.ComputeHash(combined);
                foreach (byte b in hash.Hash)
                {
                    rethash += b.ToString("X2");
                }
            }
            catch (Exception ex)
            {
                return "Error in HashCode : " + ex.Message;
            }
            return rethash;
        }
        static void Main(string[] args)
        {
            string pasHash = Sha256("Apply Hash sha1");
            Console.WriteLine(pasHash);
            Console.ReadKey();
        }
    }
}