using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_CheckForPalindrom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert a 3-digit number:");
            Console.Write("> ");
            int FullNum = int.Parse(Console.ReadLine());
            int FirstDigit = FullNum / 100;
            int ThirdDigit = FullNum % 10;
            if (FirstDigit == ThirdDigit)
            {
                Console.WriteLine("The Number " + FullNum + " is a palindrom.");
            }
            else
            {
                Console.WriteLine("The Number " + FullNum + " is not a palindrom.");
            }
            Console.Read();
        }
    }
}
