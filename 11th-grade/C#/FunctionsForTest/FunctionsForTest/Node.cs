using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionsForTest
{
    class Node<T>
    {
        private T value;
        private Node<T> next;

        public T Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        internal Node<T> Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }

        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }

        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }

        public bool HasNext()
        {
            return Next != null;
        }

        public override string ToString()
        {
            return "" + value;
        }
    }
}
