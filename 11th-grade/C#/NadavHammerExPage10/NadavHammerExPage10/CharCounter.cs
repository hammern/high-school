using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage10
{
    class CharCounter
    {
        private int count;
        private char letter;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public char Letter
        {
            get
            {
                return letter;
            }
        }

        public CharCounter(char letter)
        {
            this.letter = letter;
            count = 0;
        }

        public void Increase()
        {
            count++;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", count, letter);
        }
    }
}
