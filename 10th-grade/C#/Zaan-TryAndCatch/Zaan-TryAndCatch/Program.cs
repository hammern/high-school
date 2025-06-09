using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaan
{
    class Program
    {
        static void Main(string[] args)
        {
            const int LEN_Of_NUM = 5;
            int num = 0;
            while (!(num.ToString().Length == LEN_Of_NUM))
            {
                try
                {
                    Console.Write("Please enter a {0}-digit num: ", LEN_Of_NUM);
                    num = int.Parse(Console.ReadLine());
                    if (num.ToString().Length != LEN_Of_NUM)
                    {
                        throw new ArgumentException("Not the correct length");
                    }
                }
                catch(ArgumentException)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("==== Not the correct length ====", LEN_Of_NUM);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("==== You didn't enter a num ====", LEN_Of_NUM);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            Console.WriteLine("You entered the number: " + num);
            Console.WriteLine("The digits of the number are: " + Digits(num.ToString()));
            Console.WriteLine("The sum of the digits is: " + Sum(num.ToString()));
            Console.Read();
        }
        static string Digits(string Num)
        {
            string Digits = "";
            for (int i = 0; i < Num.Length; i++)
            {
                if (i == Num.Length - 1)
                {
                    Digits += Num[i];
                }
                else
                {
                    Digits += Num[i] + ", ";
                }
            }
            return Digits;
        }
        static int Sum(string Num)
        {
            int Sum = 0;
            for (int i = 0; i < Num.Length; i++)
            {
                Sum += int.Parse(Num[i].ToString());
            }
            return Sum;
        }
    }
}
