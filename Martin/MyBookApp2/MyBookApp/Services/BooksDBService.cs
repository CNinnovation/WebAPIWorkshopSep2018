using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBookApp.Models;

namespace MyBookApp.Services
{
    public class BooksDBService : IBookService
    {
        private readonly BooksContext _booksContext;

        public BooksDBService(BooksContext booksContext)
        {
            _booksContext = booksContext ?? throw new ArgumentNullException(nameof(booksContext));
        }

        public void AddBook(Book book)
        {
            _booksContext.Books.Add(book);
            _booksContext.SaveChanges();
        }

        public Book GetBookById(int id)
        {
            return _booksContext.Books.Find(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _booksContext.Books.Take(100);
        }
    }
}
