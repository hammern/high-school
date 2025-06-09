using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For
{
    class Program
    {
        static void Main(string[] args)
        {
            /*for (int i = 10; i <= 50; i += 2)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Please insert a number:");
            Console.Write("> ");
            int Num = int.Parse(Console.ReadLine());
            for (; Num > 0; Num--)
            {
                Console.WriteLine("*");
            }
            Console.Read();
            
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Please insert a number: ");
                long Number = long.Parse(Console.ReadLine());
                if (Number < 10 && Number > 0 || Number < 0 && Number > -10)
                {
                    Console.WriteLine("{0} is a 1-digit number.", Number);
                }
                else if (Number < 100 && Number >= 10 || Number <= -10 && Number > -100)
                {
                    Console.WriteLine("{0} is a 2-digit number.", Number);
                }
                else
                {
                    Console.WriteLine("{0} is different.", Number);
                }
            }
            Console.Read();
            
            Console.WriteLine("Please insert two numbers: ");
            Console.Write("Num 1: ");
            int Num1 = int.Parse(Console.ReadLine());
            Console.Write("Num 2: ");
            int Num2 = int.Parse(Console.ReadLine());
            if (Num1 > Num2)
                for (int i = Num2; i <= Num1 ; i++)
                {
                    if (Num2 % 5 == 0)
                        Console.WriteLine("The number {0} can be divided by 5.", Num2);
                    Num2++;
                }
            else if (Num1 < Num2)
                for (int i = Num1; i <=Num2 ; i++)
                {
                    if (Num1 % 5 == 0)
                        Console.WriteLine("The number {0} can be divided by 5.", Num1);
                    Num1++;
                }
            else
                Console.WriteLine("The numbers are equal.");
            Console.Read();
            */
            int PNum = 0;
            int NNum = 0;
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Please insert a number (" + i +"/10):");
                int Num = int.Parse(Console.ReadLine());
                if (Num > 0)
                {
                    PNum++;
                }
                else if (Num < 0)
                {
                    NNum++;
                }
            }
            Console.WriteLine("There are " + PNum + " positive numbers and " + NNum + " negetive numbers.");
            Console.Read();
        }
    }
}
