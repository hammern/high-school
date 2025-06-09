using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerBinarySearchTree
{
    class Stack<T>
    {
        private Node<T> head;

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
            if (IsEmpty())
            {
                return "[]";
            }
            Stack<T> temp = new Stack<T>();
            while (!this.IsEmpty())
            {
                temp.Push(this.Pop());
            }
            string str = "[";
            while (!temp.IsEmpty())
            {
                str = str + temp.Top() + ",";
                this.Push(temp.Pop());
            }
            str = str.Substring(0, str.Length - 1) + "]";
            return str;
        }
    }
}
