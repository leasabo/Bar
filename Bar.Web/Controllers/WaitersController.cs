using Bar.Infraestructure.Context;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Bar.Application.Commands;

namespace Bar.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaitersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WaitersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWaiter(CreateWaiterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetWaiters()
        {
            // TODO: Completar
            return Ok(); // Placeholder
        }
    }
}
