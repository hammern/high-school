using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkPage33Exr3._9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert a number between 1-99");
            Console.Write("> ");
            int Num = int.Parse(Console.ReadLine());
            if (Num % 7 == 0 || Num / 10 == 7 || Num % 10 == 7)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("BOOM!");
            }
            else
                Console.WriteLine("Not boom :-(");
            Console.Read();
        }
    }
}
