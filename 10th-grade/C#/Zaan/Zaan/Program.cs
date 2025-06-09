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
            Console.Write("Please enter a {0}-digit num: ", LEN_Of_NUM);
            string num = Console.ReadLine();
            while (!(num.Length == LEN_Of_NUM && Is_Num(num)))
            {
                Console.Write("Please enter a {0}-digit num: ", LEN_Of_NUM);
                num = Console.ReadLine();
            }
            Console.WriteLine("You entered the number: " + num);
            Console.WriteLine("The digits of the number are: " + Digits(num));
            Console.WriteLine("The sum of the digits is: " + Sum(num));
            Console.Read();
        }
        static bool Is_Num(string Num)
        {
            for (int i = 0; i < Num.Length; i++)
            {
                if (!('0' <= Num[i] && Num[i] <= '9'))
                {
                    return false;
                }
            }
            return true;
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
