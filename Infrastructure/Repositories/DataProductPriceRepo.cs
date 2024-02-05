using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class DataProductPriceRepo : DataRepo<ProductPrice>
{
    public DataProductPriceRepo(ApplicationDataContext context) : base(context)
    {
    }
}
