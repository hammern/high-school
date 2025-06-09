using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage7
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Mazda", "5", "123", 49000, "1970");
            Node<Car> cars = new Node<Car>(car);

            car = new Car("Mazda", "10", "345", 99000, "2000");
            Add(cars, car);
            car = new Car("Ferari", "Speed", "678", 1000000, "2019");
            Add(cars, car);
            car = new Car("Benji", "5", "901", 110000, "9999");
            Add(cars, car);
            car = new Car("Benji", "5", "5666", 110000, "9999");
            Add(cars, car);
            car = new Car("Attias", "5", "246", 15000, "2003");
            Add(cars, car);

            Console.WriteLine("Cars under 50000:");
            CheckLowPrice(cars);

            Console.WriteLine("License Plate Of Benji:");
            Node<string> licensePlatesOfCompany = CheckLicensePlatesOfCompany(cars, "Benji");
            PrintAll(licensePlatesOfCompany);

            Console.Read();
        }

        private static void Add(Node<Car> n, Car car) // O(n)
        {
            while (n.HasNext())
            {
                n = n.Next;
            }

            Node<Car> newNode = new Node<Car>(car);
            n.Next = newNode;
        }
        private static void PrintAll(Node<string> n) // O(n)
        {
            while (n != null)
            {
                Console.WriteLine(n.ToString());
                n = n.Next;
            }
        }

        private static void CheckLowPrice(Node<Car> cars) // O(n)
        {
            while (cars != null)
            {
                if (cars.Value.Price < 50000)
                {
                    Console.WriteLine(cars.Value.LicensePlate + ", " + cars.Value.Company + ", " + cars.Value.Model);
                }
                cars = cars.Next;
            }
        }

        private static Node<string> CheckLicensePlatesOfCompany(Node<Car> cars, string company) // O(n)
        {
            Node<string> licensePlatesOfCompany = new Node<string>("");
            bool first = true;

            while (cars != null)
            {
                if (cars.Value.Company == company)
                {
                    if (first)
                    {
                        licensePlatesOfCompany.Value = cars.Value.LicensePlate;
                        first = false;
                    }
                    else
                    {
                        licensePlatesOfCompany.Next = new Node<string>(cars.Value.LicensePlate);
                    }
                }
                cars = cars.Next;
            }
            return licensePlatesOfCompany;
        }
    }
}
