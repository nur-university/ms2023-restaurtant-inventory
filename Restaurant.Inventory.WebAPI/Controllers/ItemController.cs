using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Inventory.Application.UseCases.Items.Command.CrearItem;
using Restaurant.Inventory.Application.UseCases.Items.Query.GetItemList;

namespace Restaurant.Inventory.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem([FromBody] CrearItemCommand command)
    {
        var itemId = await _mediator.Send(command);
        
        return Ok(itemId);
    }

    [HttpGet]
    public async Task<IActionResult> SearchItems(string searchTerm = "")
    {
        var items = await _mediator.Send(new GetItemListQuery()
        {
            SearchTerm = searchTerm
        });

        return Ok(items);
    }
}
