using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Domain.Exceptions
{
    public class TransactionCreationException :
        Exception
    {
        public TransactionCreationException(string reason)
            : base("La transacción no puede ser creada por que " + reason)
        {
        }
    }
}
