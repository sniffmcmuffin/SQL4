using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class DataProductRepo : DataRepo<Product>
{
    public DataProductRepo(DataContext context) : base(context)
    {
    }
}
