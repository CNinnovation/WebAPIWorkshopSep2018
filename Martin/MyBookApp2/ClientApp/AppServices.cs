using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ClientApp
{
    public class AppServices
    {
        private static AppServices s_instance;
        public static AppServices Instance => s_instance ?? (s_instance = GetInstance());

        private static AppServices GetInstance() 
        {
            var appServices = new AppServices();
            appServices.Configure();
            return appServices;
        }

        private void Configure()
        {
            var services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder.AddFilter((category, level) => true);
                builder.AddConsole();
                builder.AddDebug();
            });

            services.AddHttpClient<MyHttpClient>(config =>
            {
                //config.BaseAddress = new Uri("http://localhost:5000");
                config.BaseAddress = new Uri("http://localhost:53255");
            }).AddTypedClient<MyHttpClient>();

            Container = services.BuildServiceProvider();
        }

        public ServiceProvider Container { get; private set;  }
    }
}
