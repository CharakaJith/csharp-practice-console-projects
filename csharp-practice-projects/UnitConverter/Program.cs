using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Converter converter = new Converter();

            bool runAgain = true;
            while (runAgain)
            {
                ConverterOperations operations = SelectOperation();

                switch (operations)
                {
                    case ConverterOperations.Length:
                        converter.ConvertLength();

                        break;
                    case ConverterOperations.Weight:
                        converter.ConvertWeight();

                        break;
                    case ConverterOperations.Temp:
                        converter.ConvertTemp();

                        break;
                    case ConverterOperations.Exit:
                        runAgain = false;

                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("------- Thank you for using our converter -------");
        }

        private static ConverterOperations SelectOperation()
        {
            while (true)
            {
                Console.WriteLine("\n------- Unit Converter -------");
                Console.WriteLine("1 - Length (m <-> ft)");
                Console.WriteLine("2 - Weight (kg <-> lbs)");
                Console.WriteLine("3 - Temperature (°C <-> °F)");
                Console.WriteLine("x - Exit");

                Console.Write("\nselect operation: ");
                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        return ConverterOperations.Length;
                    case "2":
                        return ConverterOperations.Weight;
                    case "3":
                        return ConverterOperations.Temp;
                    case "X":
                    case "x":
                        return ConverterOperations.Exit;
                    default:
                        Console.WriteLine("Please enter a valid operation!");
                        break;
                }
            }
        }
    }
}
