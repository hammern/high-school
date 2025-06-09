using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage8
{
    class MyClass
    {
        private string name;
        private Node<Student> students;

        public MyClass(string name)
        {
            this.name = name;
        }

        public void AddStudent(Student student)
        {
            if (students == null)
            {
                students = new Node<Student>(student);
            }
            else
            {
                Node<Student> iter = students;
                while (iter.HasNext())
                {
                    iter = iter.Next;
                }

                Node<Student> newNode = new Node<Student>(student);
                iter.Next = newNode;
            }
        }

        public void InsertGradeByID(string id, int grade)
        {
            Node<Student> iter = students;

            while (iter != null)
            {
                if (iter.Value.Id == id)
                {
                    iter.Value.AddGrade(grade);
                    break;
                }
                iter = iter.Next;
            }
        }

        public void PrintAverages()
        {
            Node<Student> iter = students;

            while (iter != null)
            {
                Console.WriteLine(iter.Value.Name + " - " + iter.Value.Average());

                iter = iter.Next;
            }
        }

        public Node<Student> Fails()
        {
            Node<Student> fail = null;
            Node<Student> next = null;
            Node<Student> iter = students;

            while (iter != null)
            {
                if (iter.Value.Average() < 55)
                {
                    if (fail == null)
                    {
                        fail = new Node<Student>(iter.Value);
                        next = fail;
                    }
                    else
                    {
                        fail.Next = new Node<Student>(iter.Value);
                        next = fail.Next;
                    }
                }

                iter = iter.Next;
            }

            return fail;
        }
    }
}
