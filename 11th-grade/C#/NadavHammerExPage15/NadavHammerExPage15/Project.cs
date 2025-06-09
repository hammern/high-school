using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage15
{
    class Project
    {
        private string projectName;
        private int pay;

        public string ProjectName { get => projectName; set => projectName = value; }
        public int Pay { get => pay; set => pay = value; }

        public Project(string projectName, int pay)
        {
            this.projectName = projectName;
            this.pay = pay;
        }
    }
}
