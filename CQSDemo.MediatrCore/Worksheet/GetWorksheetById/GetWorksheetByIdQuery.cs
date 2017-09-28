using System;
using MediatR;

namespace CQSDemo.MediatrCore.Worksheet.GetWorksheetById
{
    //The generic type in IRequest represents the return type
    //This facilitates the command and query types
    //Unit represents a null return type - for commands
    public class GetWorksheetByIdQuery : IRequest<Entities.Worksheet>
    {
        public Guid WorksheetId { get; }

        public GetWorksheetByIdQuery(Guid worksheetId)
        {
            WorksheetId = worksheetId;
        }
    }
}
