using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryptionTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EncryptionService service = new EncryptionService();

            bool runAgain = true;
            while (runAgain)
            {
                EncryptionOperations operations = SelectOperation();

                switch (operations)
                {
                    case EncryptionOperations.Encryption:
                        service.EncryptFile();
                        break;
                    case EncryptionOperations.Decryption:
                        service.DecryptFile();
                        break;
                    case EncryptionOperations.Exit:
                        runAgain = false;

                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("------- File encryption tool closed -------");
        }

        private static EncryptionOperations SelectOperation()
        {
            while (true)
            {
                Console.WriteLine("\n------- File Encryption Tool -------");
                Console.WriteLine("1 - Encrypt a file");
                Console.WriteLine("2 - Decrypt a file");
                Console.WriteLine("x - Exit");
                
                Console.Write("\noperation: ");
                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        return EncryptionOperations.Encryption;
                    case "2":
                        return EncryptionOperations.Decryption;
                    case "x":
                    case "X":
                        return EncryptionOperations.Exit;
                    default:
                        Console.WriteLine("Select a valid operation!");
                        break;
                }
            }
        }
    }
}
