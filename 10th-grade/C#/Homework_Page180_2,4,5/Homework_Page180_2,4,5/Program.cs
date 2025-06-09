using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Page180_2_4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise 2 - 1.3
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Exercise 2 - 1.3");
            Console.ForegroundColor = ConsoleColor.White;
            float MoneyPerMin = 1.20f;
            Console.WriteLine("Please insert the number of minutes you talked this month:");
            Console.Write("> ");
            int NumOfMins = int.Parse(Console.ReadLine());
            Console.WriteLine("Please insert your regular payment per month:");
            Console.Write("> ");
            int RegularPayment = int.Parse(Console.ReadLine());
            float Total = MoneyPerMin * NumOfMins + RegularPayment;
            Console.WriteLine("Your total payment is " + Total);

            //Exercise 4 - 1.5b
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
Exercise 4 - 1.5b");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please insert a number of years:");
            Console.Write("> ");
            int NumOfYears = int.Parse(Console.ReadLine());
            Console.WriteLine("Please insert a number of months:");
            Console.Write("> ");
            int NumOfMonths = int.Parse(Console.ReadLine());
            Console.WriteLine("Please insert a number of days:");
            Console.Write("> ");
            int NumOfDays = int.Parse(Console.ReadLine());
            int Sum = NumOfYears * 365 + NumOfMonths * 30 + NumOfDays;
            Console.WriteLine("The total number of days is " + Sum);
            
            //Exercise 4 - 1.5a
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
Exercise 4 - 1.5a");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please insert two grades:");
            Console.Write("Grade 1: ");
            int Grade1 = int.Parse(Console.ReadLine());
            Console.Write("Grade 2: ");
            int Grade2 = int.Parse(Console.ReadLine());
            int AverageOfGrades = (Grade1 + Grade2) / 2;
            Console.WriteLine("The average of the two grades is " + AverageOfGrades);
            Console.Read();

        }
    }
}
