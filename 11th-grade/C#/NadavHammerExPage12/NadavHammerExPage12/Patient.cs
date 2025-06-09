using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage12
{
    class Patient
    {
        private string id;
        private string name;
        private int dateOfBirth;
        private string gender;

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

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

        public int DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        public Patient(string id, string name, int yearOfBirth, string gender)
        {
            this.id = id;
            this.name = name;
            this.dateOfBirth = yearOfBirth;
            this.gender = gender;
        }
    }
}
