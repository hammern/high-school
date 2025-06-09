using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage15
{
    class Worker
    {
        protected string firstName;
        protected string lastName;
        protected string id;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Id { get => id; set => id = value; }

        public Worker(string firstName, string lastName, string id)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
        }

        public virtual int Payment()
        {
            return 4500;
        }
    }
}
