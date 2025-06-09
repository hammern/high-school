using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace School_Manager
{
    class GradeList
    {
        private Grade[] Grades = new Grade[0];

        public void Save()
        {
            string Lines = "";
            foreach (Grade grade in Grades)
            {
                Lines += String.Format("{0},{1},{2},{3}\n", grade.TestSubject, grade.TestDate, grade.Student, grade.Score);
            }
            File.WriteAllText("Grades.txt", Lines);
        }

        public void Load()
        {
            string[] Lines = File.ReadAllLines("Grades.txt");
            foreach (string Line in Lines)
            {
                Grade grade = new Grade();
                string[] Items = Line.Split(',');
                grade.TestSubject = Items[0];
                grade.TestDate = Items[1];
                grade.Student = Items[2];
                grade.Score = int.Parse(Items[3]);

                AddGrade(grade);
            }
        }

        public void AddGrade(Grade grade)
        {
            Array.Resize(ref Grades, Grades.Length + 1);
            Grades[Grades.Length - 1] = grade;
        }

        public void UpdateGrade(Grade grade)
        {
            for (int i = 0; i < Grades.Length; i++)
            {
                if (grade == Grades[i])
                {
                    Grades[i] = grade;
                }
            }
        }

        public void UpdateGrade(int index, Grade grade)
        {
            Grades[index] = grade;
        }

        public int Length()
        {
            return Grades.Length;
        }

        public Grade GetGrade(int index)
        {
            return Grades[index];
        }

        public int FindGrade(Grade grade)
        {
            for (int i = 0; i < Grades.Length; i++)
            {
                Grade var = Grades[i];
                if (var.TestSubject == grade.TestSubject && var.TestDate == grade.TestDate && var.Student == grade.Student)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
