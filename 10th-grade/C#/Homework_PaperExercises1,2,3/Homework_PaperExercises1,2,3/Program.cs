using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_PaperExercises1_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise 1
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Exercise 1:");
            Console.ForegroundColor = ConsoleColor.Gray;
            int MaxOfStudents = 0;
            for (int i = 0; i < 7 ; i++)
            {
                Console.WriteLine("Please insert the number of students in each bus {0}/7: ", i + 1);
                Console.Write("> ");
                int NumOfStudents = int.Parse(Console.ReadLine());
                MaxOfStudents += NumOfStudents;
            }
            Console.WriteLine("The number of students in all of the seven busses is {0}.", MaxOfStudents);
            
            //Exercise 2
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Exercise 2:");
            Console.ForegroundColor = ConsoleColor.Gray;
            int Average = 0;
            for (int i = 0; i < 5; i++ )
            {
                Console.WriteLine("Please insert grade {0}/5:", i + 1);
                Console.Write("> ");
                int Grade = int.Parse(Console.ReadLine());
                Average += Grade;
            }
            Console.WriteLine("The average of the grades is {0}.", Average / 5);
            
            //Exercise 3
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Exercise 3:");
            Console.ForegroundColor = ConsoleColor.Gray;
            int MaxLength = 0;
            int MinLength = 0;
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Please insert the jump length {0}/6:", i + 1);
                Console.Write("> ");
                int Length = int.Parse(Console.ReadLine());
                if (Length > MaxLength)
                    MaxLength = Length;
                if (MinLength == 0 || Length < MinLength)
                    MinLength = Length;                
            }
            Console.WriteLine("The biggest length is {0}.", MaxLength);
            Console.WriteLine("The smallest length is {0}.", MinLength);
            Console.Read();
        }
    }
}
