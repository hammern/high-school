using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage14
{
    class Product
    {
        protected string manufacturer;
        protected string model;
        protected int price;
        protected int amount;

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }

            set
            {
                manufacturer = value;
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

        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public Product(string manufacturer, string model, int price, int amount)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.Amount = amount;
        }
    }
}
