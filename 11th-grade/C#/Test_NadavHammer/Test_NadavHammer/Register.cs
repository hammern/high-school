using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_NadavHammer
{
    class Register
    {
        private bool endOfShift;
        private int amount;
        private Queue<string> names;

        public Register()
        {
            this.endOfShift = false;
            this.amount = 0;
            this.names = new Queue<string>();
        }
        public bool EndOfShift
        {
            get
            {
                return endOfShift;
            }

            set
            {
                endOfShift = value;
            }
        }

        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public Queue<string> Names
        {
            get
            {
                return names;
            }

            set
            {
                names = value;
            }
        }
    }
}
