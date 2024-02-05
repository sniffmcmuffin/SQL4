using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class DataManufacturerRepo : DataRepo<Manufacturer>
{
    public DataManufacturerRepo(ApplicationDataContext context) : base(context)
    {
    }
}
