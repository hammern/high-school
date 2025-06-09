using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage13
{
    class CargoWagon : BaseWagon
    {
        private int maxWeight;

        public CargoWagon(string manufacturingYear, int weight, int maxWeight) : base(manufacturingYear, weight)
        {
            this.maxWeight = maxWeight;
        }
    }
}
