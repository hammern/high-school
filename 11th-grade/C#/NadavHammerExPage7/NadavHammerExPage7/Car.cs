using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage7
{
    class Car
    {
        private string company;
        private string model;
        private string licensePlate;
        private int price;
        private string year;

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        public string LicensePlate
        {
            get
            {
                return licensePlate;
            }
            set
            {
                licensePlate = value;
            }
        }

        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public string Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        public Car(string company, string model, string licensePlate, int price, string year)
        {
            this.Company = company;
            this.model = model;
            this.licensePlate = licensePlate;
            this.price = price;
            this.year = year;
        }
    }
}
