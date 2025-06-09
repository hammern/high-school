using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage13
{
    class Locomotive : BaseWagon
    {
        private int maxWeight;

        public int MaxWeight
        {
            get
            {
                return maxWeight;
            }

            set
            {
                maxWeight = value;
            }
        }

        public Locomotive(string manufacturingYear, int weight, int maxWeight) : base(manufacturingYear, weight)
        {
            this.MaxWeight = maxWeight;
        }
    }
}
