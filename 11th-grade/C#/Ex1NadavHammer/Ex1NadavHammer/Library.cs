using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1NadavHammer
{
    class Library
    {
        private Book[] books = new Book[100];

        private static string[] Days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        private HourRange[][] hourRanges = new HourRange[7][];


        public int numOfBooks { get; set; }

        public string address { get; set; }

        public string GetBook(string bookName)
        {
            if (CheckBookExistence(bookName))
            {
                for (int i = 0; i < numOfBooks; i++)
                {
                    if (books[i].name == bookName)
                    {
                        return books[i].ToString();
                    }
                }
            }
            return "Book not found";
        }

        public Library(string address)
        {
            numOfBooks = 0;
            this.address = address;
            FillOperationalHours();
        }

        private void FillOperationalHours()
        {
            hourRanges[0] = new HourRange[1];
            hourRanges[0][0] = new HourRange("9:00", "19:45");
            hourRanges[1] = new HourRange[2];
            hourRanges[1][0] = new HourRange("9:00", "11:45");
            hourRanges[1][1] = new HourRange("11:45", "19:45");
            hourRanges[2] = new HourRange[2];
            hourRanges[2][0] = new HourRange("9:00", "11:45");
            hourRanges[2][1] = new HourRange("11:45", "19:45");
            hourRanges[3] = new HourRange[2];
            hourRanges[3][0] = new HourRange("9:00", "11:45");
            hourRanges[3][1] = new HourRange("11:45", "19:45");
            hourRanges[4] = new HourRange[1];
            hourRanges[4][0] = new HourRange("9:00", "19:45");
            hourRanges[5] = new HourRange[1];
            hourRanges[5][0] = new HourRange("9:00", "11:45");
            hourRanges[6] = new HourRange[1];
            hourRanges[6][0] = new HourRange("9:00", "19:45");
        }

        public void AddBook(Book book)
        {
            books[numOfBooks] = book;
            numOfBooks++;
        }

        public int FindBookAmountInCategory(string category)
        {
            int counter = 0;

            for (int i = 0; i < numOfBooks; i++)
            {
                if (books[i].category == category)
                {
                    counter++;
                }
            }

            return counter;
        }

        public void PrintCategoriesOfAuthor(string author)
        {
            string[] categories = new string[0];

            for (int i = 0; i < numOfBooks; i++)
            {
                if (books[i].author == author)
                {
                    int j;
                    // check if category exist
                    for (j = 0; j < categories.Length; j++)
                    {
                        if (books[i].category == categories[j])
                        {
                            break;
                        }
                    }
                    if (j == categories.Length)
                    {
                        Array.Resize(ref categories, categories.Length + 1);
                        categories[categories.Length - 1] = books[i].category;
                    }
                }
            }

            if (categories.Length > 0)
            {
                for (int i = 0; i < categories.Length; i++)
                {
                    Console.WriteLine(categories[i]);
                }
            }
            else
            {
                Console.WriteLine("Author does not exist");
            }
        }

        public bool CheckBookExistence(string bookName)
        {
            for (int i = 0; i < numOfBooks; i++)
            {
                if (books[i].name == bookName)
                {
                    return true;
                }
            }
            return false;
        }

        public HourRange[] GetHoursByDay(string day)
        {
            int dayNum = 0;

            foreach (string Day in Days)
            {
                if (Day == day)
                {
                    break;
                }
                dayNum++;
            }
            if (dayNum < 7)
            {
                return hourRanges[dayNum];
            }
            else
            {
                Console.WriteLine("Uknown day");
                return null;
            }
        }

        public void PrintHoursByDay(string day)
        {
            HourRange[] hourRanges = GetHoursByDay(day);
            if (hourRanges != null)
            {
                foreach (var hours in hourRanges)
                {
                    Console.WriteLine(hours.ToString());
                }
            }
        }
    }

    class HourRange
    {
        private string start;
        private string end;

        public HourRange(string start, string end)
        {
            this.start = start;
            this.end = end;
        }

        public string Start { get => start; set => start = value; }
        public string End { get => end; set => end = value; }

        public override string ToString()
        {
            return Start + "-" + End;
        }

    }
}
