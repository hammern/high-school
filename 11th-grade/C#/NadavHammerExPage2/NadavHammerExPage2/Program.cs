using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ex 1:");
            Console.WriteLine(AmountOfDigitsInNum(13789));
            Console.WriteLine("Ex 2:");
            Console.WriteLine(SumOfDigits(123));
            Console.WriteLine("Ex 3:");
            Console.WriteLine(Mult(2, 3));
            Console.WriteLine("Ex 4:");
            Console.WriteLine(Power(2, 4));
            Console.WriteLine("Ex 5:");
            Console.WriteLine(Factorial(5));
            Console.WriteLine("Ex 6:");
            Console.WriteLine(Fibo(8));
            Console.WriteLine("Ex 7:");
            Console.WriteLine(ArithmeticSquence(3, 8, 2));
            Console.WriteLine("Ex 8:");
            ReverseNum(1872);
            Console.WriteLine("Ex 9:");
            Console.WriteLine(CheckEvenNumbers(12));
            Console.WriteLine("Ex 10:");
            Console.WriteLine(IsAllChar("7ThisIsAString"));

            Console.Read();
        }

        // Ex1
        static int AmountOfDigitsInNum(int n)
        {
            if (n < 10)
            {
                return 1;
            }
            else
            {
                return 1 + AmountOfDigitsInNum(n / 10);
            }
        }

        // Ex2
        static int SumOfDigits(int n)
        {
            if (n < 10)
            {
                return n;
            }
            else
            {
                return SumOfDigits(n / 10) + (n % 10);
            }
        }

        // Ex3
        static int Mult(int a, int b)
        {
            if (a == 0 || b == 0)
            {
                return 0;
            }
            else if (b == 1)
            {
                return a;
            }
            return Mult(a, b - 1) + a;
        }

        // Ex4
        static int Power(int a, int b)
        {
            if (b == 0)
            {
                return 1;
            }
            else if (b == 1)
            {
                return a;
            }
            else
            {
                return a * Power(a, b - 1);
            }
        }

        // Ex5
        static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        // Ex6
        static int Fibo(int n)
        {
            if (n == 1)
            {
                return 0;
            }
            if (n == 2)
            {
                return 1;
            }
            return Fibo(n - 1) + Fibo(n - 2);
        }

        // Ex7
        static int ArithmeticSquence(int n, int firstItem, int leap)
        {
            if (n == 1)
            {
                return firstItem;
            }
            else
            {
                return ArithmeticSquence(n - 1, firstItem, leap) + leap;
            }
        }

        // Ex8
        static void ReverseNum(int a)
        {
            if (a < 10)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.Write(a % 10);
                ReverseNum(a / 10);
            }
        }

        // Ex 9
        static bool CheckEvenNumbers(int a)
        {
            if (a % 2 == 0)
            {
                if (a < 10)
                {
                    return true;
                }
                return CheckEvenNumbers(a / 10);
            }
            else
            {
                return false;
            }
        }

        // Ex10
        static bool IsAllChar(string str)
        {
            if (str.Length == 0)
            {
                return true;
            }

            bool isChar = (str[0] >= 'a' && str[0] <= 'z') || (str[0] >= 'A' && str[0] <= 'Z');
            return IsAllChar(str.Substring(1)) && isChar;
        }
    }
}
