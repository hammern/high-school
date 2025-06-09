using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage15
{
    class PaymentSystem
    {
        Node<Worker> workers;

        public void AddWorker(Worker worker)
        {
            workers = new Node<Worker>(worker, workers);
        }

        public void PrintPayments()
        {
            Node<Worker> iter = workers;

            while (iter != null)
            {
                Console.WriteLine("{0} {1}, ID: {2}, Pay: {3}", iter.Value.FirstName, iter.Value.LastName, iter.Value.Id, iter.Value.Payment());
                iter = iter.Next;
            }
        }
    }
}
