using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1NadavHammer
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library("123");

            /*for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter a new book:");
                Console.Write("Book Code: ");
                int bookCode = int.Parse(Console.ReadLine());
                Console.Write("Book Name: ");
                string bookName = Console.ReadLine();
                Console.Write("Book Category: ");
                string bookCategory = Console.ReadLine();
                Console.Write("Book Author: ");
                string author = Console.ReadLine();
                Console.Write("Book Release Year: ");
                int releaseYear = int.Parse(Console.ReadLine());
                Book book = new Book(bookCode, bookName, bookCategory, author, releaseYear);
                library.AddBook(book);
            }*/

            // Example books
            library.AddBook(new Book(1, "Scary", "horror", "Zed", 1900));
            library.AddBook(new Book(2, "man", "horror", "b", 1900));
            library.AddBook(new Book(3, "w", "fantasy", "Zed", 1900));

            Console.WriteLine("Enter a category to check how many books are in that category: ");
            string currentCategory = Console.ReadLine();
            Console.WriteLine(library.FindBookAmountInCategory(currentCategory));

            Console.WriteLine("Enter an author to check the categories he wrote in: ");
            string currentAuthor = Console.ReadLine();
            library.PrintCategoriesOfAuthor(currentAuthor);

            Console.WriteLine("Enter a book for information: ");
            string currentBook = Console.ReadLine();
            Console.WriteLine(library.GetBook(currentBook));

            Console.WriteLine("Enter a day to get operational hours: ");
            string currentDay = Console.ReadLine();
            library.PrintHoursByDay(currentDay);

            Console.Read();
        }
    }
}
