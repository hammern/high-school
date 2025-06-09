using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace School_Manager
{
    class TestList
    {
        Test[] Tests = new Test[0];

        public void Save()
        {
            string Lines = "";
            foreach (Test test in Tests)
            {
                Lines += String.Format("{0},{1}\n", test.SubjectName, test.Date);
            }
            File.WriteAllText("Tests.txt", Lines);
        }

        public void Load()
        {
            string[] Lines = File.ReadAllLines("Tests.txt");
            foreach (string Line in Lines)
            {
                Test test = new Test();
                string[] Items = Line.Split(',');
                test.SubjectName = Items[0];
                test.Date = Items[1];

                AddTest(test);
            }
        }

        public void AddTest(Test test)
        {
            Array.Resize(ref Tests, Tests.Length + 1);
            Tests[Tests.Length - 1] = test;
        }

        public void RemoveTest(Test test)
        {
            for (int i = 0; i < Tests.Length; i++)
            {
                if (test == Tests[i])
                {
                    if (i < Tests.Length - 1)
                    {
                        Array.Copy(Tests, i + 1, Tests, i, Tests.Length - 1 + i);
                    }
                    Array.Resize(ref Tests, Tests.Length - 1);
                    break;
                }
            }
        }

        public void RemoveTest(int index)
        {
            RemoveTest(Tests[index]);
        }

        public int Length()
        {
            return Tests.Length;
        }

        public Test GetTest(int index)
        {
            return Tests[index];
        }

        public class SubjectCompare : IComparer
        {
            int IComparer.Compare(Object x, Object y)
            {
                return ((new CaseInsensitiveComparer()).Compare(((Test)x).SubjectName, ((Test)y).SubjectName));
            }
        }

        public void SortBySubject()
        {
            Array.Sort(Tests, new SubjectCompare());
        }

        public class DateCompare : IComparer
        {
            int IComparer.Compare(Object x, Object y)
            {
                return ((new CaseInsensitiveComparer()).Compare(((Test)x).Date, ((Test)y).Date));
            }
        }

        public void SortByDate()
        {
            Array.Sort(Tests, new DateCompare());
        }
    }
}
