using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConfigurationSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureApp(args);
            ReadConfig();
        }

        private static void ReadConfig()
        {
            var section = Configuration.GetSection("MyConfig");
            var value = section["Config1"];
            Console.WriteLine($"read from config: {value}");
            var val2 = Configuration["Config2"];
            Console.WriteLine($"read config1 {val2}");

            var conn1 = Configuration.GetConnectionString("Conn1");
            Console.WriteLine(conn1);
        }

        private static void ConfigureApp(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.development.json", optional: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args);

#if DEBUG
            builder.AddUserSecrets("MyConfigurationSample");
#endif

            Configuration = builder.Build();
        }

        public static IConfigurationRoot Configuration { get; private set; }
    }
}
