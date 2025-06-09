using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Array_3
{
    class Program
    {
        const int AGE = 0;
        const int MED_ID = 1;
        const int MED_AMOUNT = 2;

        static void Main(string[] args)
        {
            int[,] Patients;

            Patients = Get_Patients_Records();

            int NumOfAgeGroup = Get_Most_Med_Consuming_Group(Patients);
            if (NumOfAgeGroup == 0)
            {
                Console.WriteLine("The ages that used the largest amount of medicine are between 0 and 10.");
            }
            else if (NumOfAgeGroup == 1)
            {
                Console.WriteLine("The ages that used the largest amount of medicine are between 11 and 30.");
            }
            else if (NumOfAgeGroup == 2)
            {
                Console.WriteLine("The ages that used the largest amount of medicine are between 31 and 50.");
            }
            else
            {
                Console.WriteLine("The ages that used the largest amount of medicine are ages larger than 51.");
            }

            int[] Consumed_Med = Get_Consumed_Med(Patients);
            for (int i = 0; i < Consumed_Med.Length; i++)
            {
                if (Consumed_Med[i] > 0)
                {
                    Console.WriteLine("Medicine number {0} was used.", i);
                }
            }
            Console.Read();
        }
        static int[,] Get_Patients_Records()
        {
            int[,] Patients = new int[1000, 3];
            int i = 0;

            Console.WriteLine("Please enter 3 things. The patient's age, the medicine's number and how much of the medicine needed. When done enter -1.");
            Get_Patient_Info(i, Patients);
            while (Patients[i, AGE] != -1)
            {
                i++;
                Get_Patient_Info(i, Patients);
            }

            Patients[i, AGE] = 0;
            Patients[i, MED_ID] = 0;
            Patients[i, MED_AMOUNT] = 0;

            return Patients;
        }

        static int Get_Most_Med_Consuming_Group(int[,] Patients)
        {
            int[] AgeGroups = new int[4];
            int Group;

            for (int i = 0; i < Patients.GetLength(0); i++)
            {
                if (0 <= Patients[i, AGE] && Patients[i, AGE] <= 10)
                {
                    Group = 0;
                }
                else if (Patients[i, AGE] <= 30)
                {
                    Group = 1;
                }
                else if (Patients[i, AGE] <= 50)
                {
                    Group = 2;
                }
                else
                {
                    Group = 3;
                }
                AgeGroups[Group] += Patients[i, MED_AMOUNT];
            }
            return Array.IndexOf(AgeGroups, AgeGroups.Max());
        }

        static int[] Get_Consumed_Med(int[,] Patients)
        {
            int[] Meds = new int[150];

            for (int i = 0; i < Patients.GetLength(0); i++)
            {
                if (Patients[i, MED_ID] > 0)
                {
                    Meds[Patients[i, MED_ID]] += 1;
                }
            }
            return Meds;
        }

        static void Get_Patient_Info(int i, int[,] Patient_Info)
        {
            Console.WriteLine("Patient:");
            Console.Write("Patient's age: ");
            Patient_Info[i, AGE] = int.Parse(Console.ReadLine());
            Console.Write("Medicine's Number: ");
            Patient_Info[i, MED_ID] = int.Parse(Console.ReadLine());
            Console.Write("Amount of medicine needed: ");
            Patient_Info[i, MED_AMOUNT] = int.Parse(Console.ReadLine());
        }
     }
}
