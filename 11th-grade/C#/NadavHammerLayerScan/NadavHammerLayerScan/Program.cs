using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerLayerScan
{
    class Program
    {
        static void Main(string[] args)
        {
            BinNode<int> bt = new BinNode<int>(1);
            bt.Left = new BinNode<int>(new BinNode<int>(4), 2, new BinNode<int>(new BinNode<int>(8), 5, null));
            bt.Right = new BinNode<int>(new BinNode<int>(6), 3, new BinNode<int>(null, 7, new BinNode<int>(9)));

            Console.WriteLine("Print by levels:");
            PrintScan(bt);

            Node<int> temp = new Node<int>(5);
            temp = new Node<int>(2, temp);
            BinNode<Node<int>> longest = new BinNode<Node<int>>(temp);
            temp = new Node<int>(5, new Node<int>(4, new Node<int>(3)));
            longest.Left = new BinNode<Node<int>>(temp);
            temp = new Node<int>(1, new Node<int>(9));
            longest.Right = new BinNode<Node<int>>(temp);

            Console.WriteLine("Longest node in tree:");
            temp = LongestNodeInTree(longest);
            while (temp != null)
            {
                Console.WriteLine(temp.Value);
                temp = temp.Next;
            }

            Console.Read();
        }

        public static void PrintScan(BinNode<int> bt)
        {
            Queue<BinNode<int>> q = new Queue<BinNode<int>>();
            q.Insert(bt);
            BinNode<int> val = null;
            while (!q.IsEmpty())
            {
                val = q.Remove();
                Console.WriteLine(val.Value);
                if (val.HasLeft())
                {
                    q.Insert(val.Left);
                }
                if (val.HasRight())
                {
                    q.Insert(val.Right);
                }
            }
        }

        public static Node<int> LongestNodeInTree(BinNode<Node<int>> bt)
        {
            if (bt == null)
            {
                return null;
            }

            int maxLength = 0;
            int current = 0;
            Node<int> longestNode = null;

            Queue<BinNode<Node<int>>> q = new Queue<BinNode<Node<int>>>();
            BinNode<Node<int>> pos = null;
            q.Insert(bt);
            while (!q.IsEmpty())
            {
                pos = q.Remove();
                current = Length(pos.Value);
                if (current > maxLength)
                {
                    maxLength = current;
                    longestNode = pos.Value;
                }
                if (pos.HasLeft())
                    q.Insert(pos.Left);
                if (pos.HasRight())
                    q.Insert(pos.Right);
            }
            return longestNode;
        }

        public static int Length(Node<int> n)
        {
            Node<int> iter = n;
            int length = 0;
            while (iter != null)
            {
                length++;
                iter = iter.Next;
            }
            return length;
        }
    }
}
