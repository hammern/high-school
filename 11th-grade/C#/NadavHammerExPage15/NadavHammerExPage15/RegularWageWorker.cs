using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage15
{
    class RegularWageWorker : Worker
    {
        private int pay;

        public int Pay { get => pay; set => pay = value; }

        public RegularWageWorker(string firstName, string lastName, string id, int pay) : base(firstName, lastName, id)
        {
            this.pay = pay;
        }

        public override int Payment()
        {
            return pay;
        }
    }
}
