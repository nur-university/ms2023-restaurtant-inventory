using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.Inventory.Domain.Events;
using Restaurant.Inventory.Domain.Model.Transaciones;
using Restaurant.Inventory.Infrastructure.EF.ReadModel;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Infrastructure.EF.Contexts;

internal class ReadDbContext : DbContext
{
    public virtual DbSet<ItemReadModel> Item { set; get; }
    public virtual DbSet<TransaccionReadModel> Transaccion { set; get; }

    public virtual DbSet<TransaccionItemReadModel> TransactionItem { set; get; }
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        
    }
}
