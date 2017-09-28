using System.Diagnostics;
using System.Threading.Tasks;
using MediatR;

namespace CQSDemo.MediatrCore.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next)
        {
            Trace.WriteLine($"Handling {typeof(TRequest).Name}");

            var response = await next();

            Trace.WriteLine($"Handled {typeof(TRequest).Name}");

            return response;
        }
    }
}
