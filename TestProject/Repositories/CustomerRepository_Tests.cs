using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit; // Ensure you have the correct using directive for Xunit

namespace TestProject.Repositories
{
    public class CustomerRepository_Tests
    {
        private readonly DataContext _context = new DataContext(new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .Options);

        [Fact] 
        public async Task Create_ShouldAddOneCustomerEntityToDataBaseAndReturnUpdateCustomerEntity()
        {
            // Arrange
            var customerRepository = new CustomerRepository(_context);
            var customerEntity = new CustomerEntity
            {
                Id = 1,
                FirstName = "test",
                LastName = "test",
                Email = "test",
                RoleId = 1,
            };

            // Act
            var result = await customerRepository.CreateAsync(customerEntity);

            // Assert 
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }
    }
}
