using System;
using System.Collections.Generic;
using System.Text;

namespace DISample
{
    public class GreetingController
    {
        private readonly IGreetingService _helloService;
        public GreetingController(IGreetingService helloService)
        {
            _helloService = helloService ?? throw new ArgumentNullException(nameof(helloService));
        }

        public string Hello(string name)
        {
            string greeting = _helloService.Hello(name);
            return greeting.ToUpper();
        }
    }
}
