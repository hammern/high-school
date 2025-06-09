using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace While
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int Answer = 0;
            while (Answer != 11)
            {
                Console.WriteLine("Please solve the next problem: 7+4");
                Console.Write("> ");
                Answer = int.Parse(Console.ReadLine());
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Great job!");
            Console.Read();
            
            int Tip = 0;
            int Sum = 0;
            while (Tip != -1)
            {
                Console.WriteLine("Please insert the tips you got today (enter -1 when you are done).");
                Sum = Sum + Tip;
                Console.Write("> ");
                Tip = int.Parse(Console.ReadLine());
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You got {0} shekels today!", Sum);
            Console.Read();
            
            int Grades = 0;
            int TotalGrades = 0;
            int Count = 0;
            while (Grades != 123)
            {
                TotalGrades += Grades;
                Console.WriteLine("Please enter grades between 0-100. When you are done enter 123.");
                Console.Write("> ");
                Grades = int.Parse(Console.ReadLine());
                Count++;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("The average of the grades is {0}.", TotalGrades / (Count - 1));
            Console.Read();
            
            int Tallest = 0;
            int CountTallest = 0;
            int Count180CM = 0;
            Console.WriteLine("Please insert the height of the students (example: 192). Enter 0 to exit.");
            Console.Write("> ");
            int Height = int.Parse(Console.ReadLine());
            if (Height > 180)
            {
                Count180CM++;
            }
            while (Height != 0)
            {
                Console.WriteLine("Please insert the height of the students. Enter 0 to exit.");
                Console.Write("> ");
                Height = int.Parse(Console.ReadLine());
                if (Height > Tallest)
                {
                    Tallest = Height;
                    CountTallest++;
                }
                if (Height > 180)
                {
                    Count180CM++;
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("The tallest student is {0} cm tall.", Tallest);
            Console.WriteLine("There are {0} students above 180 cm.", Count180CM);
            Console.Read();
            */
            int PushDistance = 0;
            int Count = 0;
            while (PushDistance < 50)
            {
                Console.WriteLine("Please insert a push distance between 1-20 meters:");
                Console.Write("> ");
                int Push = int.Parse(Console.ReadLine());
                PushDistance += Push;
                Count++;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("It took Ralph {0} pushes.", Count);
            Console.Read();
        }
    }
}
