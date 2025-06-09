using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace School_Manager
{
    class SubjectList
    {
        Subject[] Subjects = new Subject[0];

        public void Save()
        {
            string Lines = "";
            foreach (Subject subject in Subjects)
            {
                Lines += String.Format("{0},{1},{2}\n", subject.Name, subject.IsMajor, subject.NumOfHours);
            }
            File.WriteAllText("Subjects.txt", Lines);
        }

        public void Load()
        {
            string[] Lines = File.ReadAllLines("Subjects.txt");
            foreach (string Line in Lines)
            {
                Subject subject = new Subject();
                string[] Items = Line.Split(',');
                subject.Name = Items[0];
                subject.IsMajor = bool.Parse(Items[1]);
                subject.NumOfHours = Items[2];

                AddSubject(subject);
            }
        }

        public void AddSubject(Subject subject)
        {
            Array.Resize(ref Subjects, Subjects.Length + 1);
            Subjects[Subjects.Length - 1] = subject;
        }

        public void RemoveSubject(Subject subject)
        {
            for (int i = 0; i < Subjects.Length; i++)
            {
                if (subject == Subjects[i])
                {
                    if (i < Subjects.Length - 1)
                    {
                        Array.Copy(Subjects, i + 1, Subjects, i, Subjects.Length - 1 + i);
                    }
                    Array.Resize(ref Subjects, Subjects.Length - 1);
                    break;
                }
            }
        }

        public void RemoveSubject(int index)
        {
            RemoveSubject(Subjects[index]);
        }

        public int Length()
        {
            return Subjects.Length;
        }

        public Subject GetSubject(int index)
        {
            return Subjects[index];
        }
    }
}
