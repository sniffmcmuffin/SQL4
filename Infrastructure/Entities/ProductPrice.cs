using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public partial class ProductPrice
{
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    [Column(TypeName = "money")]
    public decimal? Price { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductPrice")]
    public virtual Product Product { get; set; } = null!;
}
