using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace School_Manager
{
    class TeacherList
    {
        private Teacher[] Teachers = new Teacher[0];

        public void Save()
        {
            string Lines = "";
            foreach (Teacher teacher in Teachers)
            {
                Lines += String.Format("{0},{1},{2},{3},{4},{5},{6},{7}\n", teacher.FirstName, teacher.LastName, teacher.ID, teacher.PayCheck,
                    teacher.DateJoined, teacher.WeeklyHours, teacher.HomeRoomTeacher, String.Join(":", teacher.Subjects));
            }
            File.WriteAllText("Teachers.txt", Lines);
        }

        public void Load()
        {
            string[] Lines = File.ReadAllLines("Teachers.txt");
            foreach (string Line in Lines)
            {
                Teacher teacher = new Teacher();
                string[] Items = Line.Split(',');
                teacher.FirstName = Items[0];
                teacher.LastName = Items[1];
                teacher.ID = Items[2];
                teacher.PayCheck = Items[3];
                teacher.DateJoined = Items[4];
                teacher.WeeklyHours = Items[5];
                teacher.HomeRoomTeacher = Items[6];
                teacher.Subjects = Items[7].Split(':');

                AddTeacher(teacher);
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            Array.Resize(ref Teachers, Teachers.Length + 1);
            Teachers[Teachers.Length - 1] = teacher;
        }

        public void UpdateTeacher(Teacher teacher)
        {
            for (int i = 0; i < Teachers.Length; i++)
            {
                if (teacher == Teachers[i])
                {
                    Teachers[i] = teacher;
                }
            }
        }

        public void UpdateTeacher(int index, Teacher teacher)
        {
            Teachers[index] = teacher;
        }


        public void RemoveTeacher(Teacher teacher)
        {
            for (int i = 0; i < Teachers.Length; i++)
            {
                if (teacher == Teachers[i])
                {
                    if (i < Teachers.Length - 1)
                    {
                        Array.Copy(Teachers, i + 1, Teachers, i, Teachers.Length - 1 + i);
                    }
                    Array.Resize(ref Teachers, Teachers.Length - 1);
                    break;
                }
            }
        }

        public void RemoveTeacher(int index)
        {
            RemoveTeacher(Teachers[index]);
        }

        public int Length()
        {
            return Teachers.Length;
        }

        public Teacher GetTeacher(int index)
        {
            return Teachers[index];
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
                    return ((new CaseInsensitiveComparer()).Compare(((Teacher)x).FirstName, ((Teacher)y).FirstName));
                }
                else
                {
                    return ((new CaseInsensitiveComparer()).Compare(((Teacher)y).FirstName, ((Teacher)x).FirstName));
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
                    return ((new CaseInsensitiveComparer()).Compare(((Teacher)x).LastName, ((Teacher)y).LastName));
                }
                else
                {
                    return ((new CaseInsensitiveComparer()).Compare(((Teacher)y).LastName, ((Teacher)x).LastName));
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
                    return ((new CaseInsensitiveComparer()).Compare(((Teacher)x).ID, ((Teacher)y).ID));
                }
                else
                {
                    return ((new CaseInsensitiveComparer()).Compare(((Teacher)y).ID, ((Teacher)x).ID));
                }
            }
        }

        public void SortByName(bool Ascending)
        {
            Array.Sort(Teachers, new FirstNameCompare(Ascending));
        }

        public void SortByLastName(bool Ascending)
        {
            Array.Sort(Teachers, new SecondNameCompare(Ascending));
        }

        public void SortByID(bool Ascending)
        {
            Array.Sort(Teachers, new IDCompare(Ascending));
        }

        public Teacher GetHomeRoomTeacher(ClassRoom classRoom)
        {
            foreach (Teacher teacher in Teachers)
            {
                if (teacher.HomeRoomTeacher == classRoom.ClassName)
                {
                    return teacher;
                }
            }
            return null;
        }
    }
}
