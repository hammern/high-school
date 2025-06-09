using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerBinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinNode<int> bst = new BinNode<int>(15);
            bst.Left = new BinNode<int>(new BinNode<int>(5), 6, new BinNode<int>(new BinNode<int>(8), 9, null));
            bst.Right = new BinNode<int>(null, 26, new BinNode<int>(new BinNode<int>(29), 30, null));

            InsertIntoBST(bst, 35);

            Console.WriteLine("Ascending order:");
            PrintAscendingOrder(bst);

            Console.WriteLine("Descending order:");
            PrintDescendingOrder(bst);

            Stack<int> s = new Stack<int>();
            Leaves(bst, s);

            BinNode<int> bst2 = new BinNode<int>(15);
            bst2.Left = new BinNode<int>(new BinNode<int>(5), 7, new BinNode<int>(new BinNode<int>(8), 9, null));
            bst2.Right = new BinNode<int>(null, 25, new BinNode<int>(new BinNode<int>(29), 32, new BinNode<int>(35)));

            Console.WriteLine("Equal trees:");
            Console.WriteLine(EqualTrees(bst, bst2));

            Console.Read();
        }

        public static void InsertIntoBST(BinNode<int> bst, int x)
        {
            if (bst == null)
            {
                bst = new BinNode<int>(x);
            }
            else if (bst.Value > x)
            {
                if (bst.HasLeft())
                {
                    InsertIntoBST(bst.Left, x);
                }
                else
                {
                    bst.Left = new BinNode<int>(x);
                }
            }
            else if (bst.Value < x)
            {
                if (bst.HasRight())
                {
                    InsertIntoBST(bst.Right, x);
                }
                else
                {
                    bst.Right = new BinNode<int>(x);
                }
            }
        }

        public static void PrintAscendingOrder(BinNode<int> bst)
        {
            if (bst.HasLeft())
            {
                PrintAscendingOrder(bst.Left);
            }
            Console.WriteLine(bst.Value);
            if (bst.HasRight())
            {
                PrintAscendingOrder(bst.Right);
            }
        }
        
        public static void PrintDescendingOrder(BinNode<int> bst)
        {
            if (bst.HasRight())
            {
                PrintDescendingOrder(bst.Right);
            }
            Console.WriteLine(bst.Value);
            if (bst.HasLeft())
            {
                PrintDescendingOrder(bst.Left);
            }
        }

        // Bagrut 2011 - 4
        public static void Leaves(BinNode<int> t, Stack<int> s) // A
        {
            if (t.HasRight())
            {
                Leaves(t.Right, s);
            }
            if (!t.HasLeft() && !t.HasRight())
            {
                s.Push(t.Value);
            }
            if (t.HasLeft())
            {
                Leaves(t.Left, s);
            }
        }

        public static bool EqualTrees(BinNode<int> t1, BinNode<int> t2) // B
        {
            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();

            Leaves(t1, s1);
            Leaves(t2, s2);

            while (!s1.IsEmpty() && !s2.IsEmpty())
            {
                if (s1.Pop() != s2.Pop())
                {
                    return false;
                }
            }
            if (!s1.IsEmpty() || !s2.IsEmpty())
            {
                return false;
            }
            return true;
        }
    }
}
