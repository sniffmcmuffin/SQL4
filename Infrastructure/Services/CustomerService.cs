using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class CustomerRegistrationDto
{
    // Använd sen detta för createcustomer
}
public class CustomerService(CustomerRepository customerRepository, AddressService addressService, RoleService roleService)
{
    private readonly CustomerRepository _customerRepository = customerRepository;
    private readonly AddressService _addressService = addressService;
    private readonly RoleService _roleService = roleService;

    // Create
    public async Task<CustomerEntity> CreateCustomerAsync(string firstName, string lastName, string email, string roleName, string streetName, string postalCode, string city)
    {
        // Beroenden först och här så fattar jag vad som jag gjort fel med min egna kod i egna försök.
        var roleEntity = await _roleService.CreateRoleAsync(roleName); // Add await and async here when those are added.
        var addressEntity = await _addressService.CreateAddressAsync(streetName, postalCode, city);

        var customerEntity = new CustomerEntity
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            RoleId = roleEntity.Id,
            AddressId = addressEntity.Id,
        };

        customerEntity = await _customerRepository.CreateAsync(customerEntity);
        return customerEntity; // Funkar detta så blir jag överlycklig.
    }


    // Read
    public CustomerEntity GetCustomerById(int id)
    {
        var customerEntity = _customerRepository.Get(x => x.Id == id);
        return customerEntity;
    }

    public CustomerEntity GetCustomerByEmail(string email)
    {
        var customerEntity = _customerRepository.Get(x => x.Email == email);
        return customerEntity;
    }

    public IEnumerable<CustomerEntity> GetCustomers()
    {
        var customers = _customerRepository.GetAll();
        return customers;
    }

    // Update
    public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
    {
        var updatedCustomerEntity = _customerRepository.Update(x => x.Id == customerEntity.Id, customerEntity);
        return updatedCustomerEntity;
    }

    // Delete
    public void DeleteCustomer(int id) 
    {
        _customerRepository.Delete(x => x.Id == id);
    }
}
