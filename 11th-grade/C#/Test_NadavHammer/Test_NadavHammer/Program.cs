using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_NadavHammer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Q1:");
            Queue<char> q = new Queue<char>();
            q.Insert('t');
            q.Insert('a');
            q.Insert('x');
            q.Insert('#');
            q.Insert('m');
            q.Insert('#');
            q.Insert('r');
            q.Insert('a');
            q.Insert('b');
            Console.WriteLine(q.ToString());
            Q1(q);
            Console.WriteLine(q.ToString());

            Console.WriteLine("Q2:");
            Stack<int> s = new Stack<int>();
            for (int i = 0; i < 5; i++)
            {
                s.Push(2);
                s.Push(1);
            }

            Console.WriteLine(s.ToString());
            Console.WriteLine(Q2(s));

            Stack<int> s2 = new Stack<int>();
            s2.Push(4);
            s2.Push(8);
            s2.Push(3);
            s2.Push(1);
            s2.Push(4);
            s2.Push(8);
            s2.Push(3);
            s2.Push(1);

            Console.WriteLine(s2.ToString());
            Console.WriteLine(Q2(s2));

            Stack<int> s3 = new Stack<int>();
            s3.Push(4);
            s3.Push(3);
            s3.Push(7);

            Console.WriteLine(s3.ToString());
            Console.WriteLine(Q2(s3));

            Console.WriteLine("Q3:");
            Node<int> lst1 = new Node<int>(6);
            lst1 = new Node<int>(32, lst1);
            lst1 = new Node<int>(5, lst1);
            lst1 = new Node<int>(7, lst1);
            lst1 = new Node<int>(4, lst1);

            Node<int> pos = lst1;
            Console.WriteLine("lst1:");
            while (pos != null)
            {
                Console.WriteLine(pos.GetValue());
                pos = pos.GetNext();
            }
            Node<TwoItems> lst2 = Q3B(lst1);
            Node<TwoItems> pos2 = lst2;
            Console.WriteLine("lst2:");
            while (pos2 != null)
            {
                Console.WriteLine(pos2.GetValue().Num1 + "," + pos2.GetValue().Num2);
                pos2 = pos2.GetNext();
            }

            Console.WriteLine("Q5:");
            Supermarket sp = new Supermarket();
            sp.AddToSupermarketQueue("Ido");
            sp.AddToSupermarketQueue("Dorf");
            sp.AddToSupermarketQueue("Benji");
            sp.AddToSupermarketQueue("Roy");
            sp.AddToSupermarketQueue("Attias");

            sp.Registers[3].EndOfShift = true;
            sp.ShiftEnded();

            Console.Read();
        }

        private static void Q1(Queue<char> s)
        {
            Queue<char> temp = new Queue<char>();
            char curr = s.Remove();
            char biggest = curr;

            while (!s.IsEmpty())
            {
                curr = s.Remove();
                if (curr == '#')
                {
                    temp.Insert(biggest);
                    biggest = 'a';
                }
                if (biggest < curr)
                {
                    biggest = curr;
                }
            }
            temp.Insert(biggest);
            while (!temp.IsEmpty())
            {
                s.Insert(temp.Remove());
            }
        }

        private static bool Q2(Stack<int> s)
        {
            Stack<int> iter = Copy(s);
            Node<int> temp = new Node<int>(iter.Pop());
            Node<int> iterOnTemp = null;

            while (temp.GetValue() != iter.Top())
            {
                iterOnTemp = temp;
                while (iterOnTemp.HasNext())
                {
                    iterOnTemp = iterOnTemp.GetNext();
                }
                Node<int> newNode = new Node<int>(iter.Pop());
                iterOnTemp.SetNext(newNode);
                if (iter.IsEmpty())
                {
                    return false;
                }
            }

            Node<int> pos = temp;
            while (!iter.IsEmpty())
            {
                if (pos == null)
                {
                    pos = temp;
                }
                if (pos.GetValue() != iter.Pop())
                {
                    return false;
                }
                pos = pos.GetNext();
            }
            return true;
        }

        private static Stack<int> Copy(Stack<int> s)
        {
            Stack<int> temp = new Stack<int>();
            Stack<int> copy = new Stack<int>();

            while (!s.IsEmpty())
            {
                temp.Push(s.Pop());
            }
            while (!temp.IsEmpty())
            {
                s.Push(temp.Top());
                copy.Push(temp.Pop());
            }
            return copy;
        }

        public static int LastAndRemove(Node<int> lst)
        {
            Node<int> iter = lst;
            Node<int> prev = new Node<int>(0, lst);
            while (iter.HasNext())
            {
                iter = iter.GetNext();
                prev = prev.GetNext();
            }
            int val = iter.GetValue();
            prev.SetNext(null);
            return val;
        }

        private static Node<TwoItems> Q3B(Node<int> lst1)
        {
            Node<TwoItems> lst2 = new Node<TwoItems>(new TwoItems(0, 0));
            Node<TwoItems> temp = lst2;
            int firstNum;
            int lastNum;
            while (lst1 != null)
            {
                lastNum = LastAndRemove(lst1);
                if (lst2 == null)
                {
                    firstNum = lastNum;
                }
                else
                {
                    firstNum = lst1.GetValue();
                    lst1 = lst1.GetNext();
                }
                while (temp.HasNext())
                {
                    temp = temp.GetNext();
                }
                temp.SetNext(new Node<TwoItems>(new TwoItems(firstNum, lastNum)));
                temp = lst2;
            }
            return lst2.GetNext();
        }
    }
}
