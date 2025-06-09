using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Please insert how many cars are in the race:");
            Console.Write("> ");
            int NumOfRacers = int.Parse(Console.ReadLine());
            int[] ArrTimeOfRacers = new int[NumOfRacers];
            int Overall = 0;
            for (int i = 0; i < ArrTimeOfRacers.Length; i++)
            {
                Console.WriteLine("Please insert the time for racer number {0}:", i + 1);
                Console.Write("> ");
                ArrTimeOfRacers[i] = int.Parse(Console.ReadLine());
                Overall += ArrTimeOfRacers[i];
            }
            Console.WriteLine("The average is {0}.", Overall / NumOfRacers);
            int CountBellowAvg = 0;
            for (int x = 0; x < ArrTimeOfRacers.Length; x++)
            {
                if (ArrTimeOfRacers[x] < (Overall / NumOfRacers))
                {
                    Console.WriteLine("Driver number {0} time is bellow average.", x + 1);
                    CountBellowAvg++;
                }
            }
            Console.WriteLine("There are {0} drivers bellow average.", CountBellowAvg);
            Console.Read();
            
            int[] NumOfBabies = new int[12];
            string[] Month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int Overall = 0;
            int Count = 0;
            int Biggest = 0;
            string BiggestMonth = "";
            int Smallest = int.MaxValue;
            string SmallestMonth = "";
            for (int i = 0; i < NumOfBabies.Length; i++)
            {
                Console.WriteLine("Please enter how many babies were born in the month {0}:", Month[i]);
                Console.Write("> ");
                NumOfBabies[i] = int.Parse(Console.ReadLine());
                Overall += NumOfBabies[i];
                if (NumOfBabies[i] > Biggest)
                {
                    Biggest = NumOfBabies[i];
                    BiggestMonth = Month[i];
                }
                if (NumOfBabies[i] < Smallest)
                {
                    Smallest = NumOfBabies[i];
                    SmallestMonth = Month[i];
                }
            }
            for (int i = 0; i < NumOfBabies.Length; i++)
            {
                if (NumOfBabies[i] > (Overall / 12))
                {
                    Count++;
                }
            }
            Console.WriteLine("The month with the biggest number of babies born is {0} and {1} babies were born.", BiggestMonth, Biggest);
            Console.WriteLine("The month with the smallest number of babies born is {0} and {1} babies were born.", SmallestMonth, Smallest);
            Console.WriteLine("The average of all the babies that were born this year is {0}.", Overall / 12);
            Console.WriteLine("There are {0} months with number of babies born above the average.", Count);
            Console.Read();
            
            bool Organized = false;
            Console.WriteLine("Please enter how many numbers do you want in the array:");
            Console.Write("> ");
            int Num = int.Parse(Console.ReadLine());
            int[] arr = new int[Num];
            for (int i = 0; i < Num; i++)
            {
                Console.WriteLine("Please insert number {0}:", i + 1);
                Console.Write("> ");
                arr[i] = int.Parse(Console.ReadLine());
                if (i == 0)
                {

                }
                else if (arr[i-1] < arr[i])
                {
                    Organized = true;
                }
                else
                {
                    Organized = false;
                    break;
                }
            }
            if (Organized == true)
            {
                Console.WriteLine("The array is organized by an ascending order.");
            }
            else
            {
                Console.WriteLine("The array isn't organized by an ascending order.");
            }
            Console.Read();
            
            Console.WriteLine("Please enter how many students are in class:");
            Console.Write("> ");
            int NumOfStudents = int.Parse(Console.ReadLine());
            int[] grade1 = new int[NumOfStudents];
            int[] grade2 = new int[NumOfStudents];
            int[] FinalGrade = new int[NumOfStudents];
            string[] Names = new string[NumOfStudents];
            for (int i = 0; i < NumOfStudents; i++)
            {
                Console.WriteLine("Please enter the name for student number {0}:", i + 1);
                Console.Write("Student Number {0}: ", i + 1);
                Names[i] = Console.ReadLine();
                Console.WriteLine("Please enter the first grade of {0}:", Names[i]);
                Console.Write("> ");
                grade1[i] = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the second grade of {0}:", Names[i]);
                Console.Write("> ");
                grade2[i] = int.Parse(Console.ReadLine());
                FinalGrade[i] = Math.Max(grade1[i], grade2[i]);
            }
            for (int i = 0; i < NumOfStudents; i++)
            {
                Console.WriteLine("The final grade for {0} is {1}.", Names[i], FinalGrade[i]);
            }
            Console.ReadLine();
            */
            Console.WriteLine("Please enter how many numbers do you want to enter:");
            Console.Write("> ");
            int Num = int.Parse(Console.ReadLine());
            int[] Numbers = new int[Num];
            int[] Positive = new int[Num];
            int[] Negetive = new int[Num];
            for (int i = 0; i < Numbers.Length; i++)
            {
                Console.WriteLine("Please enter number {0}:", i + 1);
                Console.Write("> ");
                Numbers[i] = int.Parse(Console.ReadLine());
                if (Numbers[i] >= 0)
                {
                    Positive[i] = Numbers[i];
                }
                else
                {
                    Negetive[i] = Numbers[i];
                }
            }
            Console.WriteLine("Positive numbers:");
            for (int i = 0; i < Positive.Length; i++)
            {
                if (Positive[i] != 0)
                {
                    Console.WriteLine(Positive[i]);
                }
            }
            Console.WriteLine("Negetive numbers:");
            for (int i = 0; i < Negetive.Length; i++)
            {
                if (Negetive[i] != 0)
                {
                    Console.WriteLine(Negetive[i]);
                }
            }
            Console.Read();
        }
    }
}
