using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerIntNode
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            IntNode n1 = new IntNode(rand.Next(10));
            IntNode n2 = new IntNode(rand.Next(10));

            for (int i = 0; i < 5; i++)
            {
                Add(n1, rand.Next(10));
                Add(n2, rand.Next(10));
            }

            Console.WriteLine("First Node:");
            PrintAll(n1);
            Console.WriteLine("\nSecond Node:");
            PrintAll(n2);

            IntNode combined = CombineNodes(n1, n2);

            Console.WriteLine("\nCombined Node:");
            PrintAll(combined);

            Console.Read();
        }

        private static void Add(IntNode n, int num)
        {
            while (n.HasNext())
            {
                n = n.GetNext();
            }

            IntNode newNode = new IntNode(num);
            n.SetNext(newNode);
        }

        private static void PrintAll(IntNode n)
        {
            while (n != null)
            {
                Console.WriteLine(n.ToString());
                n = n.GetNext();
            }
        }

        private static IntNode CombineNodes(IntNode n1, IntNode n2)
        {
            IntNode combined = new IntNode(0);
            bool firstItem = true;

            while (n1 != null)
            {
                if (Exists(n2, n1.GetValue()))
                {
                    if (firstItem)
                    {
                        combined.SetValue(n1.GetValue());
                        firstItem = false;
                    }
                    else
                    {
                        Add(combined, n1.GetValue());
                    }
                }

                n1 = n1.GetNext();
            }

            return combined;
        }

        private static bool Exists(IntNode n, int num)
        {
            while (n != null)
            {
                if (n.GetValue() == num)
                {
                    return true;
                }

                n = n.GetNext();
            }
            
            return false;
        }
    }
}
