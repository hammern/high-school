using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage12
{
    class Treatment
    {
        private Patient patient;
        private DateTime date;
        private string hour;

        internal Patient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        public string Hour
        {
            get
            {
                return hour;
            }
            set
            {
                hour = value;
            }
        }

        public Treatment(Patient patient, DateTime date, string hour)
        {
            this.patient = patient;
            this.date = date;
            this.hour = hour;
        }
    }
}
