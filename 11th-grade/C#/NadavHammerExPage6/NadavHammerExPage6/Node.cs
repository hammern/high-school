using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage6
{
    class Node<T>
    {
        private int value;
        private Node<T> next;

        public int Value { get => value; set => this.value = value; }

        internal Node<T> Next { get => next; set => next = value; }

        public Node(int value)
        {
            this.value = value;
            this.next = null;
        }

        public Node(int value, Node<T> next)
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
