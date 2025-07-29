using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    internal class Converter
    {
        public void ConvertLength()
        {
            Console.WriteLine("\n1 - Meters to Feet");
            Console.WriteLine("2 - Feet to Meters");
            Console.Write("your choice: ");
            string choice = Console.ReadLine();

            if (!choice.Equals("1") && !choice.Equals("2"))
            {
                Console.WriteLine("Invalid choice!");
                return;
            }

            Console.Write("\nvalue: ");
            string val = Console.ReadLine();

            if (!double.TryParse(val, out double value))
            {
                Console.WriteLine("Invalid value!");
                return;
            }

            if (choice.Equals("1"))
            {
                Console.WriteLine($"{value} m = {value * 3.28084:F2} ft");
                return;
            }
            else if (choice.Equals("2"))
            {
                Console.WriteLine($"{value} ft = {value / 3.28084:F2} m");
                return;
            }
        }

        public void ConvertWeight()
        {
            Console.WriteLine("\n1 - Kilograms to Pounds");
            Console.WriteLine("2 - Pounds to Kilograms");
            Console.Write("your choice: ");
            string choice = Console.ReadLine();

            if (!choice.Equals("1") && !choice.Equals("2"))
            {
                Console.WriteLine("Invalid choice!");
                return;
            }

            Console.Write("\nvalue: ");
            string val = Console.ReadLine();

            if (!double.TryParse(val, out double value))
            {
                Console.WriteLine("Invalid value!");
                return;
            }

            if (choice.Equals("1"))
            {
                Console.WriteLine($"{value} kg = {value * 2.20462:F2} lbs");
                return;
            }
            else if (choice.Equals("2"))
            {
                Console.WriteLine($"{value} lbs = {value / 2.20462:F2} kg");
                return;
            }
        }

        public void ConvertTemp()
        {
            Console.WriteLine("\n1 - Celsius to Fahrenheit");
            Console.WriteLine("2 - Fahrenheit to Celsius");
            Console.Write("your choice: ");
            string choice = Console.ReadLine();

            if (!choice.Equals("1") && !choice.Equals("2"))
            {
                Console.WriteLine("Invalid choice!");
                return;
            }

            Console.Write("\nvalue: ");
            string val = Console.ReadLine();

            if (!double.TryParse(val, out double value))
            {
                Console.WriteLine("Invalid value!");
                return;
            }

            if (choice.Equals("1"))
            {
                Console.WriteLine($"{value} °C = {(value * 9 / 5) + 32:F2} °F");
                return;
            }
            else if (choice.Equals("2"))
            {
                Console.WriteLine($"{value} °F = {(value - 32) * 5 / 9:F2} °C");
                return;
            }
        }
    }
}
