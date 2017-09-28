using System;
using Paramore.Brighter;

namespace CQSDemo.BrighterCore.Worksheet.CreateWorksheet
{
    public class CreateWorksheetCommand : Command
    {
        public Guid WorksheetId { get; }
        public string WorksheetName { get; }
        public int CreatedBy { get; }

        public CreateWorksheetCommand(Guid worksheetId, string worksheetName, int createdByUserId) : base(worksheetId)
        {
            WorksheetId = worksheetId;
            WorksheetName = worksheetName;
            CreatedBy = createdByUserId;
        }
    }
}
