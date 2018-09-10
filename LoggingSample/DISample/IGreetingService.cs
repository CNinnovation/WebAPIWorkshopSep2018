using Microsoft.Extensions.Logging;

namespace DISample
{
    public interface IGreetingService
    {
        string Hello(string name);
    }
}