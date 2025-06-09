using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_PaperExercises7_8_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("//Exercise 7");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Please insert two positive numbers:");
            Console.Write("X: ");
            int X = int.Parse(Console.ReadLine());
            Console.Write("Y: ");
            int Y = int.Parse(Console.ReadLine());
            int Ans = 0;
            for (int i = 0; i < Y; i++)
            {
                Ans += X;
            }
            Console.WriteLine("The answer of {0}*{1} is {2}.", X, Y, Ans);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("//Exercise 8");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Please insert two positive numbers:");
            Console.Write("X: ");
            X = int.Parse(Console.ReadLine());
            Console.Write("Y: ");
            Y = int.Parse(Console.ReadLine());
            Ans = 1;
            for (int i = 0; i < Y; i++)
            {
                Ans *= X;
            }
            Console.WriteLine("The answer of {0}^{1} is {2}.", X, Y, Ans);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("//Exercise 11");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Please insert a number:");
            Console.Write("> ");
            int Num = int.Parse(Console.ReadLine());
            bool IsPrime = true;
            for (int i = 2; i < Num; i++)
            {
                if (Num % i == 0)
                {
                    IsPrime = false;
                    break;
                }
            }
            if (IsPrime == false)
            {
                Console.WriteLine("The number {0} is not a prime number.", Num);
            }
            else
            {
                Console.WriteLine("The number {0} is a prime number.", Num);
            }
            Console.Read();
        }
    }
}
