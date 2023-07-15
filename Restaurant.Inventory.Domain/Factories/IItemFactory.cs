using Restaurant.Inventory.Domain.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Domain.Factories
{
    public interface IItemFactory 
    {
        Item Create(string nombre, string codigo);
    }
}
