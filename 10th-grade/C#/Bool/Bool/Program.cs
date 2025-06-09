using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bool
{
    class Program
    {
        static void Main(string[] args)
        {
            /*float Temp;
            if ((Temp > 37.5) || (Temp < 36.5))
            { Console.WriteLine("ABC"); }

            int Age;
            if ((Age > 60) && (Age < 120))
            { Console.WriteLine("ABC"); }
            
            Console.WriteLine("Please insert a number:");
            Console.Write("> ");
            int Num = int.Parse(Console.ReadLine());
            if ((Num % 4 == 0) && (Num % 3 == 0))
            { Console.WriteLine("Your number is divided by 3 and 4."); }
            else
            { Console.WriteLine("Your number isn't divided by 3 and 4."); }
            Console.Read();
            
            Console.WriteLine("Please insert a 2-digit number:");
            Console.Write("> ");
            int Num3 = int.Parse(Console.ReadLine());
            if ((Num3 / 10 == 3 || Num3 % 10 == 3))
            { Console.WriteLine("Your number has 3 in it."); }
            else
            { Console.WriteLine("Your number doesn't have 3 in it."); }
            Console.Read();
            */
            Console.WriteLine("Please insert your grades in the following subects:");
            Console.WriteLine("Algo:");
            Console.Write("> ");
            int Algo = int.Parse(Console.ReadLine());
            Console.WriteLine("C#:");
            Console.Write("> ");
            int CSharp = int.Parse(Console.ReadLine());
            Console.WriteLine("Program designing:");
            Console.Write("> ");
            int Prog = int.Parse(Console.ReadLine());
            if (Algo >= 80 && CSharp >= 80 || CSharp >= 80 && Prog >= 80 || Prog >= 80 && Algo >= 80)
            { Console.WriteLine("You can proceed to year B."); }
            else
            { Console.WriteLine("You can not proceed to year B because you don't have 2 grades above 80."); }
            Console.Read();
        }
    }
}
