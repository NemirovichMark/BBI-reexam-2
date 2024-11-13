using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBI_reexam_2
{
    internal class Task2
    {
        public Task2()
        {
            PaperBook[] paperBooks = new PaperBook[]
            {
                new PaperBook("Paper Book 1", "Author A", 1995, true),
                new PaperBook("Paper Book 2", "Author B", 2001, false),
                new PaperBook("Paper Book 3", "Author A", 1987, true),
                new PaperBook("Paper Book 4", "Author C", 2010, true),
                new PaperBook("Paper Book 5", "Author D", 2015, false)
            };

            ElectronicBook[] electronicBooks = new ElectronicBook[]
            {
                new ElectronicBook("E-Book 1", "Author E", 2020, "pdf"),
                new ElectronicBook("E-Book 2", "Author F", 2021, "epub"),
                new ElectronicBook("E-Book 3", "Author G", 2019, "fb2"),
                new ElectronicBook("E-Book 4", "Author H", 2022, "pdf"),
                new ElectronicBook("E-Book 5", "Author I", 2023, "epub")
            };

            AudioBook[] audioBooks = new AudioBook[]
            {
                new AudioBook("Audio Book 1", "Author J", 2018, true),
                new AudioBook("Audio Book 2", "Author K", 2017, false),
                new AudioBook("Audio Book 3", "Author L", 2022, true),
                new AudioBook("Audio Book 4", "Author M", 2021, false),
                new AudioBook("Audio Book 5", "Author N", 2020, true)
            };

            Console.WriteLine("\nКниги в формате PaperBook:");
            foreach (var book in paperBooks)
                book.PrintInfo();

            Console.WriteLine("\nКниги в формате ElectronicBook:");
            foreach (var book in electronicBooks)
                book.PrintInfo();

            Console.WriteLine("\nКниги в формате AudioBook:");
            foreach (var book in audioBooks)
                book.PrintInfo();

            Console.WriteLine("\nСортировка по убыванию цены:");
            Book[] allBooks = new Book[paperBooks.Length + electronicBooks.Length + audioBooks.Length];
            paperBooks.CopyTo(allBooks, 0);
            electronicBooks.CopyTo(allBooks, paperBooks.Length);
            audioBooks.CopyTo(allBooks, paperBooks.Length + electronicBooks.Length);

            QuickSort(allBooks, 0, allBooks.Length - 1);

            Console.WriteLine("\nОбщая таблица книг, отсортированных по убыванию цены:");
            foreach (var book in allBooks)
                book.PrintInfo();
        }
        internal abstract class Book
        {
            private static int _isbn = 100000;
            private readonly int _isbnNumber;
            private string _title;
            private string _author;
            private int _year;
            protected double _price;

            public int ISBN => _isbnNumber;
            public string Title
            {
                get => _title;
                set => _title = value;
            }
            public string Author
            {
                get => _author;
                set => _author = value;
            }
            public int Year
            {
                get => _year;
                set => _year = value;
            }
            public double Price => _price;
            public Book(string title, string author, int year)
            {
                _isbnNumber = _isbn++;
                _title = title;
                _author = author;
                _year = year;
            }
            public abstract void CalculatePrice();
            public void PrintInfo()
            {
                Console.WriteLine($"ISBN: {ISBN}, Название: {Title}, Автор: {Author}, Год: {Year}, Цена: {Price:C}");
            }
        }
        internal class PaperBook : Book
        {
            private bool _hardCover;

            public bool HardCover
            {
                get => _hardCover;
                set => _hardCover = value;
            }
            public PaperBook(string title, string author, int year, bool hardCover)
                : base(title, author, year)
            {
                _hardCover = hardCover;
                CalculatePrice();
            }
            public override void CalculatePrice()
            {
                _price = 10.0;
                if (_hardCover)
                    _price += 5.0;
            }
        }
        internal class ElectronicBook : Book
        {
            private string _format;
            public string Format
            {
                get => _format;
                set => _format = value;
            }
            public ElectronicBook(string title, string author, int year, string format)
                : base(title, author, year)
            {
                _format = format;
                CalculatePrice();
            }

            public override void CalculatePrice()
            {
                _price = 5.0;
                if (_format.ToLower() == "pdf")
                    _price += 2.0;
                else if (_format.ToLower() == "epub")
                    _price += 1.5;
            }
        }
        internal class AudioBook : Book
        {
            private bool _studioRecording;
            public bool StudioRecording
            {
                get => _studioRecording;
                set => _studioRecording = value;
            }
            public AudioBook(string title, string author, int year, bool studioRecording)
                : base(title, author, year)
            {
                _studioRecording = studioRecording;
                CalculatePrice();
            }
            public override void CalculatePrice()
            {
                _price = 15.0;
                if (_studioRecording)
                    _price += 10.0;
            }
        }
        public static void QuickSort(Book[] books, int left, int right)
        {
            int i = left, j = right;
            Book pivot = books[(left + right) / 2];
            while (i <= j)
            {
                while (books[i].Price > pivot.Price) i++;
                while (books[j].Price < pivot.Price) j--;

                if (i <= j)
                {
                    Book temp = books[i];
                    books[i] = books[j];
                    books[j] = temp;
                    i++;
                    j--;
                }
            }
            if (left < j) QuickSort(books, left, j);
            if (i < right) QuickSort(books, i, right);
        }
        
    }
}