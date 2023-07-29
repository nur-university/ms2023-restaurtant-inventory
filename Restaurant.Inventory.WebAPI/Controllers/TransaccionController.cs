using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Inventory.Application.UseCases.Transacciones.CrearTransaccion;

namespace Restaurant.Inventory.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : Controller
    {

        private readonly IMediator _mediator;

        public TransaccionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertTransaccion([FromBody] CrearTransaccionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}