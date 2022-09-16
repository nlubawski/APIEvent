using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace APIEvent.Filters
{

    public class LogResourceFilterTime : IResourceFilter
    {
        Stopwatch time = new Stopwatch();
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            time.Stop();
            Console.WriteLine($"Tempo do processo: {time.ElapsedMilliseconds} milissegundos");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            time.Start();
        }
    }
}


