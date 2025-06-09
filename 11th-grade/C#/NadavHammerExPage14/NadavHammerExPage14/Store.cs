using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage14
{
    class Store
    {
        private Node<Product> products;

        public Store(Node<Product> products, int limit)
        {
            this.products = products;
        }

        public int ProductsValue()
        {
            int value = 0;

            Node<Product> iter = products;
            while (iter != null)
            {
                value += iter.Value.Price * iter.Value.Amount;
                iter = iter.Next;
            }
            return value;
        }

        public Node<string> Limit(int limit)
        {
            Node<string> lessProducts = null;
            Node<Product> iter = products;

            while (iter != null)
            {
                if (iter.Value.Amount < limit)
                {
                    lessProducts = new Node<string>(iter.Value.Model, lessProducts);
                }
                iter = iter.Next;
            }
            return lessProducts;
        }
    }
}
