using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace School_Manager
{
    class StudentsList
    {
        private Student[] Students = new Student[0];

        public void Save()
        {
            string Lines = "";
            foreach (Student student in Students)
            {
                Lines += String.Format("{0},{1},{2},{3},{4},{5}\n", student.FirstName, student.LastName, student.ID,
                    student.Class, student.Major, String.Join(":", student.Subjects));
            }
            File.WriteAllText("Students.txt", Lines);
        }

        public void Load()
        {
            string[] Lines = File.ReadAllLines("Students.txt");
            foreach (string Line in Lines)
            {
                Student student = new Student();
                string[] Items = Line.Split(',');
                student.FirstName = Items[0];
                student.LastName = Items[1];
                student.ID = Items[2];
                student.Class = Items[3];
                student.Major = Items[4];
                student.Subjects = Items[5].Split(':');

                AddStudent(student);
            }
        }

        public void AddStudent(Student student)
        {
            Array.Resize(ref Students, Students.Length + 1);
            Students[Students.Length - 1] = student;
        }

        public void UpdateStudent(Student student)
        {
            for (int i = 0; i < Students.Length; i++)
            {
                if (student == Students[i])
                {
                    Students[i] = student;
                }
            }
        }

        public void UpdateStudent(int index, Student student)
        {
            Students[index] = student;
        }


        public void RemoveStudent(Student student)
        {
            for (int i = 0; i < Students.Length; i++)
            {
                if (student == Students[i])
                {
                    if (i < Students.Length - 1)
                    {
                        Array.Copy(Students, i + 1, Students, i, Students.Length - 1 + i);
                    }
                    Array.Resize(ref Students, Students.Length - 1);
                    break;
                }
            }
        }

        public void RemoveStudent(int index)
        {
            RemoveStudent(Students[index]);
        }

        public int Length()
        {
            return Students.Length;
        }

        public Student GetStudent(int index)
        {
            return Students[index];
        }

        public Student GetStudentByName(string name)
        {
            Student student;
            string fullName;
            for (int i = 0; i < Students.Length; i++)
            {
                student = Students[i];
                fullName = String.Format("{0} {1}", student.FirstName, student.LastName);
                if (fullName == name)
                {
                    return student;
                }
            }
            return null;
        }

        public class FirstNameCompare : IComparer
        {
            private bool m_Ascending;

            public FirstNameCompare(bool Ascending)
            {
                m_Ascending = Ascending;
            }

            int IComparer.Compare(Object x, Object y)
            {
                if (m_Ascending)
                {
                    return ((new CaseInsensitiveComparer()).Compare(((Student)x).FirstName, ((Student)y).FirstName));
                }
                else
                {
                    return ((new CaseInsensitiveComparer()).Compare(((Student)y).FirstName, ((Student)x).FirstName));
                }
            }
        }

        public class SecondNameCompare : IComparer
        {
            private bool m_Ascending;

            public SecondNameCompare(bool Ascending)
            {
                m_Ascending = Ascending;
            }

            int IComparer.Compare(Object x, Object y)
            {
                if (m_Ascending)
                {
                    return ((new CaseInsensitiveComparer()).Compare(((Student)x).LastName, ((Student)y).LastName));
                }
                else
                {
                    return ((new CaseInsensitiveComparer()).Compare(((Student)y).LastName, ((Student)x).LastName));
                }
            }
        }

        public class IDCompare : IComparer
        {
            private bool m_Ascending;

            public IDCompare(bool Ascending)
            {
                m_Ascending = Ascending;
            }

            int IComparer.Compare(Object x, Object y)
            {
                if (m_Ascending)
                {
                    return ((new CaseInsensitiveComparer()).Compare(((Student)x).ID, ((Student)y).ID));
                }
                else
                {
                    return ((new CaseInsensitiveComparer()).Compare(((Student)y).ID, ((Student)x).ID));
                }
            }
        }

        public void SortByName(bool Ascending)
        {
            Array.Sort(Students, new FirstNameCompare(Ascending));
        }

        public void SortByLastName(bool Ascending)
        {
            Array.Sort(Students, new SecondNameCompare(Ascending));
        }

        public void SortByID(bool Ascending)
        {
            Array.Sort(Students, new IDCompare(Ascending));
        }

        public string GetNumOfStudents(ClassRoom classRoom)
        {
            int count = 0;
            foreach (Student student in Students)
            {
                if (student.Class == classRoom.ClassName)
                {
                    count++;
                }
            }
            return count.ToString();
        }
    }
}
