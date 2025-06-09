using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int[,] arr = { {1, 2, 3, 4, 5},
                           {6, 7, 8, 9, 10}, 
                           {11, 12, 13, 14, 15}, 
                           {16, 17, 18, 19, 20}, 
                           {21, 22, 23, 24, 25} };
            *//*
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (i == 0 || i == 4 || j == 0 || j == 4)
                    {
                        Console.WriteLine(arr[i, j]);
                    }
                }
            }
            Console.Read();
            *//*
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                    Console.WriteLine(arr[i, i]);
            }
            Console.Read();
            *//*
            int j = 4;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine(arr[i, j]);
                j--;
            }
            Console.Read();
            *//*
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 1; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine(arr[i, j]);
                }
            }
            Console.Read();
            
            int[,] arr = { {3, 1, 9, 0, 3},
                           {4, 7, 1, 7, 8},
                           {9, 0, 6, 8, 2}, 
                           {1, 4, 1, 4, 5}, 
                           {5, 7, 1, 9, 5} };
            Console.WriteLine(CheckEqual(arr));
            int j = arr.GetLength(0) - 1;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine(arr[i, j]);
                j--;
            }
            Console.Read();
            *//*
            int[,] arr = { {4, 9, 2},
                           {3, 5, 7},
                           {8, 1, 6} };
            int[,] arr2 = { {2, 7, 6},
                            {9, 5, 1},
                            {4, 3, 8} };
            int[,] arr3 = { {8, 11, 14, 1},
                            {13, 2, 7, 12},
                            {3, 16, 9, 6},
                            {10, 5, 4, 15} };
            Console.WriteLine("Array 1: " + MagicSquare(arr));
            Console.WriteLine("Array 2: " + MagicSquare(arr2));
            Console.WriteLine("Array 3: " + MagicSquare(arr3));
            Console.Read();
            */
            int[,] arr = { {2, 5, 7},
                           {9, 13, 19},
                           {21, 37, 42} };
            bool Check = false;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == arr[i, j + 1])
                    {
                        Check = true;
                    }
                    else
                    {
                        Check = false;
                        break;
                    }
                }
            }
            if (Check == true)
            {
                Console.WriteLine("The array is sorted");
            }
            else
            {
                Console.WriteLine("The array is not sorted");
            }
            Console.Read();
        }
        static bool CheckEqual(int[,] arr)
        {
            bool Check = false;
            int j = arr.GetLength(0);
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                j--;
                if (arr[i, i] == arr[i, j])
                {
                    Check = true;
                }
                else
                {
                    Check = false;
                    break;
                }
            }
            return Check;
        }
        static bool MagicSquare(int[,] arr)
        {
            int DiagonalLeftToRight = 0;
            int DiagonalRightToLeft = 0;
            int[] Lines = new int[arr.GetLength(0)];
            int[] Columns = new int[arr.GetLength(0)];
            bool MagicSquareCheck = false;
            int j = arr.GetLength(0) - 1;
            int k = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                DiagonalLeftToRight += arr[i, i];
                DiagonalRightToLeft += arr[i, j];
                k = 0;
                while (k < arr.GetLength(0))
                {
                    Lines[i] += arr[i, k];
                    Columns[i] += arr[k, i];
                    k++;
                }
                j--;
            }
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (Lines[i] == Columns[i] && Columns[i] == DiagonalLeftToRight && DiagonalLeftToRight == DiagonalRightToLeft)
                {
                    MagicSquareCheck = true;
                }
                else
                {
                    break;
                }
            }
            return MagicSquareCheck;
        }
    }
}
