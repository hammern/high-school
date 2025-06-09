using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage12
{
    class Office
    {
        private string name;
        private Node<Doctor> doctors;

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

        internal Node<Doctor> Doctors
        {
            get
            {
                return doctors;
            }
            set
            {
                doctors = value;
            }
        }

        public Office(string name)
        {
            this.name = name;
        }

        public void AddDoctor(string name, string speciality)
        {
            if (doctors == null)
            {
                doctors = new Node<Doctor>(new Doctor(name, speciality));
            }
            else
            {
                Node<Doctor> iter = doctors;
                while (iter.HasNext())
                {
                    iter = iter.Next;
                }

                Node<Doctor> newNode = new Node<Doctor>(new Doctor(name, speciality));
                iter.Next = newNode;
            }
            Console.WriteLine("Added doctor {0}, {1}", name, speciality);
        }

        public void AddApp(string name, Patient patient, DateTime date, string hour)
        {
            Node<Doctor> iter = doctors;
            while (iter != null)
            {
                if (iter.Value.Name == name)
                {
                    iter.Value.Appointments.Insert(new Treatment(patient, date, hour));
                    iter.Value.AppNumbers++;
                    Console.WriteLine("Added appointment for {0}: {1}, {2} at {3}", name, patient.Name, date.ToString("dd/MM/yyyy"), hour);
                    break;
                }

                iter = iter.Next;
            }
        }

        public string GetCurrentPatient(string doctorName)
        {
            Node<Doctor> iter = doctors;
            while (iter != null)
            {
                if (iter.Value.Name == doctorName)
                {
                    if (iter.Value.Appointments.IsEmpty())
                    {
                        return null;
                    }
                    return iter.Value.Appointments.Remove().Patient.Name;
                }

                iter = iter.Next;
            }
            return null;
        }

        public void PrintAllFreeDoctors()
        {
            Node<Doctor> iter = doctors;

            while (iter != null)
            {
                if (iter.Value.Appointments.IsEmpty())
                {
                    Console.WriteLine(iter.Value.Name);
                }
                iter = iter.Next;
            }
        }

        public string GetLeastSpeciality(string speciality)
        {
            Node<Doctor> iter = doctors;
            string leastAppName = "";
            int leastAppNum = int.MaxValue;

            while (iter != null)
            {
                if (iter.Value.Speciality == speciality)
                {
                    if (iter.Value.AppNumbers < leastAppNum)
                    {
                        leastAppNum = iter.Value.AppNumbers;
                        leastAppName = iter.Value.Name;
                    }
                }
                iter = iter.Next;
            }
            return leastAppName;
        }
    }
}
