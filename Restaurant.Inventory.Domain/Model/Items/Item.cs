using Restaurant.Inventory.Domain.ValueObjects;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Domain.Model.Items
{
    public class Item : AggregateRoot
    {
        public ItemName Nombre { get; private set; }
        public string Codigo { get; private set; }
        public int Stock { get; set; }
        public CostoValue Costo { get; set; }

        internal Item(string nombre, string codigo)
        {
            Nombre = nombre;
            Codigo = codigo;
            Stock = 0;
            Costo = 0;
        }

        public void Edit(string nombre)
        {
            Nombre = nombre;
        }

        public void ActualizarStockYCostoPromedio(int cantidadAdicional, decimal costoUnitario = 0)
        {
            if (cantidadAdicional > 0)
            {
                Costo = (Costo * Stock + costoUnitario * cantidadAdicional) / Convert.ToDecimal(Stock + cantidadAdicional);
            }
            Stock += cantidadAdicional;
        }
    }
}
