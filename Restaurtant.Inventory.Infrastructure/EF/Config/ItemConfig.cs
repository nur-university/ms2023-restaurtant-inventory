using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.Inventory.Domain.Model.Items;
using Restaurant.Inventory.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Infrastructure.EF.Config;

internal class ItemConfig : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("item");
        builder.HasKey(x => x.Id);


        builder.Property(x => x.Id)
            .HasColumnName("itemId");

        var nombreConverter = new ValueConverter<ItemName, string>(
            nombreValue => nombreValue.Value,
            nombre => new ItemName(nombre)
        );

        builder.Property(x => x.Nombre)
            .HasConversion(nombreConverter)
            .HasColumnName("nombre");

        var costoConverter = new ValueConverter<CostoValue, decimal>(
            costoValue => costoValue.Value,
            costo => new CostoValue(costo)
        );

        builder.Property(x => x.Costo)
            .HasConversion(costoConverter)
            .HasColumnName("costo");

        builder.Property(x => x.Stock)
            .HasColumnName("stock");

        builder.Ignore("_domainEvents");
        builder.Ignore(x => x.DomainEvents);
    }
}
