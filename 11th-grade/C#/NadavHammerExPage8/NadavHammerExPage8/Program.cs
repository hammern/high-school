using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage8
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass("Yud Alef - Computers");

            Student student = new Student("123456789", "Dorf");
            myClass.AddStudent(student);
            student = new Student("548239142", "Benji");
            myClass.AddStudent(student);
            student = new Student("984673217", "Roy");
            myClass.AddStudent(student);
            student = new Student("235839646", "Amit");
            myClass.AddStudent(student);
            student = new Student("583964728", "Nadav");
            myClass.AddStudent(student);

            // 123456789 - Dorf
            myClass.InsertGradeByID("123456789", 99);
            myClass.InsertGradeByID("123456789", 78);
            myClass.InsertGradeByID("123456789", 15);
            // 548239142 - Benji
            myClass.InsertGradeByID("548239142", 13);
            myClass.InsertGradeByID("548239142", 89);
            myClass.InsertGradeByID("548239142", 90);
            // 984673217 - Roy
            myClass.InsertGradeByID("984673217", 67);
            myClass.InsertGradeByID("984673217", 43);
            myClass.InsertGradeByID("984673217", 40);
            // 235839646 - Amit
            myClass.InsertGradeByID("235839646", 23);
            myClass.InsertGradeByID("235839646", 46);
            myClass.InsertGradeByID("235839646", 78);
            // 583964728 - Nadav
            myClass.InsertGradeByID("583964728", 100);
            myClass.InsertGradeByID("583964728", 100);
            myClass.InsertGradeByID("583964728", 100);

            Console.WriteLine("Averages:");
            myClass.PrintAverages();

            Console.WriteLine("Fails:");
            MyClass failedClass = new MyClass("Yud Alef - Fails");
            Node<Student> fails = myClass.Fails();

            while (fails != null)
            {
                failedClass.AddStudent(fails.Value);
                fails = fails.Next;
            }
            failedClass.PrintAverages();
            
            Console.Read();
        }
    }
}
