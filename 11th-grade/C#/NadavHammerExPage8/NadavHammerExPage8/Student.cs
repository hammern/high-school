using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage8
{
    class Student
    {
        private string id;
        private string name;
        Node<int> grades;

        public Student(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        internal Node<int> Grades
        {
            get
            {
                return grades;
            }
            set
            {
                grades = value;
            }
        }

        public void AddGrade(int grade)
        {
            if (grades == null)
            {
                grades = new Node<int>(grade);
            }
            else
            {
                Node<int> iter = grades;
                while (iter.HasNext())
                {
                    iter = iter.Next;
                }

                Node<int> newNode = new Node<int>(grade);
                iter.Next = newNode;
            }
        }

        public int Average()
        {
            int sum = 0;
            int count = 0;
            Node<int> iter = grades;

            while (iter != null)
            {
                sum += iter.Value;
                count++;
                iter = iter.Next;
            }

            return sum / count;
        }
    }
}
