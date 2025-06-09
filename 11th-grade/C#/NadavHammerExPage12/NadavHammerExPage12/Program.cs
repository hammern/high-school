using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage12
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] specialites = { "Family", "Kids", "Orthopedia" };
            Random rand = new Random(25565);

            Office office = new Office("clalit");

            office.AddDoctor("Amit", specialites[0]);
            office.AddDoctor("Dorf", specialites[1]);
            office.AddDoctor("Roy", specialites[2]);
            office.AddDoctor("Omer", specialites[2]);
            Console.WriteLine();

            office.AddApp("Amit", new Patient("123", "Benji", 1974, "male"), DateTime.Today, rand.Next(0, 24).ToString() + ":" + rand.Next(10, 60).ToString());
            office.AddApp("Amit", new Patient("234", "Noa", 2003, "female"), DateTime.Today, rand.Next(0, 24).ToString() + ":" + rand.Next(10, 60).ToString());
            office.AddApp("Amit", new Patient("345", "Itamar", 2005, "male"), DateTime.Today, rand.Next(0, 24).ToString() + ":" + rand.Next(10, 60).ToString());

            office.AddApp("Dorf", new Patient("456", "Matan", 1974, "male"), DateTime.Today, rand.Next(0, 24).ToString() + ":" + rand.Next(10, 60).ToString());
            office.AddApp("Dorf", new Patient("567", "Izik", 2003, "male"), DateTime.Today, rand.Next(0, 24).ToString() + ":" + rand.Next(10, 60).ToString());
            office.AddApp("Dorf", new Patient("678", "Itamar", 2005, "male"), DateTime.Today, rand.Next(0, 24).ToString() + ":" + rand.Next(10, 60).ToString());
            office.AddApp("Dorf", new Patient("789", "Benji", 1974, "male"), DateTime.Today, rand.Next(0, 24).ToString() + ":" + rand.Next(10, 60).ToString());

            office.AddApp("Roy", new Patient("890", "Izi", 2003, "female"), DateTime.Today, rand.Next(0, 24).ToString() + ":" + rand.Next(0, 60).ToString());
            office.AddApp("Roy", new Patient("890", "Yali", 2003, "female"), DateTime.Today, rand.Next(0, 24).ToString() + ":" + rand.Next(0, 60).ToString());

            office.AddApp("Omer", new Patient("901", "Attias", 2003, "male"), DateTime.Today, rand.Next(0, 24).ToString() + ":" + rand.Next(0, 60).ToString());

            Console.WriteLine("\nTreatments:");
            Console.WriteLine("Amit finished appointment:");
            Console.WriteLine(office.GetCurrentPatient("Amit"));
            Console.WriteLine("Dorf finished appointment:");
            Console.WriteLine(office.GetCurrentPatient("Dorf"));
            Console.WriteLine("Roy finished appointment:");
            Console.WriteLine(office.GetCurrentPatient("Roy"));
            Console.WriteLine("Omer finished appointment:");
            Console.WriteLine(office.GetCurrentPatient("Omer"));

            Console.WriteLine("\nFree doctors:");
            office.PrintAllFreeDoctors();

            Console.WriteLine("\nLeast amount of patients:");
            Console.WriteLine(office.GetLeastSpeciality(specialites[2]) + " is the Orthopedia doctor with the least amount of patients");

            Console.Read();
        }
    }
}
