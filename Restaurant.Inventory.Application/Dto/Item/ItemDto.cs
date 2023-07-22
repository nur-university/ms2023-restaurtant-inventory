using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Application.Dto.Item
{
    public class ItemDto
    {
        public Guid ItemId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public int Stock { get; set; }
    }
}
