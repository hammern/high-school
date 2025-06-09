using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace While2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int Sum = 0;
            int Count = 0;
            Console.WriteLine("Please enter travel distance:");
            while (Sum <= 3000)
            {
                Console.Write("> ");
                int Distance = int.Parse(Console.ReadLine());
                Sum += Distance;
                Count++;
            }
            Console.WriteLine("it took {0} travels to gain the free ticket.", Count);
            Console.WriteLine("You have {0} km over what you need.", Sum - 3000);
            Console.Read();
            
            int Count = 0;
            Console.WriteLine("Please enter a positive number:");
            Console.Write("> ");
            int Num = int.Parse(Console.ReadLine());
            while (Num > 0)
            {
                Num /= 10;
                Count++;
            }
            Console.WriteLine($"The number has {Count} digits.");
            Console.Read();
            
            for (int Num1 = 1; Num1 < 7; Num1++)
            {
                for (int Num2 = 1; Num2 < 7; Num2++)
                {
                    Console.WriteLine($"{Num1},{Num2}");
                }
            }
            Console.Read();
            */
            bool Found = false;
            int Digit;
            Console.WriteLine("Please enter a positive number:");
            Console.Write("> ");
            int Num = int.Parse(Console.ReadLine());
            while (Num > 0 && Found == false)
            {
                Digit = Num % 10;
                if (Digit == 5)
                {
                    Found = true;
                }
                Num = Num / 10;
            }
            if (Found == true)
            {
                Console.WriteLine("There is 5 in the number.");
            }
            else
            {
                Console.WriteLine("There isn't 5 in the number.");
            }
            Console.Read();
        }
    }
}
