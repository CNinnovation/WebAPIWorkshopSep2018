using System;
using System.Threading.Tasks;
using ClientApp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Client - wait for service");
            Console.ReadLine();
            ConfigureContainer();
            await UseHttpClientAsync();
            Console.WriteLine("Completed");
            Console.ReadLine();
        }

        private static void ConfigureContainer()
        {
            Container = AppServices.Instance.Container;
        }

        public static IServiceProvider Container { get; private set; }

        private async static Task UseHttpClientAsync()
        {
            var client = Container.GetService<MyHttpClient>();
            await client.ShowAllBooksAsync("/api/Books");
            Console.WriteLine();
            Console.WriteLine("adding a book");
            await client.AddBookAsync("/api/Books", new Book { Title = "Enterprise Services", Publisher = "AWL" });
            await client.ShowAllBooksAsync("/api/Books");
        }
    }
}
