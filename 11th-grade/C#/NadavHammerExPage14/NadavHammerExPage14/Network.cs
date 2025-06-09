using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage14
{
    class Network
    {
        private Store[] stores;
        private int index;

        public void AddStore(Store store)
        {
            if (index < 50)
            {
                stores[index++] = store;
            }
        }

        public int NetworkProductsValue()
        {
            int value = 0;

            for (int i = 0; i < this.index; i++)
            {
                value += stores[i].ProductsValue();
            }
            return value;
        }

        public void Limit(int limit)
        {
            int lastLimit = limit;
            Node<string> Models = new Node<string>("");
            for (int i = 0; i < stores.Length; i++)
            {
                if ((lastLimit - GetNodeLength(stores[i].Limit(lastLimit)) > 0))
                {
                    PrintNode(stores[i].Limit(lastLimit));
                    lastLimit -= GetNodeLength(stores[i].Limit(lastLimit));
                }
            }
        }

        public void PrintNode(Node<string> n)
        {
            while (n != null)
            {
                Console.WriteLine(n.Value);
                n = n.Next;
            }
        }

        public int GetNodeLength(Node<string> n)
        {
            Node<string> newNode = Copy(n);
            int count = 0;
            while (newNode != null)
            {
                newNode = newNode.Next;
                count++;
            }
            return count;
        }

        public Node<string> Copy(Node<string> n)
        {
            Node<string> newNode = new Node<string>("");
            Node<string> pos = n;
            while (pos != null)
            {
                AddNode(newNode, pos.Value);
                pos = pos.Next;
            }
            return newNode;
        }

        public void AddNode(Node<string> node, string str)
        {
            while (node.Next != null)
            {
                node = node.Next;
            }
            node.Next = new Node<string>(str);
        }
    }
}
