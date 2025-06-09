using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage16_1
{
    class Bay
    {
        Ship[] ships;
        int shipcount = 0;

        public Bay()
        {
            ships = new Ship[20];
        }

        public void AddShip(Ship ship)
        {
            ships[shipcount] = ship;
            shipcount++;
        }

        public void PrintCaptains()
        {
            for (int i = 0; i < shipcount; i++)
            {
                for (int j = 0; j < ships[i].CurrentPirate; j++)
                {
                    if (ships[i].Pirates[j].Rank == 1)
                    {
                        Console.WriteLine(ships[i].Pirates[j].Name);
                    }
                }
            }
        }
    }
}
