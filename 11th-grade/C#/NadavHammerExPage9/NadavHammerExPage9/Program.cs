using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage9
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<Member> members = null;

            members = AddMember(members, new Member("Dorf"));
            members = AddMember(members, new Member("Roy"));
            members = AddMember(members, new Member("Benji"));
            members = AddMember(members, new Member("Nadav"));
            members = AddMember(members, new Member("Shmila"));

            AddSongs(members);
            Console.WriteLine("// Members with most songs:");
            PrintMostSongs(members);

            Console.WriteLine("// All songs (no duplicates):");
            Node<string> allSongs = AllSongs(members);
            while (allSongs != null)
            {
                Console.WriteLine(allSongs.Value);

                allSongs = allSongs.Next;
            }

            Console.WriteLine("// Popularity of songs:");
            SortByPopularity(members);

            Console.Read();
        }

        private static Node<Member> AddMember(Node<Member> members, Member member)
        {
            if (members == null)
            {
                members = new Node<Member>(member);
            }
            else
            {
                Node<Member> iter = members;
                while (iter.HasNext())
                {
                    iter = iter.Next;
                }

                Node<Member> newNode = new Node<Member>(member);
                iter.Next = newNode;
            }
            return members;
        }

        private static void AddSongs(Node<Member> members)
        {
            Random rand = new Random(10);
            Node<Member> iter = members;

            while (iter != null)
            {
                for (int i = 0; i < rand.Next(10); i++)
                {
                    iter.Value.AddSong(rand.Next(10).ToString());
                }
                iter = iter.Next;
            }
        }

        private static void PrintMostSongs(Node<Member> members)
        {
            int maxSongs = 0;
            Node<Member> iter = members;

            while (iter != null)
            {
                if (iter.Value.SongCount > maxSongs)
                {
                    maxSongs = iter.Value.SongCount;
                }
                iter = iter.Next;
            }

            iter = members;
            while (iter != null)
            {
                if (iter.Value.SongCount == maxSongs)
                {
                    Console.WriteLine(iter.Value.Name);
                }
                iter = iter.Next;
            }
        }

        private static Node<string> AllSongs(Node<Member> members)
        {
            Node<Member> iter = members;
            Node<string> songIter;
            Node<string> allSongs = null;

            while (iter != null)
            {
                songIter = iter.Value.Songs;
                while (songIter != null)
                {
                    if (!SongExist(allSongs, songIter.Value))
                    {
                        Node<string> newSong = new Node<string>(songIter.Value);
                        newSong.Next = allSongs;
                        allSongs = newSong;
                    }

                    songIter = songIter.Next;
                }

                iter = iter.Next;
            }
            return allSongs;
        }

        private static bool SongExist(Node<string> songs, string songName)
        {
            Node<string> iter = songs;

            while (iter != null)
            {
                if (iter.Value == songName)
                {
                    return true;
                }

                iter = iter.Next;
            }
            return false;
        }

        private static void SortByPopularity(Node<Member> members)
        {

            Node<string> allSongs = AllSongs(members);
            Node<string> songIter;
            Node<Member> iter;
            int maxCount;
            int count;
            string mostPop;

            while (allSongs != null)
            {
                maxCount = 0;
                mostPop = "";
                songIter = allSongs;

                while (songIter != null)
                {
                    count = 0;
                    iter = members;
                    while (iter != null)
                    {
                        if (SongExist(iter.Value.Songs, songIter.Value))
                        {
                            count++;
                        }

                        iter = iter.Next;
                    }

                    if (count > maxCount)
                    {
                        maxCount = count;
                        mostPop = songIter.Value;
                    }

                    songIter = songIter.Next;
                }

                Console.WriteLine(mostPop + " - " + maxCount);

                allSongs = RemoveSong(allSongs, mostPop);   
            }
        }

        private static Node<string> RemoveSong(Node<string> songs, string songName)
        {
            Node<string> first = songs;
            Node<string> prev = null;

            while (songs != null)
            {
                if (songs.Value == songName)
                {
                    if (songs.HasNext())
                    {
                        Node<string> next = songs.Next;
                        songs.Value = next.Value;
                        songs.Next = next.Next;
                        next = null;
                    }
                    else
                    {
                        if (prev != null)
                        {
                            prev.Next = null;
                        }
                        else
                        {
                            first = null;
                        }
                        songs = null;
                    }

                    break;
                }

                prev = songs;
                songs = songs.Next;
            }

            return first;
        }
    }
}
