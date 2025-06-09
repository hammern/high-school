using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Ex3_Cubes
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Player Player1 = new Player();
            Player Player2 = new Player();
            Console.Write("Name of player 1: ");
            string TempName = Console.ReadLine();
            Player1.Set_Name(TempName);
            Console.Write("Name of player 2: ");
            TempName = Console.ReadLine();
            Player2.Set_Name(TempName);
            int i = 0;
            while (Player1.Get_Score() <= 100 && Player2.Get_Score() <= 100)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Round " + (i + 1));
                Console.ForegroundColor = ConsoleColor.Gray;
                Player1.Play(rand);
                Player2.Play(rand);
                Console.WriteLine(Player1.Get_Name() + " score: " + Player1.Get_Score());
                Console.WriteLine(Player2.Get_Name() + " score: " + Player2.Get_Score());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("----------------------------");
                Console.ForegroundColor = ConsoleColor.Gray;
                i++;
            }
            if (Player1.Get_Score() >= 100 && Player2.Get_Score() >= 100)
            {
                Console.WriteLine("It's a draw!");
            }
            else if (Player1.Check_Win() == true)
            {
                Console.WriteLine(Player1.Get_Name() + " won!");
            }
            else if (Player2.Check_Win() == true)
            {
                Console.WriteLine(Player2.Get_Name() + " won!");
            }
            Console.ReadLine();
        }
    }
    class Player
    {
        private string Name;
        private int Score;
        private int Throw1;
        private int Throw2;
        public void Set_Name(string newName)
        {
            Name = newName;
        }
        public void Play(Random rand)
        {
            Throw1 = rand.Next(1, 7);
            Throw2 = rand.Next(1, 7);
            Console.WriteLine(Name + " landed a {0} and {1}", Throw1, Throw2);
            if (Throw1 == Throw2)
            {
                Score += 2 * (Throw1 + Throw2);
            }
            else
            {
                Score += Throw1 + Throw2;
            }
        }
        public bool Check_Win()
        {
            if (Score >= 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int Get_Score()
        {
            return Score;
        }
        public string Get_Name()
        {
            return Name;
        }
    }
}
