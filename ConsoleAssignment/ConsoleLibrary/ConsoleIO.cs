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
                        case TypeCode.Char:
                            valid = CharRange(Convert.ToChar(result), Convert.ToChar(min), Convert.ToChar(max));
                            break;
                        case TypeCode.Byte:
                            valid = ByteRange(Convert.ToByte(result), Convert.ToByte(min), Convert.ToByte(max));
                            break;
                        case TypeCode.Int16:
                            valid = ShortRange(Convert.ToInt16(result), Convert.ToInt16(min), Convert.ToInt16(max));
                             break;
                        case TypeCode.Int64:
                            valid = LongRange(Convert.ToInt64(result), Convert.ToInt64(min), Convert.ToInt64(max));
                            break;
                        case TypeCode.Single:
                            valid = FloatRange(Convert.ToSingle(result), Convert.ToSingle(min), Convert.ToSingle(max));
                            break;
                        case TypeCode.Double:
                            valid = DoubleRange(Convert.ToSingle(result), Convert.ToSingle(min), Convert.ToSingle(max));
                            break;
                        case TypeCode.Decimal:
                            valid = DecimalRange(Convert.ToDecimal(result), Convert.ToDecimal(min), Convert.ToDecimal(max));
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
        
        public static bool CharRange(char value, char min, char max)
        {
            return (value >= min && value <= max);
        }
        public static bool ByteRange(byte value, byte min, byte max)
        {
            return (value >= min && value <= max);
        }
        public static bool ShortRange(short value, short min, short max)
        {
            return (value >= min && value <= max);
        }
        public static bool LongRange(long value, long min, long max)
        {
            return (value >= min && value <= max);
        }
        public static bool FloatRange(float value, float min, float max)
        {
            return (value >= min && value <= max);
        }
        public static bool DoubleRange(double value, double min, double max)
        {
            return (value >= min && value <= max);
        }
        public static bool DecimalRange(decimal value, decimal min, decimal max)
        {
            return (value >= min && value <= max);
        }
        public static bool ReadBool(string message)
        {
            bool result;
            bool valid = false;

            do
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (bool.TryParse(input, out result))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Type not supported");
                }
            } while (!valid);

            return result;
        }

       public static string ReadString(string message)
        {
            string result;

            Console.Write(message + " ");
            result = Console.ReadLine();

            return result; 
        }

        public static int ReadMenu(string[] items)
        {
            int result;

                for(int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine((i + 1) +" - "+ items[i]);
                }
                Console.WriteLine("0 - Quit ");

               result = ReadValue<int>("Make Selection: ", 0, items.Length);

            return result;
        }
        public static void StupidFunction()
        {
            Console.WriteLine("Hello");
        }
    }
}

