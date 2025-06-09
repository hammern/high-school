using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1NadavHammer
{
    class Book
    {
        public int code { get; set; }

        public string name { get; set; }

        public string category { get; set; }

        public string author { get; set; }

        public int releaseYear { get; set; }

        public Book(int code, string name, string category, string author, int releaseYear)
        {
            this.code = code;
            this.name = name;
            this.category = category;
            this.author = author;
            this.releaseYear = releaseYear;
        }

        public override string ToString()
        {
            string bookInfo = string.Format("The books code is {0} and it's name is {1}. {1} is a book in the category of {2} and was written by {3} and released on {4}.",
                code.ToString(), name, category, author, releaseYear.ToString());
            return bookInfo;
        }
    }
}
