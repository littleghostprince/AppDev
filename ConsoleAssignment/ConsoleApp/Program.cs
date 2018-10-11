using System;
using ConsoleLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleIO.ReadValue<byte>("Enter age: ", 0, 110);
            ConsoleIO.ReadValue<short>("Enter area code: ", 0, 999);
            ConsoleIO.ReadValue<int>("Enter zip code: ", 0, 99999);
            ConsoleIO.ReadValue<long>("Enter a number: ", long.MinValue, long.MaxValue);
            ConsoleIO.ReadValue<float>("Enter amount in checking acct: ", float.MinValue, float.MaxValue);
            ConsoleIO.ReadValue<double>("Enter desired salary: ", 0, double.MaxValue);
            ConsoleIO.ReadValue<decimal>("Enter a number: ", decimal.MinValue, decimal.MaxValue);
            ConsoleIO.ReadValue<char>("Enter first Initial: ", 'A', 'Z');
            ConsoleIO.ReadBool("I am happy[true/false] : ");
            ConsoleIO.ReadString("Enter your last name: ");
            ConsoleIO.ReadMenu(new string[] { "Open", "Save", "Print", "Close" });

            Console.ReadLine();
        }
    }
}
