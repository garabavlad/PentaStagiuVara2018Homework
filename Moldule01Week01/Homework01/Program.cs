using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
WWW.PENTALOG.COM
HOMEWORK
Homework
•
Create a “guess the number” game
•
You must generate a random number between 0 and 100 (the target number)
•
You ask the user to guess the number, by entering a number in the console
•
If the user guesses correctly, the game ends
•
If the user’s guess was smaller than the target number, tell the user that the number 
was too small
•
If the user’s guess was larger than the target number, tell the user that the number 
was too big
•
Allow the user to guess again until he 
guesses correctly
 */
namespace PentaHomework1
{
    class Program
    {
        static void Main(string[] args)
        {
            //generating target number
            Random rand = new Random();
            int targetNumber = rand.Next(0, 100);

            //asking user to enter a number
            int userInput;
            bool correctInput = false;
            Console.WriteLine("I thought about a number from 0 to 100. Guess it!");
            do
            {
                //getting user input
                Console.WriteLine("Your number:");
                string input = Console.ReadLine();
                userInput = int.Parse(input);
                //checking number
                if (userInput > targetNumber)
                {
                    Console.WriteLine("Your number is too big!");
                    continue;
                }
                if (userInput < targetNumber)
                {
                    Console.WriteLine("Your number is too small!");
                    continue;
                }
                //if number is not too big, neither too small, then it's target number, so we exit loop
                Console.WriteLine("You guessed the number!");
                Console.Read();
                correctInput = true;
            } while (!correctInput);
        }
    }
}