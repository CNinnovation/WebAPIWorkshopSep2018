using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DISample
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
            services.AddTransient<IGreetingService, GreetingService>();
            services.AddTransient<GreetingController>();
            Container = services.BuildServiceProvider();
        }

        public ServiceProvider Container { get; private set; }
    }
}
