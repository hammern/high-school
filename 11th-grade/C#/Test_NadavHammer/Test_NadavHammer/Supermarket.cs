using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_NadavHammer
{
    class Supermarket
    {
        private Register[] registers;

        internal Register[] Registers
        {
            get
            {
                return registers;
            }

            set
            {
                registers = value;
            }
        }

        public Supermarket()
        {
            Registers = new Register[10];
            for (int i = 0; i < Registers.Length; i++)
            {
                Registers[i] = new Register();
            }
        }

        public void AddToSupermarketQueue(string name)
        {
            Register shortest = Registers[GetShortest()];
            shortest.Names.Insert(name);
            shortest.Amount++;
        }

        private int GetShortest()
        {
            int shortest = int.MaxValue;
            int shortestQueue = 0;

            for (int i = 0; i < Registers.Length; i++)
            {
                if (!Registers[i].EndOfShift)
                {
                    if (Registers[i].Amount < shortest)
                    {
                        shortest = Registers[i].Amount;
                        shortestQueue = i;
                    }
                }
            }
            return shortestQueue;
        }

        public void ShiftEnded()
        {
            int index = 0;

            for (int i = 0; i < Registers.Length; i++)
            {
                if (Registers[i].EndOfShift)
                {
                    index = i;
                }
            }
            while (!Registers[index].Names.IsEmpty())
            {
                AddToSupermarketQueue(Registers[index].Names.Remove());
            }
            Registers[index].EndOfShift = true;
            Registers[index].Amount = 0;
        }
    }
}
