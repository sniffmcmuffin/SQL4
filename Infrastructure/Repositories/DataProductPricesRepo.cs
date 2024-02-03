using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class DataProductPricesRepo : DataRepo<ProductPrice>
{
    public DataProductPricesRepo(DataContext context) : base(context)
    {
    }
}
