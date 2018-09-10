using System;
using Microsoft.Extensions.DependencyInjection;

namespace DIExampleMartin
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variante 1 ohne AppService
            //var controller = new BooksController(new BookService());

            // Variante 2 mit AppService
            var controller = AppService.Instance.Container.GetService<BooksController>();

            string book = controller.Book("Das ist mein erstes Buch");
            Console.WriteLine(book);
        }
    }
}
