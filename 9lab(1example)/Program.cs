using System;
using System.Text;
using System.Security.Cryptography;

namespace Shifr
{
    class Program
    {
        static string GetMd5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        static void Main(string[] args)
        {
            string pasHash = GetMd5Hash("HashHashHashHashHash"); // Hash
            Console.WriteLine(pasHash);
            Console.ReadKey();
        }
    }
}