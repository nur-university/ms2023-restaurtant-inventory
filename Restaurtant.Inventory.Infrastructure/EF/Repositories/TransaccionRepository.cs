using Microsoft.EntityFrameworkCore;
using Restaurant.Inventory.Domain.Model.Transaciones;
using Restaurant.Inventory.Domain.Repositories;
using Restaurtant.Inventory.Infrastructure.EF.Contexts;

namespace Restaurtant.Inventory.Infrastructure.EF.Repositories;

internal class TransaccionRepository : ITransaccionRepository
{
    public readonly DbSet<Transaccion> _transacciones;

    public TransaccionRepository(WriteDbContext context)
    {
        _transacciones = context.Transaccion;
    }

    public async Task CreateAsync(Transaccion obj)
    {
        await _transacciones.AddAsync(obj);
    }

    public async Task<Transaccion?> FindByIdAsync(Guid id)
    {
        return await _transacciones.Include("_items")
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public Task UpdateAsync(Transaccion transaccion)
    {
        _transacciones.Update(transaccion);

        return Task.CompletedTask;
    }
}
