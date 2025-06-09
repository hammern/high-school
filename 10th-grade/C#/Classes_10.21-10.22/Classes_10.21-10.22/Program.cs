using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_10._21_10._22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many songs do you have?");
            Console.Write("> ");
            int NumOfSongs = int.Parse(Console.ReadLine());
            Song[] Songs = new Song[NumOfSongs];
            string NameOfSong = "";
            string NameOfPerformer = "";
            int LengthOfSong = 0;
            for (int i = 0; i < Songs.Length; i++)
            {
                Songs[i] = new Song();
                Console.Write("Please enter the name: ");
                NameOfSong = Console.ReadLine();
                Console.Write("Please enter the performer: ");
                NameOfPerformer = Console.ReadLine();
                Console.Write("Please enter the length in seconds: ");
                LengthOfSong = int.Parse(Console.ReadLine());
                Songs[i].Set_Song(NameOfSong, NameOfPerformer, LengthOfSong);
            }
            Console.WriteLine("The average of all the songs is " + AverageSongLength(Songs));
            Console.WriteLine("The longest song is " + TheLongestSong(Songs));
            Console.WriteLine("The number of songs under 2 minutes is " + NumberOfShortSongs(Songs));
            Console.Read();
        }
        static double AverageSongLength(Song[] Songs)
        {
            int Avg = 0;
            for (int i = 0; i < Songs.Length; i++)
            {
                Avg += Songs[i].Get_Length();
            }
            Avg = Avg / Songs.Length;
            return Avg;
        }
        static string TheLongestSong(Song[] Songs)
        {
            int TimeOfLongestSong = 0;
            string LongestSong = "";
            for (int i = 0; i < Songs.Length; i++)
            {
                if (TimeOfLongestSong < Songs[i].Get_Length())
                {
                    TimeOfLongestSong = Songs[i].Get_Length();
                    LongestSong = Songs[i].Get_Name();
                }
            }
            return LongestSong;
        }
        static int NumberOfShortSongs(Song[] Songs)
        {
            int NumOfShortSongs = 0;
            for (int i = 0; i < Songs.Length; i++)
            {
                if (Songs[i].Get_Length() <= 120)
                {
                    NumOfShortSongs++;
                }
            }
            return NumOfShortSongs;
        }
    }
    class Song
    {
        private string NameOfSong;
        private string NameOfPerformer;
        private int LengthOfSong;
        public void Set_Song(string newNameOfSong, string newNameOfPerformer, int newLengthOfSong)
        {
            NameOfSong = newNameOfSong;
            NameOfPerformer = newNameOfPerformer;
            LengthOfSong = newLengthOfSong;
        }
        public int Increase_Length(int LengthOfSong, int IncreasedSeconds)
        {
            return LengthOfSong + IncreasedSeconds;
        }
        public int Decrease_Length(int LengthOfSong, int DecreaseSeconds)
        {
            return LengthOfSong - DecreaseSeconds;
        }
        public void Get_Song()
        {
            Console.WriteLine("Name: " + NameOfSong);
            Console.WriteLine("Performer: " + NameOfPerformer);
            Console.WriteLine("Length: " + LengthOfSong);
        }
        public int Get_Length()
        {
            return LengthOfSong;
        }
        public string Get_Name()
        {
            return NameOfSong;
        }
    }
}
