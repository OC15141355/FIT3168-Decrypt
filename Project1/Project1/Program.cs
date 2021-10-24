using System;
using System.Text;

namespace Project1
{
    class Program
    {
        static string Decrypt(string value, string key)
        {
            string cleaned = value.Replace('-', '+').Replace('_', '/');

            int padChars = (4 - cleaned.Length % 4) % 4;
            string padded = cleaned.PadRight(cleaned.Length + padChars, '=');

            byte[] b = Convert.FromBase64String(padded);
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = (byte)(key[i % key.Length] ^ b[i]);
            }
            return Encoding.ASCII.GetString(b);
        }

        static void Main(string[] args)
        {
            // keys go here
            string key = ""; 
            string result = Decrypt("", key);

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
