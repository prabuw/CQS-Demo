using System;
using System.Threading.Tasks;
using System.Web.Http;
using CQSDemo.BrighterCore.Worksheet.CreateWorksheet;
using CQSDemo.BrighterCore.Worksheet.GetWorksheetById;
using CQSDemo.WebApi.Models;
using Paramore.Brighter;
using Paramore.Darker;

namespace WebApi.Controllers
{
    [RoutePrefix("api/brighterworksheet")]
    public class BrighterWorksheetController : ApiController
    {
        private readonly IAmACommandProcessor _commandProcessor;
        private readonly IQueryProcessor _queryProcessor;

        public BrighterWorksheetController(
            IAmACommandProcessor commandProcessor,
            IQueryProcessor queryProcessor)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="worksheetId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{worksheetId}", Name = "GetWorksheetBrighter")]
        public async Task<IHttpActionResult> Get(Guid worksheetId)
        {
            var query = new GetWorksheetByIdQuery(worksheetId);
            var worksheet = await _queryProcessor.ExecuteAsync(query);

            return Ok(worksheet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post(CreateWorksheetRequest request)
        {
            var userIdOnPrincipal = 210;
            var worksheetId = new Guid();

            var command = new CreateWorksheetCommand(worksheetId, request.WorksheetName, userIdOnPrincipal);
            await _commandProcessor.SendAsync(command);

            return CreatedAtRoute("GetWorksheetBrighter", new { worksheetId = worksheetId }, worksheetId);
        }
    }
}
