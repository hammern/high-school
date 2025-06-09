using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage12
{
    class Doctor
    {
        private string name;
        private string speciality;
        private Queue<Treatment> appointments;
        private int appNumbers;

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

        public string Speciality
        {
            get
            {
                return speciality;
            }
            set
            {
                speciality = value;
            }
        }

        internal Queue<Treatment> Appointments
        {
            get
            {
                return appointments;
            }
            set
            {
                appointments = value;
            }
        }

        public int AppNumbers
        {
            get
            {
                return appNumbers;
            }
            set
            {
                appNumbers = value;
            }
        }

        public Doctor(string name, string speciality)
        {
            this.name = name;
            this.speciality = speciality;
            this.appointments = new Queue<Treatment>();
        }
    }
}
