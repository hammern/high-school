using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage18
{
    class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;

        public Node<T> First
        {
            get
            {
                return first;
            }

            set
            {
                first = value;
            }
        }

        public Node<T> Last
        {
            get
            {
                return last;
            }

            set
            {
                last = value;
            }
        }


        public Queue()
        {
            this.first = null;
            this.last = null;
        }

        public bool IsEmpty()
        {
            return this.first == null;
        }

        public void Insert(T x)
        {
            Node<T> temp = new Node<T>(x);
            if (first == null)
            {
                first = temp;
            }
            else
            {
                last.Next = temp;
            }
            last = temp;
        }

        public T Remove()
        {
            T x = this.first.Value;
            this.first = this.first.Next;
            if (first == null)
            {
                last = null;
            }
            return x;
        }

        public T Head()
        {
            return this.first.Value;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                return "[]";
            }
            Node<T> pos = this.first;
            string temp = "[";
            while (pos != null)
            {
                temp += " " + pos.Value.ToString();
                pos = pos.Next;
            }
            return temp + " ]";
        }
    }
}
