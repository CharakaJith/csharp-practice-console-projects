using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryptionTool
{
    internal class EncryptionService
    {
        private const string SystemPassword = "admin123";
        private const int CaesarKey = 5;        

        public void EncryptFile()
        {
            var filePath = GetFileInput();
            if (filePath == null)
            {
                return;
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return;
            }

            string content = File.ReadAllText(filePath);
            string encrypted = CaesarEncrypt(content);
            File.WriteAllText(filePath, encrypted);

            Console.WriteLine("File encrypted successfully.");
        }

        public void DecryptFile()
        {
            var filePath = GetFileInput();
            if (filePath == null)
            {
                return;
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return;
            }

            string content = File.ReadAllText(filePath);
            string decrypted = CaesarDecrypt(content);
            File.WriteAllText(filePath, decrypted);

            Console.WriteLine("File decrypted successfully.");
        }

        private string GetFileInput()
        {
            Console.Write("\nfile path: ");
            string path = Console.ReadLine();

            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("Path cannot be empty!");
                return null;
            }

            Console.Write("password: ");
            string pwd = Console.ReadLine();

            if (string.IsNullOrEmpty(pwd))
            {
                Console.WriteLine("Password cannot be empty!");
                return null;
            }

            if (!Authenticate(pwd))
            {
                Console.WriteLine("Access denied!");
                return null;
            }

            return path;
        }

        private bool Authenticate(string password)
        {
            return password == SystemPassword;
        }

        private string CaesarEncrypt(string text)
        {
            var result = new StringBuilder();
            foreach (char ch in text)
            {
                result.Append((char)(ch + CaesarKey));
            }
            return result.ToString();
        }

        private string CaesarDecrypt(string text)
        {
            var result = new StringBuilder();
            foreach (char ch in text)
            {
                result.Append((char)(ch - CaesarKey));
            }
            return result.ToString();
        }
    }
}
