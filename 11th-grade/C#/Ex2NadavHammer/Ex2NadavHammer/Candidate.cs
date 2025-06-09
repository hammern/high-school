using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2NadavHammer
{
    class Candidate
    {
        public int candidateNumber { get; }
        public string name { get; }

        public Candidate(int numberOfCandidate, string name)
        {
            this.candidateNumber = numberOfCandidate;
            this.name = name;
        }
    }
}
