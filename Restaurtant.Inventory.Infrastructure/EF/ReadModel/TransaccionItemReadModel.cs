using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Inventory.Infrastructure.EF.ReadModel;

[Table("transaccionItem")]
internal class TransaccionItemReadModel
{
    [Key]
    [Column("transaccionItemId")]
    public Guid Id { get; set; }

    [Required]
    [Column("itemId")]
    public Guid ItemId { get; set; }
    public ItemReadModel Item { get; set; }

    [Required]
    [Column("transaccionId")]
    public Guid TransaccionId { get; set; }
    public TransaccionReadModel Transaccion { get; set; }

    [Required]
    [Column("cantidad")]
    public int Cantidad { get; set; }

    [Required]
    [Column("costoUnitario", TypeName = "decimal(18,2)")]
    public decimal CostoUnitario { get; set; }

    [Required]
    [Column("costoTotal", TypeName = "decimal(18,2)")]
    public decimal CostoTotal { get; set; }
}
