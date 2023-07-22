using Restaurant.Inventory.Domain.ValueObjects;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Domain.Model.Transaciones
{
    public class TransaccionItem : Entity
    {
        public Guid ItemId { get; private set; }
        public CantidadTransaccion Cantidad { get; private set; }
        public CostoValue CostoUnitario { get; private set; }
        public CostoValue CostoTotal  { get; private set; }

        internal TransaccionItem(Guid itemId, int cantidad, decimal costoUnitario)
        {
            Id = Guid.NewGuid();
            ItemId = itemId;
            Cantidad = cantidad;
            CostoUnitario = costoUnitario;
            CostoTotal = cantidad * costoUnitario;
        }

        private TransaccionItem() { }
    }
}
