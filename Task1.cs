using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBI_reexam_2
{
    internal class Task1
    {
        public Task1()
        {
            Book[] books = new Book[]
                {
                    new Book("Book 1", "Author A", 1995),
                    new Book("Book 2", "Author B", 2001),
                    new Book("Book 3", "Author A", 1987),
                    new Book("Book 4", "Author C", 2010),
                    new Book("Book 5", "Author B", 1902),
                    new Book("Book 6", "Author D", 1975),
                    new Book("Book 7", "Author A", 1980),
                    new Book("Book 8", "Author C", 1925),
                    new Book("Book 9", "Author B", 1965),
                    new Book("Book 10", "Author D", 2018)
                };

            Console.WriteLine("Введите имя автора:");
            string author = Console.ReadLine();
            Console.WriteLine($"\nКниги автора {author}:");
            Book.PrintBooksByAuthor(books, author);

            Console.WriteLine("\nВведите век:");
            int century = int.Parse(Console.ReadLine());
            Console.WriteLine($"\nКниги из {century}-го века:");
            Book.PrintBooksByCentury(books, century);
        }

        struct Book
        {
            private static int _isbn = 100000;
            private readonly int ISBN;
            private string title;
            private string author;
            private int year;

            public Book(string title, string author, int year)
            {
                this.title = title;
                this.author = author;
                this.year = year;
                ISBN = _isbn++;
            }
            public int GetISBN() => ISBN;
            public string Title
            {
                get => title;
                set => title = value;
            }
            public string Author
            {
                get => author;
                set => author = value;
            }
            public int Year
            {
                get => year;
                set => year = value;
            }
            public void PrintInfo()
            {
                Console.WriteLine($"ISBN: {ISBN}, Название: {Title}, Автор: {Author}, Год: {Year}");
            }
            public static void PrintBooksByAuthor(Book[] books, string author)
            {
                bool found = false;
                foreach (var book in books)
                {
                    if (book.Author.ToLower() == author.ToLower())
                    {
                        book.PrintInfo();
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Книги этого автора не найдены.");
                }
            }
            public static void PrintBooksByCentury(Book[] books, int century)
            {
                bool found = false;
                foreach (var book in books)
                {
                    int bookCentury = (book.Year - 1) / 100 + 1;
                    if (bookCentury == century)
                    {
                        book.PrintInfo();
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Книги из этого века не найдены.");
                }
            }
        }

        class Program
        {

        }
    }
}