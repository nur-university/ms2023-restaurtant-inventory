using Restaurant.Inventory.Domain.Model.Transaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Domain.Factories
{
    public interface ITransaccionFactory
    {
        Transaccion CrearTransaccionIngreso();
        Transaccion CrearTransaccionSalida();
    }
}
