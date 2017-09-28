using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace CQSDemo.MediatrCore.Infrastructure
{
    public class Processor : IProcessor
    {
        private readonly IMediator _mediator;

        public Processor(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Send(ICommand query, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.Send(query, cancellationToken);
        }

        public async Task<T> Query<T>(IQuery<T> query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _mediator.Send(query, cancellationToken);
        }

        public async Task Publish(IEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.Publish(@event, cancellationToken);
        }
    }
}
