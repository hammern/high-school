using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage16_1
{
    class Ship
    {
        private Pirate[] pirates;
        private string shipName;
        private int currentPirate;

        internal Pirate[] Pirates
        {
            get
            {
                return pirates;
            }
            set
            {
                pirates = value;
            }
        }

        public int CurrentPirate
        {
            get
            {
                return currentPirate;
            }
            set
            {
                currentPirate = value;
            }
        }

        public Ship(string shipName)
        {
            this.shipName = shipName;
            Pirates = new Pirate[12];
        }

        public void AddPirate(Pirate p)
        {
            if (CurrentPirate < Pirates.Length)
            {
                Pirates[CurrentPirate++] = p;
            }
        }

        public void AddPirate(string pirateName, int rank)
        {
            if (CurrentPirate < Pirates.Length)
            {
                Pirate p = new Pirate(pirateName, rank);
                Pirates[CurrentPirate++] = p;
            }
        }
    }
}
