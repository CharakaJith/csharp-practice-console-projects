using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public class Round
    {
        private int number;
        private int maxNumber;
        private int attempts;

        public int Attempts => attempts;

        public Round(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    this.maxNumber = 10;
                    break;
                case Difficulty.Medium:
                    this.maxNumber = 50;
                    break;
                case Difficulty.Hard:
                    this.maxNumber = 100;
                    break;
                default:
                    maxNumber = 10;
                    break;
            }

            this.number = new Random().Next(1, this.maxNumber + 1);
            this.attempts = 0;
        }

        public void Play()
        {
            int guess = 0;

            while(guess != this.number)
            {
                Console.Write("\nenter your guess: ");
                string input = Console.ReadLine();

                bool isValid = int.TryParse(input, out guess);

                if (!isValid || guess < 1 || guess > this.maxNumber)
                {
                    Console.WriteLine($"Please enter a valid number between 1 and {this.maxNumber}");
                    continue;
                }

                this.attempts++;

                if (guess < this.number)
                {
                    Console.WriteLine("Too low!");
                }
                else if (guess > this.number)
                {
                    Console.WriteLine("Too high!");
                }
                else
                {
                    Console.WriteLine($"The number is {this.number}! You guessed it in {this.attempts} attempts");
                }
            }
        }
    }
}
