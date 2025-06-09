using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage16_1
{
    class Pirate : IJob
    {
        private int rank;
        private string name;

        public int Rank
        {
            get
            {
                return rank;
            }
            set
            {
                rank = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Pirate(string name, int rank)
        {
            this.Name = name;
            this.Rank = rank;
        }

        public void DoJob()
        {

        }
    }
}
