using System;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            bool sound;

            if(args.Equals("sound"))
            {
                sound = true;
            }
            else
            {
                sound = false;
            }
            game.run(sound);
            Console.ReadLine();
        }
    }
}
