using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Page117_Exercise7._63
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = { {5, 4, 3, 2, 1},
                           {10, 9, 8, 7, 6},
                           {15, 14, 13, 12, 11},
                           {20, 19, 18, 17, 16},
                           {25, 24, 23, 22, 21} };
            Exercise1(arr);
            Exercise2(arr);
            Exercise3(arr);
            Exercise4(arr);
            Exercise5(arr);
            Exercise6(arr);
        }
        static void Exercise1(int[,] arr)
        {
            Console.WriteLine("Exercise 1:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (i == 0 || i == arr.GetLength(0) - 1 || j == 0 || j == arr.GetLength(0) - 1)
                    {
                        Console.Write("{0,2:d} ", arr[i, j]);
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static void Exercise2(int[,] arr)
        {
            Console.WriteLine("Exercise 2:");
            int j = arr.GetLength(0) - 1;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int k = 0; k < arr.GetLength(0) - i; k++)
                {
                    Console.Write("   ");
                }
                Console.WriteLine(arr[i, j]);
                j--;
            }
            Console.ReadLine();
        }
        static void Exercise3(int[,] arr)
        {
            Console.WriteLine("Exercise 3:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int k = 0; k < i; k++)
                {
                    Console.Write("   ");
                }
                Console.WriteLine(arr[i, i]);
            }
            Console.ReadLine();
        }
        static void Exercise4(int[,] arr)
        {
            Console.WriteLine("Exercise 4:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j < arr.GetLength(1) - (i + 1))
                    {
                        Console.Write("{0,2:d} ", arr[i, j]);
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static void Exercise5(int[,] arr)
        {
            Console.WriteLine("Exercise 5:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i > j)
                    {
                        Console.Write("{0,2:d} ", arr[i, j]);
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static void Exercise6(int[,] arr)
        {
            Console.WriteLine("Exercise 6:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i + j >= arr.GetLength(1))
                    {
                        Console.Write("{0,2:d} ", arr[i, j]);
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
