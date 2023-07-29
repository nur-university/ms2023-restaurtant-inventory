using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Application.Dto.Transaccion
{
    public class ItemDetalleTransaccionDto
    {
        public Guid Id { get; set; }
        public decimal CostoUnitario { get; set; }
        public int Cantidad { get; set; }
    }
}
