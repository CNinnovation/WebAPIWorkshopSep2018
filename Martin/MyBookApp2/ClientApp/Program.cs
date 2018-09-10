using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ConfigureContainer();
            await UseHttpClientAsync();
        }

        private static void ConfigureContainer() {
            Container = AppServices.Instance.Container;
        }

        public static IServiceProvider Container { get; private set; }

        private async static Task UseHttpClientAsync() {
            var client = Container.GetService<MyHttpClient>();
            await client.ShowAllBooksAsync("/api/Books");
            Console.WriteLine();
        }
    }
}
