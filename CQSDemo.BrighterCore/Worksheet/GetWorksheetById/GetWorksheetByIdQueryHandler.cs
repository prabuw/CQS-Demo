using System.Threading;
using System.Threading.Tasks;
using Paramore.Darker;

namespace CQSDemo.BrighterCore.Worksheet.GetWorksheetById
{
    public class GetWorksheetByIdQueryHandler : QueryHandlerAsync<GetWorksheetByIdQuery, Entities.Worksheet>
    {
        public override Task<Entities.Worksheet> ExecuteAsync(GetWorksheetByIdQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            //Read data from db etc.

            throw new System.NotImplementedException();
        }
    }
}
