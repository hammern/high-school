using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage15
{
    class Manager : RegularWageWorker
    {
        private int bonus;

        public int Bonus { get => bonus; set => bonus = value; }

        public Manager(string firstName, string lastName, string id, int pay, int bonus) : base(firstName, lastName, id, pay)
        {
            this.bonus = bonus;
        }

        public override int Payment()
        {
            return base.Pay + bonus;
        }
    }
}
