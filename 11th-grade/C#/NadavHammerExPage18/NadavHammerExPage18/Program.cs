using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage18
{
    class Program
    {
        static void Main(string[] args)
        {
            BinNode<int> bt = new BinNode<int>(1);
            bt.Left = new BinNode<int>(new BinNode<int>(4), 2, new BinNode<int>(new BinNode<int>(8), 5, null));
            bt.Right = new BinNode<int>(new BinNode<int>(6), 3, new BinNode<int>(null, 7, new BinNode<int>(9)));

            Console.WriteLine("Sum of leafs values:");
            Console.WriteLine(SumOfLeavesValues(bt));

            Console.WriteLine("Num of leafs:");
            Console.WriteLine(NumOfLeaves(bt));

            Console.WriteLine("Sum of right children:");
            Console.WriteLine(SumOfRightChildren(bt));

            Console.WriteLine("Balanced tree:");
            Console.WriteLine(BalancedTree(bt));
            BinNode<int> balanced = new BinNode<int>(new BinNode<int>(2), 1, new BinNode<int>(2));
            Console.WriteLine(BalancedTree(balanced));

            Console.WriteLine("Balanced tree 2:");
            Console.WriteLine(BalancedTree2(bt));
            BinNode<int> balanced2 = new BinNode<int>(1);
            balanced2.Left = new BinNode<int>(new BinNode<int>(2), 2, new BinNode<int>(2));
            balanced2.Right = new BinNode<int>(new BinNode<int>(2), 2, new BinNode<int>(2));
            Console.WriteLine(BalancedTree2(balanced2));

            Console.WriteLine("Decreasing tree:");
            Console.WriteLine(DecTree(bt));
            BinNode<int> dec = new BinNode<int>(new BinNode<int>(1), 2, null);
            Console.WriteLine(DecTree(dec));

            Console.WriteLine("Equal children:");
            Console.WriteLine(EqualChildren(bt));
            BinNode<int> eq = new BinNode<int>(new BinNode<int>(new BinNode<int>(5), 10, new BinNode<int>(5)), 22, new BinNode<int>(new BinNode<int>(6), 12, new BinNode<int>(6)));
            Console.WriteLine(EqualChildren(eq));

            Console.WriteLine("Organized tree:");
            Console.WriteLine(OrganizedTree(bt));
            BinNode<int> org = new BinNode<int>(new BinNode<int>(-1), 2, new BinNode<int>(3));
            Console.WriteLine(OrganizedTree(org));

            Console.WriteLine("X tree:");
            Console.WriteLine(X_Tree(bt, 5));
            BinNode<int> x_tree = new BinNode<int>(new BinNode<int>(5), 5, new BinNode<int>(5));
            Console.WriteLine(X_Tree(x_tree, 5));

            Console.WriteLine("X < Y tree:");
            Console.WriteLine(XY_Tree(bt, 5, 7));
            Console.WriteLine(XY_Tree(bt, 0, 11));

            Console.WriteLine("Right-Left tree:");
            Console.WriteLine(RightLeftTree(bt));
            BinNode<int> r_l_tree = new BinNode<int>(new BinNode<int>(null, 5, new BinNode<int>(5)), 5, null);
            Console.WriteLine(RightLeftTree(r_l_tree));

            Console.WriteLine("Print by layers:");
            PrintByLayers(bt);

            Console.Read();
        }

        private static int SumOfLeavesValues(BinNode<int> bt) // 1
        {
            if (bt == null)
            {
                return 0;
            }
            if (!bt.HasLeft() && !bt.HasRight())
            {
                return SumOfLeavesValues(bt.Left) + SumOfLeavesValues(bt.Right) + bt.Value;
            }
            return SumOfLeavesValues(bt.Left) + SumOfLeavesValues(bt.Right);
        }

        private static int NumOfLeaves(BinNode<int> bt) // 2
        {
            if (bt == null)
            {
                return 0;
            }
            if (!bt.HasLeft() && !bt.HasRight())
            {
                return NumOfLeaves(bt.Left) + NumOfLeaves(bt.Right) + 1;
            }
            return NumOfLeaves(bt.Left) + NumOfLeaves(bt.Right);
        }

        private static int SumOfRightChildren(BinNode<int> bt) // 3
        {
            if (bt == null)
            {
                return 0;
            }
            if (bt.HasRight())
            {
                return SumOfRightChildren(bt.Left) + SumOfRightChildren(bt.Right) + bt.Right.Value;
            }
            return SumOfRightChildren(bt.Left) + SumOfRightChildren(bt.Right);
        }

        private static bool BalancedTree(BinNode<int> bt) // 4
        {
            return SumOfTree(bt.Left) == SumOfTree(bt.Right);
        }

        public static int SumOfTree(BinNode<int> bt) // 4
        {
            return bt == null ? 0 : SumOfTree(bt.Left) + SumOfTree(bt.Right) + bt.Value;
        }

        private static bool BalancedTree2(BinNode<int> bt) // 5
        {
            if (bt == null)
            {
                return true;
            }
            if (BalancedTree(bt))
            {
                return BalancedTree2(bt.Left) && BalancedTree2(bt.Right);
            }
            return false;
        }

        private static bool DecTree(BinNode<int> bt) // 6
        {
            if ((!bt.HasLeft() && !bt.HasRight()) || bt == null)
            {
                return true;
            }
            if (bt.HasLeft() && bt.HasRight())
            {
                return DecTree(bt.Left) && DecTree(bt.Right) && bt.Value >= bt.Left.Value && bt.Value >= bt.Right.Value;
            }
            else if (!bt.HasLeft() && bt.HasRight())
            {
                return DecTree(bt.Right) && bt.Value >= bt.Right.Value;
            }
            else
            {
                return DecTree(bt.Left) && bt.Value >= bt.Left.Value;
            }
        }

        private static bool EqualChildren(BinNode<int> bt) // Second 6 (Mistake in Page 18 leading to two 6 questions)
        {
            if (bt == null || (!bt.HasLeft() && !bt.HasRight()))
            {
                return true;
            }
            if (bt.HasLeft() && bt.HasRight())
            {
                if (bt.Value == (bt.Left.Value + bt.Right.Value))
                {
                    return EqualChildren(bt.Left) && EqualChildren(bt.Right);
                }
            }
            else if (bt.HasLeft() && !bt.HasRight())
            {
                if (bt.Value == bt.Left.Value)
                {
                    return EqualChildren(bt.Left);
                }
            }
            else if (!bt.HasLeft() && bt.HasRight())
            {
                if (bt.Value == bt.Right.Value)
                {
                    return EqualChildren(bt.Right);
                }
            }
            return false;
        }

        private static bool OrganizedTree(BinNode<int> bt) // 7
        {
            if (bt == null)
            {
                return true;
            }
            if (bt.HasLeft())
            {
                if (bt.Left.Value >= 0)
                {
                    return false;
                }
            }
            if (bt.HasRight())
            {
                if (bt.Right.Value < 0)
                {
                    return false;
                }
            }
            return OrganizedTree(bt.Left) && OrganizedTree(bt.Right);
        }

        private static bool X_Tree(BinNode<int> bt, int x) // 8
        {
            if (bt == null)
            {
                return true;
            }
            return bt.Value == x && X_Tree(bt.Left, x) && X_Tree(bt.Right, x);
        }

        private static bool XY_Tree(BinNode<int> bt, int x, int y) // 9
        {
            if (bt == null)
            {
                return true;
            }
            return (x <= bt.Value && bt.Value <= y) && XY_Tree(bt.Left, x, y) && XY_Tree(bt.Right, x, y);
        }

        private static bool RightLeftTree(BinNode<int> bt) // 10
        {
            if (bt == null)
            {
                return true;
            }
            if (!bt.HasLeft() && !bt.HasRight())
            {
                return true;
            }
            if (bt.HasLeft() && !bt.HasRight())
            {
                if (!bt.Left.HasLeft() && !bt.Left.HasRight())
                {
                    return RightLeftTree(bt.Left);
                }
                return bt.Left.HasRight() && !bt.Left.HasLeft() && RightLeftTree(bt.Left);
            }
            if (!bt.HasLeft() && bt.HasRight())
            {
                if (!bt.Right.HasLeft() && !bt.Right.HasRight())
                {
                    return RightLeftTree(bt.Right);
                }
                return !bt.Right.HasRight() && bt.Right.HasLeft() && RightLeftTree(bt.Right);
            }
            return false;
        }

        private static void PrintByLayers(BinNode<int> bt) // 11
        {
            Queue<BinNode<int>> temp = new Queue<BinNode<int>>();
            temp.Insert(bt);
            BinNode<int> iter = null;
            while (!temp.IsEmpty())
            {
                iter = temp.Remove();
                Console.Write(iter.Value + " ");
                if (iter.HasLeft())
                {
                    temp.Insert(iter.Left);
                }
                if (iter.HasRight())
                {
                    temp.Insert(iter.Right);
                }
            }
        }
    }
}
