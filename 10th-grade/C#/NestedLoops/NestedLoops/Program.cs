using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            /*bool Ans = false;
            int Num = 0;
            while (Ans == false)
            {
                Console.WriteLine("Please write seventee three:");
                Console.Write("> ");
                Num = int.Parse(Console.ReadLine());
                if (Num == 73)
                {
                    Ans = true;
                }
            }
            Console.WriteLine("Good job!");
            Console.Read();
            
            int Sum, Count, Avg, Grade, CountBest = 0; 
            Console.WriteLine("Please insert how many students do you have:");
            Console.Write("> ");
            int Students = int.Parse(Console.ReadLine());
            Console.WriteLine("Please insert grades for your students. When you finish enter -999.");
            for (int i = 0; i < Students; i++)
            {
                Sum = 0;
                Count = 0;
                Console.Write("Please insert the name of your student: ");
                string Name = Console.ReadLine();
                Console.WriteLine("Please enter a grade for the student {0}:", Name);
                Console.Write("> ");
                Grade = int.Parse(Console.ReadLine());
                while (Grade != -999)
                {
                    Sum += Grade;
                    Count++;
                    Console.WriteLine("Please enter a grade for the student {0}:", Name);
                    Console.Write("> ");
                    Grade = int.Parse(Console.ReadLine());
                }
                Avg = Sum / Count;
                Console.WriteLine("The average of {0} is {1}.", Name, Avg);
                if (Avg > 90)
                {
                    CountBest++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("There are {0} students with averages above 90.", CountBest);
            Console.Read();
            */
            Console.WriteLine("Please insert two numbers:");
            Console.WriteLine("When you are done enter two equal numbers.");
            Console.Write("Num 1: ");
            int FirstNum = int.Parse(Console.ReadLine());
            Console.Write("Num 2: ");
            int SecondNum = int.Parse(Console.ReadLine());
            while (FirstNum != SecondNum)
            {
                for (; FirstNum <= SecondNum; FirstNum++)
                {
                    Console.WriteLine(FirstNum);
                }
                Console.WriteLine();
                Console.Write("Num 1: ");
                FirstNum = int.Parse(Console.ReadLine());
                Console.Write("Num 2: ");
                SecondNum = int.Parse(Console.ReadLine());
            }
            Console.Read();
        }
    }
}
