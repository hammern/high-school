using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage15
{
    class ProjectWorker : Worker
    {
        Node<Project> projects;

        internal Node<Project> Projects { get => projects; set => projects = value; }

        public ProjectWorker(string firstName, string lastName, string id, Node<Project> projects) : base(firstName, lastName, id)
        {
            this.projects = projects;
        }

        public override int Payment()
        {
            int projectsPay = 0;
            Node<Project> iter = projects;

            while (iter != null)
            {
                projectsPay += iter.Value.Pay;
                iter = iter.Next;
            }
            return projectsPay;
        }
    }
}
