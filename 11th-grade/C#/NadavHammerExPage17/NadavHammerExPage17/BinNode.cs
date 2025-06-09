using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage17
{
    class BinNode<T>
    {
        private T value;
        private BinNode<T> right;
        private BinNode<T> left;

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

        internal BinNode<T> Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }

        internal BinNode<T> Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        public BinNode(T x)
        {
            this.left = null;
            this.value = x;
            this.right = null;
        }

        public BinNode(BinNode<T> left, T x, BinNode<T> right)
        {
            this.left = left;
            this.value = x;
            this.right = right;
        }

        public bool HasLeft()
        {
            return left != null;
        }

        public bool HasRight()
        {
            return right != null;
        }

        public override string ToString()
        {
            return "" + this.value;
        }
    }
}
