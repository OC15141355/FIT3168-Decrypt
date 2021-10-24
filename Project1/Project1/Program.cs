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
            string key = "05e171a6107fc7b8";
            string result = Decrypt("FEQQVEVIXBRCVVsDAENCVlFYAB1UUBNSbl5CCwFSEBRTQxMdR1gPGlRIRw8RTkJeQloIEVRDBFJYRFQHEVMRAxIOQVdHDAdZQVVZTkFSGkhcWgxFGUIQWhMcF0QUFUsDVkIXWENUSRJXQBtCEkIHSkkcXldUXQ5FVBgTABMeWXhDTBZFUlxJFFxJRBcPF09NEFYQQkNeDFNDEBoWGU0bbEZ7AFcYRARkRgZYFUNUF0tEWghURUJBChFVTxYPWAtMHkYUXRdNQVlBVVkVEFtCXV5WRRxVUBJTBwQXSwJSEQkCDUUcR1MKUlcCF0sKQwdKEARVAQcRTF0RX0Y_EWIgCnwEDH0GcA9MCBIeXQ", key);

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}