using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage13
{
    class Program
    {
        static void Main(string[] args)
        {
            Train train = new Train("2020", 30000, 100000);

            train.Wagons[0] = new Wagon("2019", 25000, 5);
            train.Wagons[1] = new Wagon("2019", 20000, 3);
            train.Wagons[2] = new Wagon("2019", 30000, 8);

            train.CargoWagons[0] = new CargoWagon("2018", 25000, 15000);
            train.CargoWagons[1] = new CargoWagon("2018", 20000, 14000);

            Console.WriteLine("Can carry: " + train.canCarry());
            Console.Read();
        }
    }
}
