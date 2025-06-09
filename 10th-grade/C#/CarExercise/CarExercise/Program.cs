using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int TimeFirstPlace = int.MaxValue;
            int TimeSecondPlace = 0;
            int PlaceOfFirst = 0;
            int PlaceOfSecond = 0;
            Console.WriteLine("Please enter how many cars are racing:");
            Console.Write("> ");
            int NumOfCars = int.Parse(Console.ReadLine());
            for (int i = 1; i <= NumOfCars; i++)
            {
                Console.WriteLine("Please insert the time it took car number {0}/{1} to finish the race:", i, NumOfCars);
                Console.Write("> ");
                int CurrentPlace = int.Parse(Console.ReadLine());
                if (CurrentPlace < TimeFirstPlace)
                {
                    TimeSecondPlace = TimeFirstPlace;
                    PlaceOfSecond = PlaceOfFirst;
                    TimeFirstPlace = CurrentPlace;
                    PlaceOfFirst = i;
                }
            }
            Console.WriteLine("The car that came first is car number {0} and it took {1} seconds to finish the race.", PlaceOfFirst, TimeFirstPlace);
            Console.WriteLine("The car that came second is car number {0} and it took {1} seconds to finish the race.", PlaceOfSecond, TimeSecondPlace);
            Console.Read();
        }
    }
}
