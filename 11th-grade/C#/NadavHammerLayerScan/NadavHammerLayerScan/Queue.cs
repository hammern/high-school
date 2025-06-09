using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerLayerScan
{
    class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;

        internal Node<T> First
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

        internal Node<T> Last
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
            this.First = null;
            this.Last = null;
        }

        public bool IsEmpty()
        {
            return this.First == null;
        }

        public void Insert(T x)
        {
            Node<T> temp = new Node<T>(x);
            if (First == null)
            {
                First = temp;
            }
            else
            {
                Last.Next = temp;
            }
            Last = temp;
        }

        public T Remove()
        {
            T x = this.First.Value;
            this.First = this.First.Next;
            if (First == null)
            {
                Last = null;
            }
            return x;
        }

        public T Head()
        {
            return this.First.Value;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                return "[]";
            }
            Node<T> pos = this.First;
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
