using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public class Game
    {
        private int highScore = int.MaxValue;

        public void Start()
        {
            bool playAgain = true;
            while(playAgain)
            {
                Difficulty dificulty = GetDificulty();

                Round round = new Round(dificulty);
                round.Play();

                if (round.Attempts < this.highScore)
                {
                    this.highScore = round.Attempts;
                    Console.WriteLine($"\nNew highscore: {this.highScore} attempts");
                }
                else
                {
                    Console.WriteLine($"\nYour score: {round.Attempts}");
                    Console.WriteLine($"Current highscore: {this.highScore} attempts");                    
                }

                Console.Write("\nplay again (y/n): ");
                string confrim = Console.ReadLine().Trim().ToLower();

                playAgain = confrim == "y";

                if (playAgain)
                {
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("------- Thank you for playing -------");
                }
               
            }
        }

        private Difficulty GetDificulty()
        {
            Console.WriteLine("------- Number Guessing Game -------");
            Console.WriteLine("\nSelect dificulty: ");
            Console.WriteLine($"1 - {Difficulty.Easy} (1 to 10)");
            Console.WriteLine($"2 - {Difficulty.Medium} (1 to 50)");
            Console.WriteLine($"3 - {Difficulty.Hard} (1 to 100)");

            while(true)
            {
                Console.Write("\nyour choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        return Difficulty.Easy;
                    case "2":
                        return Difficulty.Medium;
                    case "3":
                        return Difficulty.Hard;
                    default:
                        Console.WriteLine("Please enter a valid choice!");
                        break;
                }
            }
        }
    }
}
