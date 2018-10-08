using System;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;

            bool sound = false;
            string[] s = { "sound" };

            if (args.Length > 0)
            {
                if (args[0].Equals(s[0]))
                {
                    sound = true;
                }
                else
                {
                    sound = false;
                }
            }
            game.run(sound);
            Console.ReadLine();
        }
    }
}
