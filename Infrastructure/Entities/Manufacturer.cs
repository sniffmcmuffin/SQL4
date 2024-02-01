using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public partial class Manufacturer
{
    [Key]
    [Column("ManufacturerID")]
    public int ManufacturerId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? ManufacturerName { get; set; }

    [InverseProperty("Manufacturer")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
