using System.Collections.Generic;
using MyBooksApp.Models;

namespace MyBooksApp.Services
{
    public interface IBooksService
    {
        IEnumerable<Book> GetBooks();
    }
}