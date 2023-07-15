using Restaurant.Inventory.Domain.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Domain.Factories
{
    public class ItemFactory : IItemFactory
    {
        public Item Create(string nombre, string codigo)
        {
            return new Item(nombre, codigo);
        }
    }
}
