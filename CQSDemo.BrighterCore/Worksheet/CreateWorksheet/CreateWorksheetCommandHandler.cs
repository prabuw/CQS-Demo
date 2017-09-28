using System.Threading;
using System.Threading.Tasks;
using Paramore.Brighter;

namespace CQSDemo.BrighterCore.Worksheet.CreateWorksheet
{
    public class CreateWorksheetCommandHandler : RequestHandlerAsync<CreateWorksheetCommand>
    {
        public override Task<CreateWorksheetCommand> HandleAsync(CreateWorksheetCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            //Store worksheet here

            return base.HandleAsync(command, cancellationToken);
        }
    }
}
