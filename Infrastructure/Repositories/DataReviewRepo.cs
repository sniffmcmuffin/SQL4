using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class DataReviewRepo : DataRepo<Review>
{
    public DataReviewRepo(DataContext context) : base(context)
    {
    }
}
