using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage14
{
    class WirelessHeadphones : Product
    {
        private int range;

        public WirelessHeadphones(string manufacturer, string model, int price, int amount, int range) : base(manufacturer, model, price, amount)
        {
            this.range = range;
        }
    }
}
