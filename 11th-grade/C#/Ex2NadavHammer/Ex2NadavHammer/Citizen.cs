using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2NadavHammer
{
    class Citizen
    {
        public string fullName { get; set; }
        public int id { get; set; }

        public Citizen(string fullName, int id)
        {
            this.fullName = fullName;
            this.id = id;
        }
    }
}
