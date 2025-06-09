using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int Pass = 0;
            int SumPass = 0;
            int Fail = 0;
            int SumFail = 0;
            Console.WriteLine("Please insert how many grades you want to input:");
            Console.Write("> ");
            int NumOfGrades = int.Parse(Console.ReadLine());
            for (int i = 0; i < NumOfGrades; i++)
                {
                 Console.WriteLine("Please insert grade {0}/{1}: ", i + 1, NumOfGrades);
                 Console.Write("> ");
                 int Input = int.Parse(Console.ReadLine());
                 if (Input >= 55)
                 {
                     Pass = Pass + Input;
                     SumPass++;
                 }
                 else
                 {
                     Fail = Fail + Input;
                     SumFail++;
                 }
                }
            Console.WriteLine("The remainder between the average of the passing grades({0}) and the average of the failing grades({1}) is {2}.", Pass / SumPass , Fail / SumFail ,(Pass / SumPass) - (Fail / SumFail));
            Console.Read();
            */
            long Sum = 1;
            Console.WriteLine("Please insert a number:");
            Console.Write("> ");
            long Num = long.Parse(Console.ReadLine());
            for (int i = 1; i <= Num; i++)
            {
                Sum = Sum * i;
            }
            Console.WriteLine(Sum);
            Console.Read();
        }
    }
}
