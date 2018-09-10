using MyBookApp.Models;
using System.Collections.Generic;

namespace MyBookApp.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();
        void AddBook(Book book);
        Book GetBookById(int id);
    }
}