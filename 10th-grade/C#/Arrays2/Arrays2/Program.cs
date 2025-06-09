using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int[] arr1 = { 36, 8, 9, 73, 11, 3, 4 };
            int[] arr2 = { 4, 77, 8, 15, 12 };
            int[] arr3 = new int[arr1.Length];
            int Count = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int x = 0; x < arr2.Length; x++)
                {
                    if (arr1[i] == arr2[x])
                    {
                        arr3[Count] = arr1[i];
                        Count++;
                    }
                }
            }
            for (int i = 0; i < arr3.Length; i++)
            {
                Console.WriteLine(arr3[i]);
            }
            Console.Read();
            
            Console.WriteLine("Please enter how many numbers do you want to input?");
            Console.Write("> ");
            int NumOfNumbers = int.Parse(Console.ReadLine());
            int[] arr = new int[NumOfNumbers];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Please enter number {0}:", i + 1);
                Console.Write("> ");
                int Num = int.Parse(Console.ReadLine());
                arr[Num]++;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("The number {0} is there {1} times.", i + 1, arr[i]);
            }
            Console.Read();
            
            Console.WriteLine("Please enter how many people you have:");
            Console.Write("> ");
            int NumOfPeople = int.Parse(Console.ReadLine());
            int[] num = new int[NumOfPeople];
            int[] Ages = new int[21];
            string Max = "";
            int Place = 0;
            for (int i = 0; i < num.Length; i++)
            {
                Console.WriteLine("Please enter the age of number {0} (age between 1-20):", i + 1);
                Console.Write("> ");
                int Age = int.Parse(Console.ReadLine());
                Ages[Age]++;
            }
            for (int i = 0; i < num.Length; i++)
            {
                if (Ages[i] > Place)
                {
                    Place = Ages[i];
                    Max = "" + i;
                }
                else if (Ages[i] == Place)
                {
                    Max = Max + ", " + i;
                }
            }
            Console.WriteLine("The most common age is {0}.", Max);
            Console.WriteLine("The ages with out any classes are:");
            for (int i = 0; i < Ages.Length; i++)
            {
                if (Ages[i] == 0)
                {
                    Console.Write("> ");
                    Console.WriteLine(i);
                }
            }
            Console.Read();
            */
            Console.WriteLine("Please enter the number of rounds:");
            Console.Write("> ");
            int NumOfRounds = int.Parse(Console.ReadLine());
            int[] PlayerPoints = new int[4];
            for (int i = 0; i < NumOfRounds; i++)
            {
                PlayRound(i + 1, PlayerPoints);
            }
            for (int i = 0; i < PlayerPoints.Length; i++)
            {
                if (PlayerPoints[i] == PlayerPoints.Max())
                {
                    Console.WriteLine("The winner is player {0} with {1} points.", i + 1, PlayerPoints.Max());
                    break;
                }
            }
            Console.Read();
        }

        static void PlayRound(int Round, int[] PlayerPoints)
        {
            string[] PlacesNames = { "first", "second", "third" };
            int[] PointsPerPlace = { 7, 3, 0, -4 };
            int LastPlayer = 9; // The sum of all players numbers. By deducting the winning players we are left with the last player number.
            Console.WriteLine("Round {0}:", Round);
            Console.WriteLine("Enter the number 1-4 according to the players.");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Please enter who got {0} place:", PlacesNames[i]);
                Console.Write("> ");
                int Player = int.Parse(Console.ReadLine());
                PlayerPoints[Player - 1] += PointsPerPlace[i];
                LastPlayer -= Player;
            }
            PlayerPoints[LastPlayer] += PointsPerPlace[3];
        }
    }
}
