using System;
using Microsoft.Extensions.DependencyInjection;

namespace DISample
{
    class Program
    {
        static void Main(string[] args)
        {

            //  var controller = new GreetingController(new GreetingService());
            var controller = AppServices.Instance.Container.GetService<GreetingController>();
            string greet = controller.Hello("Stephanie");
            Console.WriteLine(greet);
        }
    }
}
