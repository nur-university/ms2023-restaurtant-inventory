using Restaurant.Inventory.Domain.Model.Transaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Infrastructure.EF.ReadModel;

[Table("transaccion")]
internal class TransaccionReadModel
{
    [Key]
    [Column("transaccionId")]
    public Guid Id { get; set; }

    [Required]
    [Column("fechaRegistro")]
    public DateTime FechaRegistro { get; set; }


    [Column("fechaConfirmacion")]
    [AllowNull]
    public DateTime? FechaConfirmacion { get; set; }

    [AllowNull]
    [Column("fechaAnulacion")]
    public DateTime? FechaAnulacion { get; set; }

    [Required]
    [Column("tipo") ]
    [MaxLength(25)]
    public string Tipo { get; set; }

    [Required]
    [Column("estado")]
    [MaxLength(25)]
    public string Estado { get; set; }

    public List<TransaccionItemReadModel> Items { get; set; }

}
