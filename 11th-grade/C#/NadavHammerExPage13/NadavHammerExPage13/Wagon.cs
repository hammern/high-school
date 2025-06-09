using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage13
{
    class Wagon : BaseWagon
    {
        private int maxPassengers;

        public Wagon(string manufacturingYear, int weight, int maxPassengers) : base(manufacturingYear, weight)
        {
            this.maxPassengers = maxPassengers;
        }
    }
}
