using System.Threading.Tasks;
using MediatR;

namespace CQSDemo.MediatrCore.Worksheet.CreateWorksheet
{
    public class CreateWorksheetCommandHandler : IAsyncRequestHandler<CreateWorksheetCommand>
    {
        public async Task Handle(CreateWorksheetCommand message)
        {
            //Store worksheet in database
        }
    }
}
