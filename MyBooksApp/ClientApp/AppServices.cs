using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApp
{
    public class AppServices
    {
        private AppServices()
        {

        }

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
                config.BaseAddress = new Uri("http://localhost:54164");
                // config.BaseAddress = new Uri("http://localhost:54167");
            })
           // .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(4) }))
            .AddTypedClient<MyHttpClient>();


            Container = services.BuildServiceProvider();
        }

        public ServiceProvider Container { get; private set; }
    }
}
