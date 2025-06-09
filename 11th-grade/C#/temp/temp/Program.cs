using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp
{
    class Program
    {
        static void Main(string[] args)
        {
            A x = new B();
            //B y = new A();

            A ab = new B();

            ab.Print();

            ab.XYZ();

            Console.Read();
        }
    }
}
