using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class RoleRepository(DataContext context) : BaseRepository<RoleEntity>(context)
{
}
