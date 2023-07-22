using Restaurant.Inventory.Domain.Model.Transaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Domain.Factories
{
    public class TransaccionFactory : ITransaccionFactory
    {
        public Transaccion CrearTransaccionIngreso()
        {
            return new Transaccion(TipoTransaccion.Ingreso);
        }

        public Transaccion CrearTransaccionSalida()
        {
            return new Transaccion(TipoTransaccion.Salida);
        }
    }
}
