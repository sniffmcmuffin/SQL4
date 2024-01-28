using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<AddressEntity> Addresses { get; set; } // Addresses blir namnet i databasen.
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CustromerEntity> Custromers { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
}
