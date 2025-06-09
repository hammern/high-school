using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2NadavHammer
{
    class Ballot
    {
        private Citizen[] citizens = new Citizen[100];
        private static int citizenCounter = 0;
        public Candidate[] candidates = new Candidate[10];
        private static int candidateCounter = 0;
        private string ballotName;
        private Vote[] votes = new Vote[100];
        private int voteCounter = 0;

        public void AddCandidate(Candidate candidate)
        {
            if (candidateCounter <= 10)
            {
                candidates[candidateCounter] = candidate;
                candidateCounter++;
            }
        }

        public void AddCitizen(Citizen citizen)
        {
            if (citizenCounter <= 100)
            {
                citizens[citizenCounter] = citizen;
                citizenCounter++;
            }
        }

        public void Vote(int id, int numberOfCandidate)
        {
            if (voteCounter <= 100)
            {
                votes[voteCounter] = new Vote(id, numberOfCandidate);
                voteCounter++;
            }
        }

        public void SortVotes()
        {
            Result[] results = new Result[0];

            for (int i = 0; i < voteCounter; i++)
            {
                int j;

                for (j = 0; j < results.Length; j++)
                {
                    if (votes[i].candidateNumber == results[j].candidateNumber)
                    {
                        break;
                    }
                }

                if (j == results.Length)
                {
                    Array.Resize(ref results, results.Length + 1);
                    j = results.Length - 1;
                    results[j] = new Result(votes[i].candidateNumber);
                }

                results[j].numOfVotes++;
            }

            Array.Sort(results, new VoteCompare());

            for (int i = 0; i < results.Length; i++)
            {
                for (int j = 0; j < candidates.Length; j++)
                {
                    if (results[i].candidateNumber == candidates[j].candidateNumber)
                    {
                        Console.WriteLine(candidates[j].name + " - " + results[i].numOfVotes);
                        break;
                    }
                }
            }
        }

        public class VoteCompare : IComparer
        {
            int IComparer.Compare(Object x, Object y)
            {
                return ((Result)x).numOfVotes < ((Result)y).numOfVotes ? 1 : -1;
            }
        }
    }

    class Vote
    {
        public int candidateNumber { get; set; }
        public int citizenID { get; set; }

        public Vote(int id, int numberOfCandidate)
        {
            this.citizenID = id;
            this.candidateNumber = numberOfCandidate;
        }

    }

    class Result
    {
        public int candidateNumber { get; set; }
        public int numOfVotes { get; set; }

        public Result(int numberOfCandidate)
        {
            this.candidateNumber = numberOfCandidate;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", candidateNumber, numOfVotes);
        }
    }
}
