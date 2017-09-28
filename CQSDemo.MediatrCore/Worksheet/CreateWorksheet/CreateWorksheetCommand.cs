using System;
using MediatR;

namespace CQSDemo.MediatrCore.Worksheet.CreateWorksheet
{
    //The generic type in IRequest represents the return type
    //This facilitates the command and query types
    //Unit represents a null return type - for commands
    public class CreateWorksheetCommand : IRequest
    {
        public Guid WorksheetId { get; }
        public string WorksheetName { get; }
        public int CreatedBy { get; }

        public CreateWorksheetCommand(Guid worksheetId, string worksheetName, int createdByUserId)
        {
            WorksheetId = worksheetId;
            WorksheetName = worksheetName;
            CreatedBy = createdByUserId;
        }
    }
}
