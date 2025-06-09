using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switch
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Please insert a number between 0-9:");
            Console.Write("> ");
            int Num = int.Parse(Console.ReadLine());
            switch(Num)
            {
                case 0:
                    Console.WriteLine("Zero");
                    break;
                case 1:
                    Console.WriteLine("One");
                    break;
                case 2:
                    Console.WriteLine("Two");
                    break;
                case 3:
                    Console.WriteLine("Three");
                    break;
                case 4:
                    Console.WriteLine("Four");
                    break;
                case 5:
                    Console.WriteLine("Five");
                    break;
                case 6:
                    Console.WriteLine("Six");
                    break;
                case 7:
                    Console.WriteLine("Seven");
                    break;
                case 8:
                    Console.WriteLine("Eight");
                    break;
                case 9:
                    Console.WriteLine("Nine");
                    break;
                default:
                    Console.WriteLine("You're a rebel, aren't you...");
                    break;
            }
            Console.Read();
            
            Console.WriteLine("Please insert two numbers:");
            Console.Write("Num 1: ");
            float Num1 = float.Parse(Console.ReadLine());
            Console.Write("Num 2: ");
            float Num2 = float.Parse(Console.ReadLine());
            Console.WriteLine("Please insert one of the following symbols: (+)(-)(*)(/)");
            Console.Write("> ");
            char Symbol = char.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Cyan;
            switch(Symbol)
            {
                case '+':
                    Console.WriteLine("The result is " + (Num1 + Num2));
                    break;
                case '-':
                    Console.WriteLine("The result is " + (Num1 - Num2));
                    break;
                case '*':
                    Console.WriteLine("The result is " + (Num1 * Num2));
                    break;
                case '/':
                    Console.WriteLine("The result is " + (Num1 / Num2));
                    break;
                default:
                    Console.WriteLine("You're a rebel, aren't you...");
                    break;
            }
            Console.Read();
            
            Console.WriteLine("Please insert a capital letter:");
            Console.Write("> ");
            char Letter = char.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine((char) (Letter+32));
            Console.Read();
            */
            Console.WriteLine("Please insert a symbol:");
            Console.Write("> ");
            char Symbol = char.Parse(Console.ReadLine());
            if (Symbol >= 'A' && Symbol <= 'Z')
            { Console.WriteLine("The symbol " + "'" + Symbol + "'" + " is a capital letter."); }
            else if (Symbol >= 'a' && Symbol <= 'z')
            { Console.WriteLine("The symbol " + "'" + Symbol + "'" + " is a small letter."); }
            else if (Symbol >= '0' && Symbol <= '9')
            { Console.WriteLine("The symbol " + "'" + Symbol + "'" + " is a number."); }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("OTHER");
            }
            Console.Read();
        }
    }
}
