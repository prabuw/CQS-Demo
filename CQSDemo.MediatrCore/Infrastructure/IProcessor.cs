using System.Threading;
using System.Threading.Tasks;

namespace CQSDemo.MediatrCore.Infrastructure
{
    public interface IProcessor
    {
        Task Send(ICommand query, CancellationToken cancellationToken = default(CancellationToken));
        Task<T> Query<T>(IQuery<T> query, CancellationToken cancellationToken = default(CancellationToken));
        Task Publish(IEvent @event, CancellationToken cancellationToken = default(CancellationToken));
    }
}
