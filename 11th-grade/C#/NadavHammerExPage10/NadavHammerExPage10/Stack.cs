using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage10
{
    class Stack<T>
    {
        private Node<T> head;

        internal Node<T> Head
        {
            get
            {
                return head;
            }
            set
            {
                head = value;
            }
        }

        public Stack()
        {
            this.head = null;
        }

        public bool IsEmpty()
        {
            return this.head == null;
        }

        public void Push(T x)
        {
            this.head = new Node<T>(x, this.head);
        }

        public T Pop()
        {
            T x = this.head.Value;
            this.head = this.head.Next;
            return x;
        }

        public T Top()
        {
            return this.head.Value;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
