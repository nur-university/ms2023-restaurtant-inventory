using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Application.UseCases.Item.Command.CrearItem
{
    public class CrearItemCommand : IRequest<Guid>
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }

    }
}
