using System;
using Paramore.Darker;

namespace CQSDemo.BrighterCore.Worksheet.GetWorksheetById
{
    //The generic type in IRequest represents the return type
    //This facilitates the command and query types
    //Unit represents a null return type - for commands
    public class GetWorksheetByIdQuery : IQuery<Entities.Worksheet>
    {
        public Guid WorksheetId { get; }

        public GetWorksheetByIdQuery(Guid worksheetId)
        {
            WorksheetId = worksheetId;
        }
    }
}
