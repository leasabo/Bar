using Bar.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bar.Application.Commands;

namespace Bar.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TablesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TablesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable(CreateTableCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // Similar endpoints for Get, Update, Delete operations
    }
}
