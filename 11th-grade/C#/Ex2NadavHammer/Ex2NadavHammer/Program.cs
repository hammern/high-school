using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2NadavHammer
{
    class Program
    {
        static void Main(string[] args)
        {
            Ballot ballot = new Ballot();

            ballot.AddCandidate(new Candidate(0,"Zed"));
            ballot.AddCandidate(new Candidate(1, "Yosi"));
            ballot.AddCandidate(new Candidate(2, "David"));
            ballot.AddCandidate(new Candidate(3, "Yaron"));

            ballot.AddCitizen(new Citizen("A B", 123));
            ballot.AddCitizen(new Citizen("A B", 456));
            ballot.AddCitizen(new Citizen("A B", 789));
            ballot.AddCitizen(new Citizen("A B", 134));
            ballot.AddCitizen(new Citizen("A B", 245));
            ballot.AddCitizen(new Citizen("A B", 356));
            ballot.AddCitizen(new Citizen("A B", 467));
            ballot.AddCitizen(new Citizen("A B", 578));
            ballot.AddCitizen(new Citizen("A B", 689));
            ballot.AddCitizen(new Citizen("A B", 790));

            ballot.Vote(123, 0);
            ballot.Vote(456, 1);
            ballot.Vote(789, 3);
            ballot.Vote(134, 2);
            ballot.Vote(245, 3);
            ballot.Vote(356, 2);
            ballot.Vote(467, 3);
            ballot.Vote(578, 3);
            ballot.Vote(689, 0);
            ballot.Vote(790, 0);

            ballot.SortVotes();

            Console.Read();
        }
    }
}
