using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage13
{
    class BaseWagon
    {
        protected string manufacturingYear;
        protected int weight;

        public int Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }

        public BaseWagon(string manufacturingYear, int weight)
        {
            this.manufacturingYear = manufacturingYear;
            this.Weight = weight;
        }
    }
}
