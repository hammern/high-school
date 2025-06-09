using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionsForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // remember to think and plan before starting to code
            // think of all the cases: the start, middle and the end of the node

            // All Functions:
            /*
             NodeLoop
             Add
             Remove
             FindIndexOfNum
             */
        }

        public static void NodeLoop(Node<string> node)
        {
            Node<string> iter = node;

            while (iter != null)
            {
                // 
                iter = iter.Next;
            }
        }

        public void Add(/*(add if not in class) Node<string> node, */string value)
        {
            if (node == null)
            {
                node = new Node<string>(value);
            }
            else
            {
                Node<string> iter = node;
                while (iter.HasNext())
                {
                    iter = iter.Next;
                }

                Node<string> newNode = new Node<string>(value);
                iter.Next = newNode;
            }
            return members; // add if not in class
        }

        private static Node<string> Remove(Node<string> node, string item)
        {
            Node<string> first = node;
            Node<string> prev = null;
            // if by index:
            // int i = 0;

            while (node != null)
            {
                if (node.Value == item) // replace with i == index
                {
                    if (node.HasNext())
                    {
                        Node<string> next = node.Next;
                        node.Value = next.Value;
                        node.Next = next.Next;
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
                        node = null;
                    }

                    break;
                }

                prev = node;
                node = node.Next;
                // i++
            }

            return first;
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
    }
}
