using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerRecursiveArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 5, 4, 6, 7 };
            Console.WriteLine(CheckSymmetrySum(arr));

            Console.Read();
        }

        static bool CheckSymmetrySum(int[] arr)
        {
            return CheckSymmetrySum(arr, 0, arr.Length - 1);
        }

        static bool CheckSymmetrySum(int[] arr, int startIndex, int lastIndex)
        {
            if (lastIndex < startIndex)
            {
                return true;
            }
            return arr[startIndex] + arr[lastIndex] == arr[startIndex + 1] + arr[lastIndex - 1] && CheckSymmetrySum(arr, startIndex + 1, lastIndex - 1);
        }
    }
}
