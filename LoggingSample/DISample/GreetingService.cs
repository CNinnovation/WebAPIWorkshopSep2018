using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DISample
{
    public class GreetingService : IGreetingService
    {
        private readonly ILogger<GreetingService> _logger;
        public GreetingService(ILogger<GreetingService> logger)
        {
            _logger = logger;
        }
        public string Hello(string name)
        {
            // _logger.Log(LogLevel.Trace, "Hello invoked", name);
            _logger.LogTrace("Hello invoked", name);
            return $"Hello, {name}";
        }
    }
}
