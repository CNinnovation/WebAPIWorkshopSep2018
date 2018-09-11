using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Start service");
            Console.ReadLine();
            ConfigureContainer();
            await UseHttpClientAsync();
            Console.WriteLine($"Completed!");
            Console.ReadLine();
        }

        private static void ConfigureContainer() {
            Container = AppServices.Instance.Container;
        }

        public static IServiceProvider Container { get; private set; }

        private async static Task UseHttpClientAsync() {
            var client = Container.GetService<MyHttpClient>();
            await client.ShowAllBooksAsync("/api/Book");
            Console.WriteLine();
        }
    }
}
