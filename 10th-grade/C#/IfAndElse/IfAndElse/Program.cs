using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfAndElse
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Please insert a number:");
            Console.Write("> ");
            int Num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Please insert a second different number:");
            Console.Write("> ");
            int Num2 = int.Parse(Console.ReadLine());
            if (Num1 > Num2)
            {
                Console.WriteLine("Your first number is bigger: " + Num1);
            }
            else
            {
                Console.WriteLine("Your second number is bigger: " + Num2);
            }
            Console.Read();
            
            Console.WriteLine("Please insert a number:");
            Console.Write("> ");
            int Num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Please insert a second different number:");
            Console.Write("> ");
            int Num2 = int.Parse(Console.ReadLine());
            if (Num1 > Num2)
            {
                Console.WriteLine(Num2 + ", " + Num1);
            }
            else
            {
                Console.WriteLine(Num1 + ", " + Num2);
            }
            Console.Read();
            
            Console.WriteLine("Please insert a grade from the first half of the year:");
            Console.Write("> ");
            int FirstGrade = int.Parse(Console.ReadLine());
            Console.WriteLine("Please insert a grade from the second half of the year:");
            Console.Write("> ");
            int SecondGrade = int.Parse(Console.ReadLine());
            if (SecondGrade > FirstGrade + 5)
            {
                Console.WriteLine("The student has made a progress from the first half of the year!");
            }
            else
            {
                Console.WriteLine(@"The student hasn't made a progress 
     .-""""""-.
   .'          '.
  /   O      O   \
 :           `    :
 |                |
 :    .------.    :
  \  '        '  /
   '.          .'
     '-......-'");
            }
            Console.Read(); 
            */
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
