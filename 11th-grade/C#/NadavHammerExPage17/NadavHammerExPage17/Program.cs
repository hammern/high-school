using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage17
{
    class Program
    {
        static void Main(string[] args)
        {
            BinNode<int> bt = new BinNode<int>(1);
            bt.Left = new BinNode<int>(new BinNode<int>(4), 2, new BinNode<int>(new BinNode<int>(8), 5, null));
            bt.Right = new BinNode<int>(new BinNode<int>(6), 3, new BinNode<int>(null, 7, new BinNode<int>(9)));

            Console.WriteLine("Sum of tree:");
            Console.WriteLine(SumOfTree(bt));

            Console.WriteLine("Sum of even numbers:");
            Console.WriteLine(SumOfEvenTree(bt));

            Console.WriteLine("Left to right values:");
            PrintFromLeftToRight(bt);

            Console.WriteLine("\nChilds upwards:");
            PrintChildsUpwards(bt);

            Console.WriteLine("\nAmount of parents with only one child:");
            Console.WriteLine(ParentsWithOneChild(bt));

            Console.Read();
        }

        public static int SumOfTree(BinNode<int> bt)
        {
            return bt == null ? 0 : SumOfTree(bt.Left) + SumOfTree(bt.Right) + bt.Value;
        }

        public static int SumOfEvenTree(BinNode<int> bt)
        {
            if (bt == null)
            {
                return 0;
            }
            if (bt.Value % 2 == 0)
            {
                return SumOfEvenTree(bt.Left) + SumOfEvenTree(bt.Right) + bt.Value;
            }
            return SumOfEvenTree(bt.Left) + SumOfEvenTree(bt.Right);
        }

        public static void PrintFromLeftToRight(BinNode<int> bt)
        {
            if (bt != null)
            {
                Console.Write(bt.Value + " ");
                PrintFromLeftToRight(bt.Left);
                PrintFromLeftToRight(bt.Right);
            }
        }

        public static void PrintChildsUpwards(BinNode<int> bt)
        {
            if (bt != null)
            {
                PrintChildsUpwards(bt.Left);
                PrintChildsUpwards(bt.Right);
                Console.Write(bt.Value + " ");
            }
        }

        public static int ParentsWithOneChild(BinNode<int> bt)
        {
            if (bt == null)
            {
                return 0;
            }
            if ((bt.HasLeft() && !bt.HasRight()) || (!bt.HasLeft() && bt.HasRight()))
            {
                return ParentsWithOneChild(bt.Left) + ParentsWithOneChild(bt.Right) + 1;
            }
            return ParentsWithOneChild(bt.Left) + ParentsWithOneChild(bt.Right);
        }
    }
}
