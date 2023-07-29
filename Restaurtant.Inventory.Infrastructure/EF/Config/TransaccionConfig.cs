using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.Inventory.Domain.Model.Transaciones;
using Restaurant.Inventory.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Infrastructure.EF.Config;

internal class TransaccionConfig : IEntityTypeConfiguration<Transaccion>,
        IEntityTypeConfiguration<TransaccionItem>
{

    public void Configure(EntityTypeBuilder<Transaccion> builder)
    {
        builder.ToTable("transaccion");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("transaccionId");

        builder.Property(x => x.FechaRegistro)
            .HasColumnName("fechaRegistro");

        builder.Property(x => x.FechaConfirmacion)
            .HasColumnName("fechaConfirmacion");

        builder.Property(x => x.FechaAnulacion)
             .HasColumnName("fechaAnulacion");

        var tipoConverter = new ValueConverter<TipoTransaccion, string>(
            tipoEnumValue => tipoEnumValue.ToString(),
            tipo => (TipoTransaccion)Enum.Parse(typeof(TipoTransaccion), tipo)
        );

        builder.Property(x => x.Tipo)
             .HasConversion(tipoConverter)
             .HasColumnName("tipo")
             .HasMaxLength(20)
             .IsRequired();


        var estadoConverter = new ValueConverter<EstadoTransaccion, string>(
            estadoEnumValue => estadoEnumValue.ToString(),
            estado => (EstadoTransaccion)Enum.Parse(typeof(EstadoTransaccion), estado)
        );

        builder.Property(x => x.Estado)
             .HasConversion(estadoConverter)
             .HasColumnName("estado")
             .HasMaxLength(20)
             .IsRequired();

        builder.HasMany(typeof(TransaccionItem), "_items");

        builder.Ignore("_domainEvents");
        builder.Ignore(x => x.DomainEvents);
        builder.Ignore(x => x.Items);
    }
    public void Configure(EntityTypeBuilder<TransaccionItem> builder)
    {
        builder.ToTable("transaccionItem");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("transaccionItemId");

        var cantidadConverter = new ValueConverter<CantidadTransaccion, int>(
            cantidadValue => cantidadValue.Cantidad,
            cantidad => new CantidadTransaccion(cantidad)
        );

        builder.Property(x => x.Cantidad)
            .HasColumnName("cantidad")
            .HasConversion(cantidadConverter);

        var costoInventarioConverter = new ValueConverter<CostoValue, decimal>(
            costoValue => costoValue.Value,
            costo => new CostoValue(costo)
        );

        builder.Property(x => x.CostoUnitario)
            .HasColumnName("costoUnitario")
            .HasConversion(costoInventarioConverter);

        builder.Property(x => x.CostoTotal)
            .HasConversion(costoInventarioConverter)
            .HasColumnName("costoTotal");

        builder.Ignore("_domainEvents");
        builder.Ignore(x => x.DomainEvents);
    }
}
