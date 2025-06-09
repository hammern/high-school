using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage16_3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            
            Ex 2 - 
            
            All a => id = 111, name = "Zvulun", degree = "manager"
            
            a[++counter] => (Element) id = 222, name = "Sonya"

            SuperElement se => id = 444, name = "Rami", degree = "programmer"

            a[++counter] => (Element) id = 555, name = "Miri"

            a[++counter] => (SuperElement) id = 666, name = "Miri", degree = "cleaner"

            a[++counter] => (SuperElement) id = 777, name = "Ruven", degree = "cleaner"

            a.Print();
            
            Output:
            id = 111, name = "Zvulun", degree = "manager"

            id = 222, name = "Sonya"
            id = 555, name = "Miri"
            id = 666, name = "Miri", degree = "cleaner"
            id = 777, name = "Ruven", degree = "cleaner"
            

            Ex 3 -

            a.PrintWorkers(cleaner) needs to be added to ALL

            public void PrintWorkers(string work)
            {
                for (int i = 0; i < this.counter; i++)
                {
                    if (arr[i] is SuperElement)
                    {
                        if (((SuperElement)(arr[i])).GetDegree() == work)
                        {
                            Console.WriteLine(arr[i]);
                        }
                    }
                }
            }

             */
        }
    }
}
