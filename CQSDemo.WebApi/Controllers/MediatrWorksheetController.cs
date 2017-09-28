using System;
using System.Threading.Tasks;
using System.Web.Http;
using CQSDemo.MediatrCore.Worksheet.CreateWorksheet;
using CQSDemo.MediatrCore.Worksheet.GetWorksheetById;
using CQSDemo.WebApi.Models;
using MediatR;

namespace WebApi.Controllers
{
    [RoutePrefix("api/mediatrworksheet")]
    public class MediatrWorksheetController : ApiController
    {
        private readonly IMediator _mediator;

        public MediatrWorksheetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="worksheetId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{worksheetId}", Name = "GetWorksheetMediatr")]
        public async Task<IHttpActionResult> Get(Guid worksheetId)
        {
            var query = new GetWorksheetByIdQuery(worksheetId);
            var worksheet = await _mediator.Send(query);

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
            await _mediator.Send(command);

            return CreatedAtRoute("GetWorksheetMediatr", new { worksheetId = worksheetId }, worksheetId);
        }
    }
}
