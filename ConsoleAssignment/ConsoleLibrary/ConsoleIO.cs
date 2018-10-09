using System;

namespace ConsoleLibrary
{
    public class ConsoleIO
    {
        public static int ReadInterger(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            int result;
            bool valid = false;

            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                bool validInput = int.TryParse(input, out result);
                if (validInput && (result >= min && result <= max))
                {
                    valid = true;
                }
            } while (!valid);

            return result;
        }

        public static bool TryParse<T>(string text, out T value)
        {
            value = default(T);

            try
            {
                value = (T)Convert.ChangeType(text, typeof(T));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T ReadValue<T>(string message, T min, T max)
        {
            T result;
            bool valid = false;

            do
            {

                Console.Write(message);
                string input = Console.ReadLine();

                bool validInput = TryParse<T>(input, out result);
                if (validInput)
                {
                    switch (Type.GetTypeCode(typeof(T)))
                    {
                        case TypeCode.Int32:
                            valid = IntRange(Convert.ToInt32(result), Convert.ToInt32(min), Convert.ToInt32(max));
                            break;
                        default:
                            throw new Exception("type not supported");
                    }
                }


            } while (!valid);

            return result;
        }

        public static bool IntRange(int value, int min, int max) //need to do for other values
        {
            return (value >= min && value <= max);
        }
        public static void StupidFunction()
        {
            Console.WriteLine("Hello");
        }
    }
}

