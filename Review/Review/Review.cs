using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FoundationReview
{
    class Review
    {
        static void Main(string[] args)
        {
            Delegatttte operationDelegate = D_Add;
            Console.WriteLine("Add: ");
            operationDelegate(5.0, 5.0);

            // (1) - Console IO
            // prompt user for name
            // read user name into a string called name
            // display user name in string using standard variable output {0} and string interpolation {name}

            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello {0}", name);
            Console.WriteLine($"good thing my name isnt {name}");

            // (2) - String
            // display a string using verbatim string
            Console.WriteLine(@"C:\'n");

            // (3) - String
            // display a string with quotes (") in it using escape characters
            Console.WriteLine("You know that qoute...\"early worm gets the chicken...?\", yeah me either");

            // (4) - String
            // replace the word "nice" with "fantastic" in the string below and display the string
            string s1 = "Today is a nice day!";
            Console.WriteLine("Fixed string: {0}", s1.Replace("nice", "fantastic"));


            // (5) - StringBuilder
            // create a StringBuilder string with "Welcome too Neumont College!" and specify that is has a capacity of 256 characters
            // remove the extra 'o' in too
            // display the string

            StringBuilder sb = new StringBuilder("welcome too Neumont College!", 256);
            sb.Remove(9, 1);
            Console.WriteLine(sb);

            // (6) - Data Types
            // <put answers after the question>
            // for example: how many bits in a byte? 8-bits
            // how many bits in a short? 16-bits
            // how many bits in a long? 64 bits
            // where are data types stored (stack/heap)? stack

            // (7) - Data Type Cast
            // cast the variable below to an int variable
            byte b1 = 123;
            int i1 = (int)b1;

            // (8) - Data Type Cast
            // what is the issue with doing this cast? you could narrow your values and loose some data if the value is bigger
            // what is it called? narrowing
            // int i = 1534;
            // byte b = (byte)i

            // (9) - Implicit Type
            // show an example of an implicit type
            var value = 666;
            Console.WriteLine("type: {0}", value.GetType());

            // (10) - DateTime Type
            // create a date type type with your birthday or some other significant date
            // display the date (day month, year and day of the week)
            DateTime dt = new DateTime(1996, 07, 29);
            Console.WriteLine("My birthday on {0} was {1}", dt.ToString("dd/MM/yyyy"), dt.DayOfWeek);

            // (11) - Arrays
            // create an array of 5 ints
            // sort the list 
            // display the list
            int[] num = { 1, 2, 3, 5, 4 };
            Array.Sort(num);
            Console.Write("sorted: ");

            foreach (int v in num)
            {
                Console.Write("{0} ", v);
            }
            Console.WriteLine("");


            // (12) - Arrays
            // create an Object Array (an array of objects) with a variety of types in the array
            Object[] objects = { 1, 3.0, 4.0f, 'A' };

            // (13) - Queue<T>
            // create a queue of float types
            // add three elements to the queue
            // dequeue an element from the queue
            // display the queue using foreach
            Queue<float> queue = new Queue<float>();
            queue.Enqueue(3.0f);
            queue.Enqueue(10.0f);
            queue.Enqueue(3.4f);

            queue.Dequeue();

            foreach (float o in queue)
            {
                Console.WriteLine($"queue : {o}");
            }

            // (14) - Stack<T>
            // create a stack of any type of your choosing
            // push three elements onto the stack
            // peek at the top element and display it
            // pop the top element
            Stack stack = new Stack();

            stack.Push("Hello");
            stack.Push("I");
            stack.Push("Need");

            Console.WriteLine("Peek: {0}", stack.Peek());
            stack.Pop();

            // (15) - Stack<T> | Queue<T>
            // convert either your stack or queue to an array
            // clear both your stack and queue
            object[] stackArray = stack.ToArray();

            stack.Clear();
            queue.Clear();

            // (16) - Stack<T> | Stack
            // <put answer after the question>
            // what's the difference between Stack<T> and Stack?
             
            // (17) - Iteration
            // create a do while loop with the while condition looking for i == 0
            int idw = 5;
            // do - while
            do
            {
                idw--;
                Console.Write(idw);
            } while (idw != 0);

            // (18) - Iteration
            // create a for loop that starts i at 0 and repeats while i < 105
            // display all odd i numbers
            for (int i = 0; i < 105; i++)
            {
                if (!(i % 2 == 0))
                {
                    Console.Write(" {0} ", i);
                }
            }

            Display();
        }
        // (19) - Enumeration
        // create an enum of some type that contains at least 3 elements
        // set the default data type to byte
        enum eMonsters : byte
        {
            Bat,
            Sasquash,
            Warewolf
        }


        // (20) - Enumeration
        // create a small switch statement that will print the enum name
        static void ScaryMonsters(eMonsters monster)
        {
            switch (monster)
            {
                case eMonsters.Bat:
                    Console.WriteLine("bat");
                    break;
                case eMonsters.Sasquash:
                    Console.WriteLine("Sasquash");
                    break;
                case eMonsters.Warewolf:
                    Console.WriteLine("Warewolf");
                    break;
                default:
                    break;
            }
        }

        public static void Display()
        {
            // (21) - Exception
            // create a try block where we try to convert a string to an int (because there are characters it will throw an exception)
            // create a catch block that will print the exception name and message (it can be the base catch (Exception exception)

            try
            {
                string ns = "23s4";
                int i = int.Parse(ns);
            }
            catch (Exception exception)
            {
                Console.WriteLine("\n" + exception.GetType().Name);
                Console.WriteLine(exception.Message);
            }

            // (22) - Nullable
            // create an int variable that is a nullable type (null can be assigned to it)
            // use the ?? to test if the variable is null, if it is assign a value to it
            int? var = null;
            int finalVar = var ?? 100;


            // (23A) - Generics
            // call the generic Subtract method and display the result
            Sub(5, 3);

            // (24A) - Pass By Reference
            // call the method that takes a reference to some type (int, float, ...)
            // display the type to make sure the value was changed

            int x = 2;
            int y = 4;
            IntRef(x, y);

            Console.ReadLine();
            // (25A) - Out Parameter
            // call the method that takes a out parameter to some type (int, float, ...)
            // display the type to make sure the value was set
            int i1 = 3;
            int i2 = 5;
            int outResult;
            OutAdd(i1, i2, out outResult);
            Console.WriteLine($"out: {i1} + {i2} = {outResult}");


            // (26) - Pass by Reference / Pass by Value
            // what is the difference between pass by reference and pass be value?
            //pass by value makes it so you get a copy of the value without modifying the real value, while the pass by reference
            //makes it so you modify your value.

            // (27) - Reference / Value Type
            // what is the difference between a value type and reference type
            //ref types are stored on the heap while value types are stored on the stack

            // (28) - Boxing / Unboxing
            float fb1 = 34.5f;
            object fbo = fb1;
            // what is it called when you convert the value type to the reference type?
            // what happens when we create a reference object from a value type?
            float fb2 = (float)fbo;

            //boxing, you are putting the refrence value into the object so it takes a copy of it. 

            // what is it called when you convert the reference type to the value type?
            // what happens when we create a value type from a reference object?

            //unboxing, you are able to get an object and turn it into the value needed. 

            // (29A) - Name Parameters
            // call Function01 with a named parameter(s)

            Function01(4, 3);
            Console.ReadLine();
        }

        // (23B) - Generics
        // create a method (Subtract) that takes two generic parameters and subtracts them and returns the result
        public static void Sub<T>(T num1, T num2)
        {
            double d1 = Convert.ToDouble(num1);
            double d2 = Convert.ToDouble(num2);
            Console.WriteLine($"{d1} - {d2} = {d1 - d2:f2}");
        }
        // (24B) - Pass By Reference
        // create a method that takes a reference to some type (int, float, ...) and multiplies it by some number
        public static void IntRef(int _X, int _Y)
        {
            int X = _X;
            int Y = _Y;
            int multi = X * Y;
            Console.WriteLine($"\n {X} * {Y} = {multi}");
        }


        // (25B) - Out Parameter
        // create a method that has an out parameter to some type (int, float, ...) and set it to some value
        public static void OutAdd(int i1, int i2, out int result)
        {
            result = i1 + i2;
        }
        // (29B) - Name Parameters
        public static void Function01(int param1, int param2)
        {
            Console.WriteLine($"Function 01: {param1} - {param2}");
        }

        // (30) - Optional / Default Parameters
        // set a default value for both parameters
        public static void Function02(int param1 = 5, bool param2 = false)
        {
            //
        }

        // (31) - params Parameter
        //public static void Function03(?? gpas)
        //{

        //}

        //I dont know what you want me to do here! sorry )))))):

        // (31) - Static Class
        // create a static class
        // include two variables in it
        // include two methods in it

        static class Monster
        {
            const float Bouns = 10.0f;
            const float Strength = 100.0f;

            static float AttackTotal(float power) { return power * Strength; }
            static float BounsMagic(float magic) { return magic * Bouns; }
        }

        // (32) - Abstract Base Class
        // create an abstract base class
        // include two fields (one field should be a float called percentage
        // include a accessor property to percentage and make sure the value is between 0-100 on the set
        // include a constructor that takes two parameters that will set your fields in the class
        // include a static variable
        // include a static method to access the static variable
        // include an abstract method
        // include a virtual method
        public abstract class MotorVehicle
        {

            int fuel;
            float percentage;
            static int mph;
            public MotorVehicle() { }
            public MotorVehicle(int f, float p)
            {
                this.fuel = f;
                SetPercentage(p);
            }
            static int Getmph()
            {
                return mph;
            }
            float GetPrecentage()
            {
                return percentage;
            }
            void SetPercentage(float p)
            {
                if (p > 0 && p < 100)
                {
                    this.percentage = p;
                }
            }
            int getFuel()
            {
                return this.fuel;
            }
            public abstract void Noise();
            public virtual void Drive()
            {
                Console.WriteLine("You are driving the car.");
            }
        }
        // (33) - Derived Class
        // create a class that is derived from the (32) - Abstract Base Class
        // include an override for the necessary methods
        // include a constructor that will take two parameters that you can base to your base class
        public class Motorcycle : MotorVehicle
        {
            public Motorcycle(int f, int p) : base(f, p) { }

            public override void Noise()
            {
                Console.WriteLine("vroom");
            }
            public override void Drive()
            {
                Console.WriteLine("you are driving a motorcycle.");
            }
        }
        // (34) - Sealed Derived Class
        // create a class that is derived from the (32) - Abstract Base Class
        // set the class so it can't be derived from
        public sealed class BMW : MotorVehicle
        {
            public override void Noise()
            {
                Console.WriteLine("vroom vroom, get out of me car.");
            }
        }
        // (35) - Operator Overoading
        // create a class called Rectangle
        // include two variables called width and height
        // include a constructor that takes two parameters to width and height
        // include at least two operators (+, i) or (<, >)

        public class Rectangle
        {
            float width = 0;
            float height = 0;
            public Rectangle(int w, int h) { width = w; height = h; }
            public Rectangle() { }
            public static bool operator >(Rectangle v1, Rectangle v2)
            {
                return (v1.width > v2.width && v1.height > v2.height);
            }
            public static bool operator <(Rectangle v1, Rectangle v2)
            {
                return (v1.width < v2.width && v1.height < v2.height);
            }
        }
        // (36) - Delegate
        // create a delegate definition that takes two parameters and returns void
        public delegate void Delegatttte(double num1, double num2);


        // (37) - Delegate Method
        // create a method that matches the signature of your delegate in (36)
        // print the two parameters in the method

        public static void D_Add(double num1, double num2)
        {
            Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
        }

        // (38) - Delegate
        // in Main create a delegate type and assign the method (37) to it
        // call the delegate to print out the parameters
        //did it in the begining :)


    }
}
