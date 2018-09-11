using System;
using System.Collections.Generic;
using System.Text;

namespace DIExampleMartin
{
    public class BooksController
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }

        public string Book(string name)
        {
            string book = _bookService.Book(name);
            return book.ToUpper();
        }
    }
}
