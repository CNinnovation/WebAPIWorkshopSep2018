using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBooksApp.Models;

namespace MyBooksApp.Services
{
    public class BooksDBService : IBooksService
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

        public bool DeleteBook(Book book)
        {
            _booksContext.Books.Remove(book);
            int changed = _booksContext.SaveChanges();
            return changed == 1;
        }

        public Book GetBookById(int id)
        {
            return _booksContext.Books.Find(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _booksContext.Books.Take(100);
        }

        public void UpdateBook(Book book)
        {
            _booksContext.Books.Update(book);
            _booksContext.SaveChanges();
        }
    }
}
