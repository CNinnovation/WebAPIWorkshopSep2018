using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBookApp.Models;

namespace MyBookApp.Services
{
    public class BookService : IBookService
    {
        private List<Book> _books =
            new List<Book>()
            {
                new Book { BookId = 100, Title = ".net Core 2.1", Publisher ="Martin Kuenz"},
                new Book { BookId = 10, Title = ".net Core 2.0", Publisher ="Martin Kuenz"}
            };

        public IEnumerable<Book> GetBooks() => _books;

        public Book GetBookById(int id) => _books.SingleOrDefault(b => b.BookId == id);

        public void AddBook(Book book)
        {
            _books.Add(book);
        }
    }
}
