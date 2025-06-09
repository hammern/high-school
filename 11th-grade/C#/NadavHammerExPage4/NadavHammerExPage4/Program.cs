using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ex 1
            int[] arr1 = {2, 5, 7, 10, 5 };
            Console.WriteLine(FindAmountOfEven(arr1));

            // Ex 2
            int[] arr2 = { 2, 5, 7, 10, 5 };
            Console.WriteLine(FindLargestNumber(arr2));

            // Ex 3
            int[] arr3 = { 1, 3, 5, 21 };
            Console.WriteLine(CheckRisingOrder(arr3));

            // Ex 4
            int[] arr4 = { 5, 4, 10, 13, 20 };
            Console.WriteLine(CheckDividingOfNum(arr4, 10));

            // Ex 5
            int[] arr5_1 = { 1, 2, 3 };
            int[] arr5_2 = { 1, 2, 3 };
            Console.WriteLine(CheckEvenSameIndex(arr5_1, arr5_2));

            // Ex 6
            int[] arr6 = { 5, 13, 18, 20, 30, 32, 42 };
            Console.WriteLine(CheckExists(arr6, 32));

            // Ex 7
            int[] arr7_1 = { 4, 6, 10, 10, 30, 40, 100, 703 };
            int[] arr7_2 = { 1, 12, 20, 55, 89 };
            int[] combinedArr7 = SortTwoArrays(arr7_1, arr7_2);
            for (int i = 0; i < combinedArr7.Length - 1; i++)
            {
                Console.Write(combinedArr7[i] + "-");
            }
            Console.Write(combinedArr7[combinedArr7.Length - 1]);

            Console.Read();
        }

        // Ex 1
        static int FindAmountOfEven(int[] arr)
        {
            return FindAmountOfEven(arr, 0);
        }

        private static int FindAmountOfEven(int[] arr, int index)
        {
            if (index == arr.Length - 1)
            {
                return 0;
            }
            if (arr[index] % 2 == 0)
            {
                return 1 + FindAmountOfEven(arr, index + 1);
            }
            return FindAmountOfEven(arr, index + 1);
        }

        // Ex 2
        static int FindLargestNumber(int[] arr)
        {
            return FindLargestNumber(arr, 0, arr[0]);
        }

        private static int FindLargestNumber(int[] arr, int index, int largestNumber)
        {
            if (index == arr.Length - 1)
            {
                return largestNumber;
            }
            if (arr[index] < arr[index + 1])
            {
                largestNumber = arr[index + 1];
            }
            return FindLargestNumber(arr, index + 1, largestNumber);
        }

        // Ex 3
        static bool CheckRisingOrder(int[] arr)
        {
            return CheckRisingOrder(arr, 0);
        }

        private static bool CheckRisingOrder(int[] arr, int index)
        {
            if (index == arr.Length - 1)
            {
                return true;
            }
            if (arr[index] > arr[index + 1])
            {
                return false;
            }
            return CheckRisingOrder(arr, index + 1);
        }

        // Ex 4
        static int CheckDividingOfNum(int[] arr, int num)
        {
            return CheckDividingOfNum(arr, num, 0);
        }

        private static int CheckDividingOfNum(int[] arr, int num, int index)
        {
            if (index == arr.Length - 1)
            {
                return num % arr[index] == 0 ? 1 : 0;
            }

            return (num % arr[index] == 0 ? 1 : 0) + CheckDividingOfNum(arr, num, index + 1);
        }

        // Ex 5
        static bool CheckEvenSameIndex(int[] arr1, int[] arr2)
        {
            return CheckEvenSameIndex(arr1, arr2, 0);
        }

        private static bool CheckEvenSameIndex(int[] arr1, int[] arr2, int i)
        {
            if (i == arr1.Length - 1)
            {
                return arr1[i] == arr2[i];
            }
            return arr1[i] == arr2[i] && CheckEvenSameIndex(arr1, arr2, i + 1);
        }

        // Ex 6
        static bool CheckExists(int[] arr, int num)
        {
            return CheckExists(arr, num, 0, arr.Length - 1) == num;
        }

        private static int CheckExists(int[] arr, int num, int start, int end)
        {
            if (start == end)
            {
                return arr[start];
            }

            int mid = (end + start) / 2;

            int n = CheckExists(arr, num, start, mid);
            if (num <= n)
            {
                return n;
            }
 
            return CheckExists(arr, num, mid + 1, end);
        }

        // Ex 7
        static int[] SortTwoArrays(int[] arr1, int[] arr2)
        {
            int[] combinedArr = new int[arr1.Length + arr2.Length];
            int i = 0;
            int j = 0;
            int k = 0;

            while ((i < arr1.Length) && (j < arr2.Length))
            {
                if (arr1[i] < arr2[j])
                {
                    combinedArr[k] = arr1[i];
                    i++;
                }
                else
                {
                    combinedArr[k] = arr2[j];
                    j++;
                }
                k++;
            }

            for (; i < arr1.Length; i++)
            {
                combinedArr[k] = arr1[i];
                k++;
            }

            for (; j < arr2.Length; j++)
            {
                combinedArr[k] = arr2[j];
                k++;
            }

            return combinedArr;
        }
    }
}
