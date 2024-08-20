using Bar.Application.Commands.CreateTable;
using Bar.Application.Commands.DeleteTable;
using Bar.Application.Commands.UpdateTable;
using Bar.Application.Queries.GetTable;
using Bar.Application.Queries.GetTableList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bar.Web.Controllers
{
    [ApiController]
    [Route("api/v1/tables")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class TablesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TablesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Tables
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetList()
        {
            var response = await _mediator.Send(new GetTableListQuery());
            return Ok(response);
        }

        // GET: api/Tables/5
        [HttpGet]
        [Route("{tableId:int}")]
        public async Task<IActionResult> Get([FromRoute] int tableId)
        {
            var response = await _mediator.Send(new GetTableQuery { TableId = tableId });
            return Ok(response);
        }

        // POST: api/Tables
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] CreateTableCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        // PUT: api/Tables/5
        [HttpPut]
        [Route("{tableId:int}")]
        public async Task<IActionResult> Update([FromRoute] int tableId, [FromBody] UpdateTableCommand command)
        {
            command.TableId = tableId;
            await _mediator.Send(command);
            return Ok();
        }

        // DELETE: api/Tables/5
        [HttpDelete]
        [Route("{tableId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int tableId)
        {
            var command = new DeleteTableCommand { TableId = tableId };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
