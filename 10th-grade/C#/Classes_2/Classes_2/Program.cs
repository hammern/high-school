using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Square MySquare = new Square();
            Console.WriteLine("Please enter how many squares do you need to solve:");
            Console.Write("> ");
            int NumOfSquares = int.Parse(Console.ReadLine());
            for (int i = 0; i < NumOfSquares; i++)
            {
                Console.WriteLine("Please enter the Length of the square:");
                Console.Write("> ");
                int Length = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the width of the square:");
                Console.Write("> ");
                int Width = int.Parse(Console.ReadLine());
                MySquare.Set_Sides(Length, Width);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("The circumference of the square is: " + MySquare.Get_Circumference());
                Console.WriteLine("The area of the square is: " + MySquare.Get_Area());
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("---------------------------------------");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.Read();
        }
    }
    public class Square
    {
        private int Length;
        private int Width;

        public void Set_Sides(int newLength, int newWidth)
        {
            Length = newLength;
            Width = newWidth;
        }

        public int Get_Area()
        {
            return Length * Width;
        }
        public int Get_Circumference()
        {
            return (Length * 2) + (Width * 2);
        }
    }
}
