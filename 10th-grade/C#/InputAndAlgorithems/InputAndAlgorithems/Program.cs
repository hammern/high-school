using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello, This program will take the price of your computer and tax in your country. Then it will calculate the final price");
            Console.WriteLine("Please insert the price of the computer:");
            Console.Write("> ");
            int PriceOfComputer = int.Parse(Console.ReadLine());
            Console.WriteLine("Please insert the Tax in your country:");
            Console.Write("> ");
            int Tax = int.Parse(Console.ReadLine());
            int FinalPrice = PriceOfComputer + PriceOfComputer*Tax/100;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("The price of the coumpter is " + FinalPrice); 
            Console.Read();
            
            Console.WriteLine("Please insert an age:");
            Console.Write("> ");
            int YoungerBoy = int.Parse(Console.ReadLine());
            int OlderBoy = (YoungerBoy + 10);
            Console.WriteLine("The older boy's age is " + OlderBoy);
            int YoungerGirl = (OlderBoy + 1);
            Console.WriteLine("The younger girl's age is " + YoungerGirl);
            int OlderGirl = (YoungerGirl + 3);
            Console.WriteLine("The Older girl's age is " + OlderGirl);
            Console.Read();
            */
            Console.WriteLine("Please insert a value for a and b");
            Console.WriteLine("Before:");
            Console.Write("a=");
            int StartA = int.Parse(Console.ReadLine());
            Console.Write("b=");
            int StartB = int.Parse(Console.ReadLine());
            int EndB = StartA;
            int EndA = StartB;
            Console.WriteLine("After:");
            Console.WriteLine("a=" + EndA);
            Console.WriteLine("b=" + EndB);
            Console.Read();
        }
    }
}
