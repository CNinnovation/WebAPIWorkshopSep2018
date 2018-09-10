using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DISample
{
    public class GreetingController
    {
        private readonly IGreetingService _helloService;
        private readonly ILogger<GreetingController> _logger;
        public GreetingController(IGreetingService helloService, ILogger<GreetingController> logger)
        {
            _helloService = helloService ?? throw new ArgumentNullException(nameof(helloService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public string Hello(string name)
        {
            _logger.LogError("error in hello");
            string greeting = _helloService.Hello(name);
            return greeting.ToUpper();
        }
    }
}
