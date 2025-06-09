using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage9
{
    class Member
    {
        private string name;
        private Node<string> songs;
        private int songCount;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        internal Node<string> Songs
        {
            get
            {
                return songs;
            }

            set
            {
                songs = value;
            }
        }

        public int SongCount { get => songCount;}

        public Member(string name)
        {
            this.name = name;
        }

        public void AddSong(string song)
        {
            if (songs == null)
            {
                songs = new Node<string>(song);
            }
            else
            {
                Node<string> iter = songs;
                while (iter.HasNext())
                {
                    iter = iter.Next;
                }

                Node<string> newNode = new Node<string>(song);
                iter.Next = newNode;
            }
            songCount++;
        }
    }
}
