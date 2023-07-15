using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Domain.Model.Transaciones
{
    public record CantidadTransaccion : ValueObject
    {
        public int Cantidad { get; private set; }

        internal CantidadTransaccion(int cantidad)
        {
            if(cantidad <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor a cero");
            }
            Cantidad = cantidad;
        }

        public static implicit operator int(CantidadTransaccion cantidad) => cantidad.Cantidad;

        public static implicit operator CantidadTransaccion(int cantidad) => new(cantidad);
    }
}
