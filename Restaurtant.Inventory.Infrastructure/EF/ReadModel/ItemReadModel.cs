using Restaurant.Inventory.Domain.Model.Items;
using Restaurant.Inventory.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Infrastructure.EF.ReadModel;

[Table("item")]
internal class ItemReadModel
{
    [Key]
    [Column("itemId")]
    public Guid Id { get; set; }
    
    [Column("nombre")]
    [StringLength(250)]
    [Required]
    public string Nombre { get; set; }
    
    [Column("codigo")]
    [StringLength(10)]
    [Required]
    public string Codigo { get; set; }
    
    [Column("stock")]
    [Required]
    public int Stock { get; set; }

    [Column("costo", TypeName = "decimal(18,2)")]
    [Required]
    public decimal Costo { get; set; }
}
