using Restaurant.Inventory.Domain.Model.Items;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Domain.Repositories;

public interface IItemRepository : IRepository<Item, Guid>
{
    Task UpdateAsync(Item item);

}
