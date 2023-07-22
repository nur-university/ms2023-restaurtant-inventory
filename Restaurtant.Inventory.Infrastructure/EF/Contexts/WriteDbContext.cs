using Microsoft.EntityFrameworkCore;
using Restaurant.Inventory.Domain.Events;
using Restaurant.Inventory.Domain.Model.Items;
using Restaurant.Inventory.Domain.Model.Transaciones;
using Restaurant.Inventory.Infrastructure.EF.Config;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurtant.Inventory.Infrastructure.EF.Contexts
{
    internal class WriteDbContext : DbContext
    {
        public virtual DbSet<Item> Item { set; get; }
        public virtual DbSet<Transaccion> Transaccion { set; get; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var itemConfig = new ItemConfig();
            modelBuilder.ApplyConfiguration(itemConfig);

            var transaccionConfig = new TransaccionConfig();
            modelBuilder.ApplyConfiguration<Transaccion>(transaccionConfig);
            modelBuilder.ApplyConfiguration<TransaccionItem>(transaccionConfig);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<TransaccionConfirmada>();
        }
    }
}
