using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage15
{
    class PartTimeWorker : Worker
    {
        private int hours;
        private int payPerHour;

        public int Hours { get => hours; set => hours = value; }
        public int PayPerHour { get => payPerHour; set => payPerHour = value; }

        public PartTimeWorker(string firstName, string lastName, string id, int hours, int payPerHour) : base(firstName, lastName, id)
        {
            this.hours = hours;
            this.payPerHour = payPerHour;
        }

        public override int Payment()
        {
            return hours * payPerHour;
        }
    }
}
