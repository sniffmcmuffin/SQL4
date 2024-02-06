using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class DataCustomerRegistrationDto
{
    // Använd sen detta för createcustomer
}
public class DataCustomerService(DataCustomerRepo dataCustomerRepo)
{
    private readonly DataCustomerRepo _dataCustomerRepo = dataCustomerRepo;
  
    // Create
    public Customer CreateCustomer(string firstName, string lastName, string email, string phone)
    {
        var customerEntity = new Customer
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Phone = phone            
        };

        customerEntity = _dataCustomerRepo.Create(customerEntity);

        return customerEntity; 
    }

    // Read
    public Customer GetCustomerById(int id)
    {
        var customer = _dataCustomerRepo.Get(x => x.Id == id);
        return customer;
    }

    public Customer GetCustomerByEmail(string email)
    {
        var customer = _dataCustomerRepo.Get(x => x.Email == email);
        return customer;
    }

    public IEnumerable<Customer> GetCustomers()
    {
        var customers = _dataCustomerRepo.GetAll();
        return customers;
    }

    // Update
    public Customer UpdateCustomer(Customer customer)
    {
        var updatedCustomer = _dataCustomerRepo.Update(x => x.Id == customer.Id, customer);
        return updatedCustomer;
    }

    // Delete
    public void DeleteCustomer(int id)
    {
        _dataCustomerRepo.Delete(x => x.Id == id);
    }
}