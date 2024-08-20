using Bar.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Bar.Application.Commands;

namespace Bar.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReceiptsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReceipt(CreateReceiptCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // TODO: Crear los demás
    }
}
