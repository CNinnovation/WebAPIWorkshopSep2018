using MyBooksApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksApp.Services
{
    public class BooksService : IBooksService
    {
        public IEnumerable<Book> GetBooks() =>
            new List<Book>()
            {
                new Book { BookId = 1, Title = "Professional C# 7 and .NET Core 2.0", Publisher = "Wrox Press"},
                new Book { BookId = 2, Title = "Professional C# 6 and .NET Core 1.0", Publisher = "Wrox Press"},
            };
    }
}
