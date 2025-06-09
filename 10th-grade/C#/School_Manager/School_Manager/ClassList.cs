using System;
using System.IO;

namespace School_Manager
{
    class ClassList
    {
        private ClassRoom[] Classes = new ClassRoom[0];

        public void Save()
        {
            string Lines = "";
            foreach (ClassRoom classRoom in Classes)
            {
                Lines += String.Format("{0},{1}\n", classRoom.ClassName, classRoom.NumOfStudents);
            }
            File.WriteAllText("Classes.txt", Lines);
        }

        public void Load()
        {
            string[] Lines = File.ReadAllLines("Classes.txt");
            foreach (string Line in Lines)
            {
                ClassRoom classRoom = new ClassRoom();
                string[] Items = Line.Split(',');
                classRoom.ClassName = Items[0];
                classRoom.NumOfStudents = Items[1];


                AddClass(classRoom);
            }
        }

        public void AddClass(ClassRoom classRoom)
        {
            Array.Resize(ref Classes, Classes.Length + 1);
            Classes[Classes.Length - 1] = classRoom;
        }

        public void UpdateClass(ClassRoom classRoom)
        {
            for (int i = 0; i < Classes.Length; i++)
            {
                if (classRoom == Classes[i])
                {
                    Classes[i] = classRoom;
                }
            }
        }

        public void UpdateClass(int index, ClassRoom classRoom)
        {
            Classes[index] = classRoom;
        }

        public void RemoveClass(ClassRoom classRoom)
        {
            for (int i = 0; i < Classes.Length; i++)
            {
                if (classRoom == Classes[i])
                {
                    if (i < Classes.Length - 1)
                    {
                        Array.Copy(Classes, i + 1, Classes, i, Classes.Length - 1 + i);
                    }
                    Array.Resize(ref Classes, Classes.Length - 1);
                    break;
                }
            }
        }

        public void RemoveClass(int index)
        {
            RemoveClass(Classes[index]);
        }

        public int Length()
        {
            return Classes.Length;
        }

        public ClassRoom GetClassRoom(int index)
        {
            return Classes[index];
        }
    }
}
