using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame
{
    class game
    {
        public void logic(bool sound)
        {
            int maxNumber = validInt("Enter Max Number: ");

            Random rand = new Random();
            int randNum = rand.Next(maxNumber);

            guess(randNum,sound);  //Guess the number , checks if the user inputs a number 

        }

        public int validInt(string prompt)
        {
            bool valid = false;
            int Number;

            do
            {
                string input;
                Console.Write(prompt);
                input = Console.ReadLine();

                if (Int32.TryParse(input, out Number))
                {
                    Number = Convert.ToInt32(input);
                    valid = false;
                }
                else
                {
                    valid = true;
                    Console.WriteLine("invalid Entry...Please try again...\n");
                }
            } while (valid);

            return Number;
        }
        public void guess(int randNum, bool sound)
        {
           
            bool end = true;
            int tries = 0;

            Console.WriteLine("Time to Guess the number!\n");

            while (end)
            {
                int guess = validInt("Your Guess: ");

                if (guess == randNum)
                {
                    string answer;

                    if (sound) Console.Beep(5000, 1000);

                    Console.WriteLine("Correct! It took you {0} tries!", tries);
                    Console.WriteLine("would you like to play again? (yes/no)");

                    answer = Console.ReadLine();
                    answer = answer.ToLower();
                    if (answer.Equals("yes"))
                    {
                        Console.WriteLine("Great! Next game starting!");
                        end = false;
                        logic(sound);
                    }
                    else
                    {
                        end = false;
                    }
                }
                else if (guess != randNum && tries <= 4)
                {
                    if (sound) Console.Beep(1000, 1000);
                    tries++;
                    Console.WriteLine("Wrong! Try again! you have: {0} tries left...", 5 - tries);
                    if(guess < randNum)
                    {
                        Console.WriteLine("Hint: Your answer was too low.");
                    }
                    else
                    {
                        Console.WriteLine("Hint: your answer was too high.");
                    }
                }
                
                if(tries > 4)
                {
                    Console.WriteLine("Oh no! you do not have any more tires left...\n GAME OVER ): ");
                    string answer;
                    Console.WriteLine("would you like to play again? (yes/no)");

                    answer = Console.ReadLine();
                    answer = answer.ToLower();
                    if (answer.Equals("yes"))
                    {
                        Console.WriteLine("Great! Next game starting!");
                        end = false;
                        logic(sound);
                    }
                    else
                    {
                        end = false;
                    }
                }
            }
        }
        public static void run(bool sound = false)
        {
            game G = new game();
            G.logic(sound);
        }
    }
}
