using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ex 1
            Console.WriteLine("Ex 1:");
            Console.WriteLine(GetAmountOfDigInNum(122342, 2));
            // Ex 2
            Console.WriteLine("Ex 2:");
            Console.WriteLine(CheckIfDigInNum(123, 4));

            // Printing Ex
            // Ex 26
            Console.WriteLine("Ex 26:");
            PrintTriangleFromBottomToTop(3);
            // Ex 27
            Console.WriteLine("Ex 27:");
            PrintTriangleFromTopToBottom(7);
            // Ex 28
            Console.WriteLine("Ex 28:");
            PrintTriangleAndReverse(10);


            Console.Read();
        }

        // Ex 1
        static int GetAmountOfDigInNum(int num, int dig)
        {
            if (num < 10)
            {
                return (num == dig ? 1 : 0);
            }

            return ((num % 10) == dig ? 1 : 0) + GetAmountOfDigInNum(num / 10, dig);
        }

        // Ex2
        static bool CheckIfDigInNum(int num, int dig)
        {
            if (num < 10)
            {
                return num != dig;
            }

            return ((num % 10) != dig) && CheckIfDigInNum(num / 10, dig);
        }

        // Printing Exs

        private static void PrintStars(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        // Ex 26
        static void PrintTriangleFromBottomToTop(int n)
        {
            if (n == 0)
            {
                return;
            }
            PrintStars(n);
            PrintTriangleFromBottomToTop(n - 1);
        }

        // Ex 27
        static void PrintTriangleFromTopToBottom(int n)
        {
            if (n == 0)
            {
                return;
            }

            PrintTriangleFromTopToBottom(n - 1);
            PrintStars(n);
        }

        // Ex 28
        static void PrintTriangleAndReverse(int n)
        {
            if (n == 0)
            {
                return;
            }

            PrintStars(n);
            PrintTriangleAndReverse(n - 1);
            if (n > 1)
            {
                PrintStars(n);
            }
        }
    }
}
