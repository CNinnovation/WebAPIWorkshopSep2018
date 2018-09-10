using System;
using System.Collections.Generic;
using System.Text;

namespace DIExampleMartin
{
    public class BookService : IBookService
    {
        public string Book(string name) => $"Buchname, {name}";
    }
}
