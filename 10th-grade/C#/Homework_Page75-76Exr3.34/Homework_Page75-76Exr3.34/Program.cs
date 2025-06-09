using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Page75_76Exr3._34
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise 3.34a
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Exercise 3.34a");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please insert two heights of students (for example - 1.85)");
            Console.Write("First Height: ");
            float FirstHeight = float.Parse(Console.ReadLine());
            Console.Write("Second Height: ");
            float SecondHeight = float.Parse(Console.ReadLine());
            float Abs = (Math.Abs(FirstHeight - SecondHeight));
            Console.WriteLine("The abuslute value of {0} - {1} is {2}", FirstHeight, SecondHeight, Abs);
            if (FirstHeight > SecondHeight)
            { Console.WriteLine("The first height is taller."); }
            else if (FirstHeight < SecondHeight)
            { Console.WriteLine("The second height is taller."); }
            else
            { Console.WriteLine("The heights are equal."); }

            // Exercise 3.34b
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
Exercise 3.34b");
            Console.ForegroundColor = ConsoleColor.White;
            Random rand = new Random();
            int Num1 = rand.Next(20, 41);
            int Num2 = rand.Next(20, 41);
            int Num3 = rand.Next(20, 41);
            Console.WriteLine("The first number is {0}.", Num1);
            Console.WriteLine("The second number is {0}.", Num2);
            Console.WriteLine("The third number is {0}.", Num3);
            if (Num1 > Num2 && Num1 > Num3)
            { Console.WriteLine("The first number is the biggest!"); }
            else if (Num2 > Num1 && Num2 > Num3)
            { Console.WriteLine("The second number is the biggest!"); }
            else if (Num3 > Num1 && Num3 > Num2)
            { Console.WriteLine("The third number is the biggest!"); }
            else
            { Console.WriteLine("looks like some of the numbers are equal!"); }
            if (Math.Round(Math.Sqrt(Num1)) == Math.Round(Math.Sqrt(Num2)))
            { Console.WriteLine("The rounded Square root of {0} and {1} is equal.", Num1, Num2); }
            else if (Math.Round(Math.Sqrt(Num1)) == Math.Round(Math.Sqrt(Num3)))
            { Console.WriteLine("The rounded Square root of {0} and {1} is equal.", Num1, Num3); }
            else if (Math.Round(Math.Sqrt(Num2)) == Math.Round(Math.Sqrt(Num3)))
            { Console.WriteLine("The rounded square root of {0} and {1} is equal.", Num2, Num3); }
            else if (Math.Round(Math.Sqrt(Num1)) == Math.Round(Math.Sqrt(Num2)) && Math.Round(Math.Sqrt(Num1)) == Math.Round(Math.Sqrt(Num3)))
            { Console.WriteLine("All of the rounded square roots are equal!"); }
            else
            { Console.WriteLine("None of the rounded square roots are equal!"); }
            Console.Read();
        }
    }
}
