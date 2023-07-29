using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Inventory.Application.Dto.Item;
using Restaurant.Inventory.Application.UseCases.Items.Query.GetItemList;
using Restaurant.Inventory.Domain.Model.Items;
using Restaurant.Inventory.Infrastructure.EF.Contexts;
using Restaurant.Inventory.Infrastructure.EF.ReadModel;

namespace Restaurtant.Inventory.Infrastructure.UseCases.Item.Query;

internal class GetItemListHandler :
    IRequestHandler<GetItemListQuery, ICollection<ItemDto>>
{
    private readonly DbSet<ItemReadModel> _items;

    public GetItemListHandler(ReadDbContext context)
    {
        _items = context.Item;
    }

    public async Task<ICollection<ItemDto>> Handle(GetItemListQuery request, CancellationToken cancellationToken)
    {
        var query = _items.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {            
            query = query.Where(x => x.Nombre.Contains(request.SearchTerm));            
        }
        
        return await query.Select(item => 
            new ItemDto
            {
                ItemId = item.Id,
                Nombre = item.Nombre,
                Codigo = item.Codigo
            }).ToListAsync(cancellationToken);
    }

}
