using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace School_Manager
{
    class StaffList
    {
        private Staff[] Staffs = new Staff[0];

        public void Save()
        {
            string Lines = "";
            foreach (Staff staff in Staffs)
            {
                Lines += String.Format("{0},{1},{2},{3},{4},{5},{6}\n", staff.FirstName, staff.LastName, staff.ID, staff.PayCheck,
                    staff.DateJoined, staff.WeeklyHours, staff.Role);
            }
            File.WriteAllText("Staff.txt", Lines);
        }

        public void Load()
        {
            string[] Lines = File.ReadAllLines("Staff.txt");
            foreach (string Line in Lines)
            {
                Staff staff = new Staff();
                string[] Items = Line.Split(',');
                staff.FirstName = Items[0];
                staff.LastName = Items[1];
                staff.ID = Items[2];
                staff.PayCheck = Items[3];
                staff.DateJoined = Items[4];
                staff.WeeklyHours = Items[5];
                staff.Role = Items[6];

                AddStaff(staff);
            }
        }

        public void AddStaff(Staff staff)
        {
            Array.Resize(ref Staffs, Staffs.Length + 1);
            Staffs[Staffs.Length - 1] = staff;
        }

        public void UpdateStaff(Staff staff)
        {
            for (int i = 0; i < Staffs.Length; i++)
            {
                if (staff == Staffs[i])
                {
                    Staffs[i] = staff;
                }
            }
        }

        public void UpdateStaff(int index, Staff staff)
        {
            Staffs[index] = staff;
        }

        public void RemoveStaff(Staff staff)
        {
            for (int i = 0; i < Staffs.Length; i++)
            {
                if (staff == Staffs[i])
                {
                    if (i < Staffs.Length - 1)
                    {
                        Array.Copy(Staffs, i + 1, Staffs, i, Staffs.Length - 1 + i);
                    }
                    Array.Resize(ref Staffs, Staffs.Length - 1);
                    break;
                }
            }
        }

        public void RemoveStaff(int index)
        {
            RemoveStaff(Staffs[index]);
        }

        public int Length()
        {
            return Staffs.Length;
        }

        public Staff GetStaff(int index)
        {
            return Staffs[index];
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
                    return ((new CaseInsensitiveComparer()).Compare(((Staff)x).FirstName, ((Staff)y).FirstName));
                }
                else
                {
                    return ((new CaseInsensitiveComparer()).Compare(((Staff)y).FirstName, ((Staff)x).FirstName));
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
                    return ((new CaseInsensitiveComparer()).Compare(((Staff)x).LastName, ((Staff)y).LastName));
                }
                else
                {
                    return ((new CaseInsensitiveComparer()).Compare(((Staff)y).LastName, ((Staff)x).LastName));
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
                    return ((new CaseInsensitiveComparer()).Compare(((Staff)x).ID, ((Staff)y).ID));
                }
                else
                {
                    return ((new CaseInsensitiveComparer()).Compare(((Staff)y).ID, ((Staff)x).ID));
                }
            }
        }

        public void SortByName(bool Ascending)
        {
            Array.Sort(Staffs, new FirstNameCompare(Ascending));
        }

        public void SortByLastName(bool Ascending)
        {
            Array.Sort(Staffs, new SecondNameCompare(Ascending));
        }

        public void SortByID(bool Ascending)
        {
            Array.Sort(Staffs, new IDCompare(Ascending));
        }
    }
}
