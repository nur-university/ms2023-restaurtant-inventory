using Restaurant.Inventory.Domain.Factories;
using Restaurant.Inventory.Domain.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Test.Application.UseCases.Items.EventHandlers
{
    internal class ItemMockFactory
    {
        public static List<Item> getItems()
        {
            return new List<Item>
            {
                 new ItemFactory().Create("Item 1", "I1"),
                 new ItemFactory().Create("Item 2", "I2"),
                 new ItemFactory().Create("Item 3", "I3")
            };
        }
    }
}
