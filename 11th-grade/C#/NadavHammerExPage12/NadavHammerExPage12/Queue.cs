using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage12
{
    public class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;

        public Queue()
        {
            this.first = null;
            this.last = null;
        }

        public void Insert(T x)
        {
            Node<T> temp = new Node<T>(x);
            if (first == null)
                first = temp;
            else
                last.Next = temp;
            last = temp;
        }

        public T Remove()
        {
            T x = first.Value;
            first = first.Next;
            if (first == null)
                last = null;
            return x;
        }

        public T head()
        {
            return first.Value;
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public override string ToString()
        {
            string temp = "[";
            Node<T> pos = this.first;
            while (pos != null)
            {
                temp += " " + pos.Value.ToString();
                pos = pos.Next;
            }
            return temp + " ]";
        }
    }
}
