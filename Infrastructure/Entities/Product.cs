using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public partial class Product
{
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? ProductName { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [Column("CategoryID")]
    public int? CategoryId { get; set; }

    [Column("ManufacturerID")]
    public int? ManufacturerId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category? Category { get; set; }

    [ForeignKey("ManufacturerId")]
    [InverseProperty("Products")]
    public virtual Manufacturer? Manufacturer { get; set; }

    [InverseProperty("Product")]
    public virtual ProductPrice? ProductPrice { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
