using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage15
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentSystem paymentSystem = new PaymentSystem();
            Console.WriteLine("Payment System:");

            Node<Project> projects = new Node<Project>(new Project("E", 6000));
            projects = new Node<Project>(new Project("F", 1000), projects);
            paymentSystem.AddWorker(new ProjectWorker("ProjectWorker", "B", "123456780", projects));

            projects = new Node<Project>(new Project("C", 500));
            projects = new Node<Project>(new Project("D", 1000), projects);
            paymentSystem.AddWorker(new ProjectWorker("ProjectWorker", "A", "123456781", projects));

            paymentSystem.AddWorker(new Manager("Manager", "B", "123456782", 6000, 1500));
            paymentSystem.AddWorker(new Manager("Manager", "A", "123456783", 5000, 500));

            paymentSystem.AddWorker(new RegularWageWorker("RegularWageWorker", "B", "123456784", 7000));
            paymentSystem.AddWorker(new RegularWageWorker("RegularWageWorker", "A", "123456785", 5000));

            paymentSystem.AddWorker(new PartTimeWorker("PartTimeWorker", "B", "123456786", 30, 50));
            paymentSystem.AddWorker(new PartTimeWorker("PartTimeWorker", "A", "123456787", 40, 100));

            paymentSystem.AddWorker(new Worker("Worker", "B", "123456788"));
            paymentSystem.AddWorker(new Worker("Worker", "A", "123456789"));

            paymentSystem.PrintPayments();
            Console.Read();
        }
    }
}
