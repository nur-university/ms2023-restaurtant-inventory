using MediatR;
using Restaurant.Inventory.Application.Dto.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Application.UseCases.Items.Query.GetItemList
{
    public class GetItemListQuery : IRequest<ICollection<ItemDto>>
    {
        public string SearchTerm { get; set; }

    }
}
