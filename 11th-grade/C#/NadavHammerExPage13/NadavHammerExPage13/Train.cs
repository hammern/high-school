using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage13
{
    class Train
    {
        private CargoWagon[] cargoWagons;
        private int cargoWagonsLength = 2;
        private Wagon[] wagons;
        private int wagonsLength = 3;
        private Locomotive locomotive;

        internal CargoWagon[] CargoWagons
        {
            get
            {
                return cargoWagons;
            }

            set
            {
                cargoWagons = value;
            }
        }

        internal Wagon[] Wagons
        {
            get
            {
                return wagons;
            }

            set
            {
                wagons = value;
            }
        }

        public Train(string manufacturingYear, int weight, int maxWeight)
        {
            this.locomotive = new Locomotive(manufacturingYear, weight, maxWeight);
            CargoWagons = new CargoWagon[cargoWagonsLength];
            Wagons = new Wagon[wagonsLength];
        }

        public bool canCarry()
        {
            int allWeight = 0;

            allWeight += locomotive.Weight;
            for (int i = 0; i < wagons.Length; i++)
            {
                allWeight += wagons[i].Weight;
            }
            for (int j = 0; j < cargoWagons.Length; j++)
            {
                allWeight += cargoWagons[j].Weight;
            }

            Console.WriteLine("Weight of train: " + allWeight);
            Console.WriteLine("Max carry limit of train: " + locomotive.MaxWeight);

            return allWeight <= locomotive.MaxWeight;
        }
    }
}
