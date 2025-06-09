using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab22_Ex4_Robots
{
    class Program
    {
        static void Main(string[] args)
        {
            //TwoRobotGame();
            MoreThanTwoRobots();
            Console.Read();
        }
        static void MoreThanTwoRobots()
        {
            Console.WriteLine("Please enter how many robots are playing:");
            Console.Write("> ");
            int NumOfRobots = int.Parse(Console.ReadLine());
            Robot[] Robots = new Robot[NumOfRobots];
            for (int i = 0; i < Robots.Length; i++)
            {
                Robots[i] = new Robot();
                Console.Write("Robot {0} color: ", i + 1);
                string Color = Console.ReadLine();
                Robots[i].Set_Robot(Color, 15, true);
            }
            Random RandomDirection = new Random();
            Random StepCount = new Random();
            int Direction = 0;
            int NumberOfSteps = 0;
            int NumOfRound = 0;
            while (PlayMultiplayer(Robots))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("==== Round {0} ====", (NumOfRound + 1));
                Console.ForegroundColor = ConsoleColor.Gray;
                for (int i = 0; i < Robots.Length; i++)
                {
                    Direction = RandomDirection.Next(0, 2);
                    NumberOfSteps = StepCount.Next(1, 7);
                    Movement(Direction, NumberOfSteps, Robots[i]);
                }
                MultiplayerCheckOnSameSquare(Robots);
                NumOfRound++;
            }
            for (int i = 0; i < Robots.Length; i++)
            {
                if (!Robots[i].Get_IsOnGameBoard())
                {
                    Console.WriteLine("The {0} robot won after {1} rounds!", Robots[i].Get_Color(), NumOfRound);
                    break;
                }
            }
        }
        static bool PlayMultiplayer(Robot[] robots)
        {
            bool IsOnGameBoard = true;
            for (int i = 0; i < robots.Length; i++)
            {
                if (robots[i].Get_IsOnGameBoard() == false)
                {
                    IsOnGameBoard = false;
                }
            }
            return IsOnGameBoard;
        }
        static bool CheckOnSameSquare(Robot Robot1, Robot Robot2)
        {
            if (Robot1.Get_NumOfSquare() == Robot2.Get_NumOfSquare())
            {
                Robot1.Set_IsOnGameBoard(false);
            }
            return Robot1.Get_IsOnGameBoard();
        }
        static void MultiplayerCheckOnSameSquare(Robot[] robots)
        {
            for (int i = 0; i < robots.Length; i++)
            {
                for (int j = 0; j < robots.Length; j++)
                {
                    if (robots[i].Get_NumOfSquare() == robots[j].Get_NumOfSquare())
                    {
                        if (i < j)
                        {
                            robots[j].Set_NumOfSquare(42);
                        }
                        else if (i > j)
                        {
                            robots[i].Set_NumOfSquare(42);
                        }
                    }
                }
            }
        }
        static void Movement(int Direction, int NumberOfSteps, Robot robot)
        {
            if (Direction == 0)
            {
                robot.Move_Forward(NumberOfSteps);
                Console.WriteLine(robot.Get_Robot() + " and moved forward " + NumberOfSteps);
            }
            else
            {
                robot.Move_Backwards(NumberOfSteps);
                Console.WriteLine(robot.Get_Robot() + " and moved backwards " + NumberOfSteps);
            }
        }
        static void VisualGame(Robot robot1, Robot robot2)
        {
            string NumberLine = "|0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30|";
            string Line = "|                                                                              |";
            int Index;
            for (int i = 0; i < 30; i++)
            {
                if (i == robot1.Get_NumOfSquare())
                {
                    Index = NumberLine.IndexOf(i.ToString());
                    Line = Line.Insert(Index, "r1");
                }
                if (i == robot2.Get_NumOfSquare())
                {
                    Index = NumberLine.IndexOf(i.ToString());
                    Line = Line.Insert(Index, "r2");
                }
            }
            Console.WriteLine("+----------------------------------------------------------------------------------+");
            Console.WriteLine(NumberLine);
            Console.WriteLine(Line);
            Console.WriteLine("+----------------------------------------------------------------------------------+");
            System.Threading.Thread.Sleep(1000);
        }
        static void TwoRobotGame()
        {
            Console.Write("Color of Robot 1: ");
            string Color = Console.ReadLine();
            Robot Robot1 = new Robot();
            Robot1.Set_Robot(Color, 15, true);
            Console.Write("Color of Robot 2: ");
            Color = Console.ReadLine();
            Robot Robot2 = new Robot();
            Robot2.Set_Robot(Color, 15, true);
            Random RandomDirection = new Random();
            Random StepCount = new Random();
            int Direction = 0;
            int NumberOfSteps = 0;
            int NumOfRound = 1;
            while (Robot1.Get_IsOnGameBoard() && Robot2.Get_IsOnGameBoard())
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Round " + NumOfRound);
                Console.ForegroundColor = ConsoleColor.Gray;
                Direction = RandomDirection.Next(0, 2);
                NumberOfSteps = StepCount.Next(1, 7);
                Movement(Direction, NumberOfSteps, Robot1);
                Robot1.Set_IsOnGameBoard(CheckOnSameSquare(Robot1, Robot2));
                Direction = RandomDirection.Next(0, 2);
                NumberOfSteps = StepCount.Next(1, 7);
                Movement(Direction, NumberOfSteps, Robot2);
                Robot2.Set_IsOnGameBoard(CheckOnSameSquare(Robot2, Robot1));
                NumOfRound++;
                VisualGame(Robot1, Robot2);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            if (!Robot1.Get_IsOnGameBoard())
            {
                Console.WriteLine("The {0} robot won after {1} rounds", Robot1.Get_Color(), NumOfRound - 1);
            }
            else
            {
                Console.WriteLine("The {0} robot won after {1} rounds", Robot2.Get_Color(), NumOfRound - 1);
            }
        }
    }
    class Robot
    {
        private string Color;
        private int NumOfSquare;
        private bool IsOnGameBoard;
        public void Set_Robot(string Color, int NumOfSquare, bool IsOnGameBoard)
        {
            this.Color = Color;
            this.NumOfSquare = NumOfSquare;
            this.IsOnGameBoard = IsOnGameBoard;
        }
        public void Set_NumOfSquare(int NumOfSquare)
        {
            this.NumOfSquare = NumOfSquare;
        }
        public int Get_NumOfSquare()
        {
            return NumOfSquare;
        }
        public string Get_String_NumOfSquare()
        {
            return NumOfSquare.ToString();
        }
        public void Set_IsOnGameBoard(bool IsOnGameBoard)
        {
            this.IsOnGameBoard = IsOnGameBoard;
        }
        public bool Get_IsOnGameBoard()
        {
            if (0 <= NumOfSquare && NumOfSquare <= 30)
            {
                IsOnGameBoard = true;
            }
            else
            {
                IsOnGameBoard = false;
            }
            return IsOnGameBoard;
        }
        public string Get_Color()
        {
            return Color;
        }
        public string Get_Robot()
        {
            return Color + " robot is on square number " + NumOfSquare;
        }
        public void Move_Forward(int StepCount)
        {
            NumOfSquare += StepCount;
        }
        public void Move_Backwards(int StepCount)
        {
            NumOfSquare -= StepCount;
        }

    }
}
