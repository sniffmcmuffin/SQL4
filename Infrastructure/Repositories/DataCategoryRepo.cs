using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class DataCategoryRepo : DataRepo<Category>
{
    public DataCategoryRepo(DataContext context) : base(context)
    {
    }
}
