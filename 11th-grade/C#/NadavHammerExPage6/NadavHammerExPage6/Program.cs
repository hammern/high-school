using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage6
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> n1 = new Node<int>(1);
            Node<int> n2 = new Node<int>(2);

            Random rand = new Random();

            int num = 0;

            n1.Value = rand.Next(10);
            n2.Value = rand.Next(10);

            for (int i = 0; i < 5; i++)
            {
                num = rand.Next(10);
                Add(n1, num);
                num = rand.Next(10);
                Add(n2, num);
            }

            Console.WriteLine("Node 1:");
            PrintAll(n1);
            int numberToSearch = 5;
            int? index = FindIndexOfNum(n1, numberToSearch);
            Console.WriteLine("Checked number: {0}", numberToSearch);
            if (index != null)
            {
                Console.WriteLine("Exists in index {0}", index);
            }
            else
            {
                Console.WriteLine("Number does not exist");
            }

            Console.WriteLine("\nNode 2:");
            PrintAll(n2);
            int removeIndex = 0;
            Console.WriteLine("Removing number in index {0}", removeIndex);
            n2 = RemoveInIndex(n2, removeIndex);
            Console.WriteLine("Node 2 after removal:");
            PrintAll(n2);

            Console.WriteLine("\nNo Duplicates:");
            n1 = RemoveDuplicates(n1, n2);
            PrintAll(n1);

            Console.WriteLine("\nTriplets Ex:");
            Node<int> empty = null;
            Console.WriteLine("Empty Node:");
            Console.WriteLine(IsTriplet(empty));
            Console.WriteLine("Node not split by 3:");
            Node<int> not3 = new Node<int>(0);
            Add(not3, 16);
            Console.WriteLine(IsTriplet(not3));
            Console.WriteLine("Split by three but items not equal:");
            Node<int> notEqual = new Node<int>(1);
            Add(notEqual, 2);
            Add(notEqual, 3);
            Add(notEqual, 1);
            Add(notEqual, 3);
            Add(notEqual, 2);
            Console.WriteLine(IsTriplet(notEqual));
            Console.WriteLine("Example Node:");
            Node<int> L = new Node<int>(2);
            Add(L, 5);
            Add(L, 3);
            Add(L, 7);
            Add(L, 2);
            Add(L, 5);
            Add(L, 3);
            Add(L, 7);
            Add(L, 2);
            Add(L, 5);
            Add(L, 3);
            Add(L, 7);
            Console.WriteLine(IsTriplet(L));

            Console.Read();
        }

        private static void PrintAll(Node<int> n)
        {
            while (n != null)
            {
                Console.WriteLine(n.ToString());
                n = n.Next;
            }
        }
        private static void Add(Node<int> n, int rand)
        {
            while (n.HasNext())
            {
                n = n.Next;
            }

            Node<int> newNode = new Node<int>(rand);
            n.Next = newNode;
        }

        private static int? FindIndexOfNum(Node<int> pos, int num)
        {
            int i = 0;

            while (pos != null)
            {
                if (pos.Value == num)
                {
                    return i;
                }

                pos = pos.Next;
                i++;
            }
            return null;
        }

        private static Node<int> RemoveInIndex(Node<int> pos, int index)
        {
            Node<int> first = pos;
            Node<int> prev = null;
            int i = 0;

            while (pos != null)
            {
                if (i == index)
                {
                    if (pos.HasNext())
                    {
                        Node<int> next = pos.Next;
                        pos.Value = next.Value;
                        pos.Next = next.Next;
                        next = null;
                    }
                    else
                    {
                        if (prev != null)
                        {
                            prev.Next = null;
                        }
                        else
                        {
                            first = null;
                        }
                        pos = null;
                    }

                    break;
                }

                prev = pos;
                pos = pos.Next;
                i++;
            }

            return first;
        }

        private static Node<int> RemoveDuplicates(Node<int> n1, Node<int> n2)
        {
            Node<int> temp = n1;
            Node<int> next = null;
            int i = 0;

            while (n1 != null)
            {
                next = n1.Next;
                if (Exists(n2, n1.Value))
                {
                    temp = RemoveInIndex(temp, i);
                    if (temp == null)
                    {
                        return null;
                    }
                    i--;
                }

                n1 = next;
                i++;
            }

            return temp;
        }

        private static bool Exists(Node<int> n, int num)
        {
            while (n != null)
            {
                if (n.Value == num)
                {
                    return true;
                }

                n = n.Next;
            }

            return false;
        }

        private static bool IsTriplet(Node<int> n)
        {
            int count = CountNodes(n);

            if ((n == null) || (count % 3 != 0))
            {
                return false;
            }

            Node<int> n1 = n;
            Node<int> n2 = SkipNode(n1, count / 3);
            Node<int> n3 = SkipNode(n2, count / 3);

            for (int i = 0; i < (count / 3); i++)
            {
                if (!(n1.Value == n2.Value && n1.Value == n3.Value && n2.Value == n3.Value))
                {
                    return false;
                }
                n1 = n1.Next;
                n2 = n2.Next;
                n3 = n3.Next;
            }
            return true;
        }

        private static int CountNodes(Node<int> n)
        {
            int i = 0;

            while (n != null)
            {
                n = n.Next;
                i++;
            }

            return i;
        }

        private static Node<int> SkipNode(Node<int> n, int i)
        {
            int j = 0;

            while (n != null && j < i)
            {
                n = n.Next;
                j++;
            }
            return n;
        }
    }
}
