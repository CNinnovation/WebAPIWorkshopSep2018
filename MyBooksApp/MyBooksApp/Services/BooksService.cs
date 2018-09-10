using MyBooksApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksApp.Services
{
    public class BooksService : IBooksService
    {
        private List<Book> _books =
            new List<Book>()
            {
                new Book { BookId = 1, Title = "Professional C# 7 and .NET Core 2.0", Publisher = "Wrox Press"},
                new Book { BookId = 2, Title = "Professional C# 6 and .NET Core 1.0", Publisher = "Wrox Press"},
            };

        public IEnumerable<Book> GetBooks() => _books;

        public Book GetBookById(int id) => _books.SingleOrDefault(b => b.BookId == id);

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            Book orig = _books.Find(b => b.BookId == book.BookId);
            if (orig == null)
            {
                throw new InvalidOperationException($"book with id {book.BookId} not found");
            }
            _books.Remove(orig);
            _books.Add(book);
        }

        public bool DeleteBook(Book book)
        {
            bool removed = _books.Remove(book);
            return removed;
        }

    }
}
