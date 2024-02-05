using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class DataCustomerRepo : DataRepo<Customer>
{
    public DataCustomerRepo(ApplicationDataContext context) : base(context)
    {
    }
}
