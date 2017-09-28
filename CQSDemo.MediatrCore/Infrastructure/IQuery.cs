using MediatR;

namespace CQSDemo.MediatrCore.Infrastructure
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
