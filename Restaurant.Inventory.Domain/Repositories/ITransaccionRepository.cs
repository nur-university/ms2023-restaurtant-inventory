using Restaurant.Inventory.Domain.Model.Transaciones;
using Restaurant.SharedKernel.Core;

namespace Restaurant.Inventory.Domain.Repositories;

public interface ITransaccionRepository : IRepository<Transaccion, Guid>
{
    Task UpdateAsync(Transaccion transaccion);
}
