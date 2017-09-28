using System.Threading.Tasks;
using MediatR;

namespace CQSDemo.MediatrCore.Worksheet.GetWorksheetById
{
    public class GetWorksheetByIdQueryHandler : IAsyncRequestHandler<GetWorksheetByIdQuery, Entities.Worksheet>
    {
        public async Task<Entities.Worksheet> Handle(GetWorksheetByIdQuery message)
        {
            //Store worksheet in database

            return new Entities.Worksheet();
        }
    }
}
