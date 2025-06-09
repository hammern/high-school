using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage16_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ship s1 = new Ship("Shoola");

            Bay b = new Bay();
            b.AddShip(s1);
            Ship s2 = new Ship("Rina");
            s1 = new Ship("Yosefa");
            b.AddShip(s2);
            b.AddShip(s1);
            b.AddShip(new Ship("Diva"));

            Console.Read();

            // Ex 2 - DoJob()
            // Ex 5 - 4 new ships
            // Ex 6 - shipcount = 4
            // Ex 7 - Shoola, Rina, Yosefa, Diva
        }
    }
}
