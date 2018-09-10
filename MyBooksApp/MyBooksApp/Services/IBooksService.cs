using System.Collections.Generic;
using MyBooksApp.Models;

namespace MyBooksApp.Services
{
    public interface IBooksService
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        bool DeleteBook(Book book);
    }
}