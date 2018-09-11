using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace DIExampleMartin
{
    public class AppService
    {
        private static AppService s_instance;
        public static AppService Instance => s_instance ?? (s_instance = GetInstance());

        private static AppService GetInstance()
        {
            var appService = new AppService();
            appService.Configure();
            return appService;
        }

        private void Configure()
        {
            var service = new ServiceCollection();
            service.AddTransient<IBookService, BookService>();
            service.AddTransient<BooksController>();
            Container = service.BuildServiceProvider();
        }

        public ServiceProvider Container { get; private set; }
    }
}
