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
        public async Task CreateAsync_ShouldCreateSaveRecordToDatabase_ReturnCustomerEntityWithId_1()
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

        [Fact]
        public async Task CreateAsync_ShouldNotSaveRecordToDatabase_ReturnNull()
        {
            // Arrange
            var customerRepository = new CustomerRepository(_context);
            var customerEntity = new CustomerEntity();

            // Act
            var result = await customerRepository.CreateAsync(customerEntity);

            // Assert 
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllAsync_ShouldGetAllRecords_ReturnIEnumerableOfTypeCustomerEntity()
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
            await customerRepository.CreateAsync(customerEntity);

            // Act
            var result = await customerRepository.GetAllAsync();

            // Assert 
            Assert.NotNull(result); 
            Assert.IsAssignableFrom<IEnumerable<CustomerEntity>>(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task GetAsync_ShouldGetOneCustomerByEmail_ReturnOneCustomer()
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
            await customerRepository.CreateAsync(customerEntity);

            // Act
            var result = await customerRepository.GetAsync(x => x.Email == customerEntity.Email);

            // Assert 
            Assert.NotNull(result);
            Assert.Equal(customerEntity.Email, result.Email); 
        }

        [Fact]
        public async Task GetAsync_ShouldNotFindCustomerByEmail_ReturnNull()
        {
            // Arrange
            var customerRepository = new CustomerRepository(_context);
            var customerEntity = new CustomerEntity { Email = "test" };
          
            // Act
            var result = await customerRepository.GetAsync(x => x.Email == customerEntity.Email);

            // Assert 
            Assert.Null(result);           
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateExistingCustomer_ReturnUpdatedCustomerEntity()
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
            customerEntity = await customerRepository.CreateAsync(customerEntity);

            // Act
            customerEntity.FirstName = "testa";
            var result = await customerRepository.UpdateAsync(x => x.Id == customerEntity.Id, customerEntity);

            // Assert 
            Assert.NotNull(result);
            Assert.Equal(customerEntity.Id, result.Id);
            Assert.Equal("testa", result.FirstName);
        }    

        [Fact]
        public async Task DeleteAsync_ShouldRemoveOneCustomer_ReturnTrue()
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
            await customerRepository.CreateAsync(customerEntity);

            // Act
            var result = await customerRepository.DeleteAsync(x => x.Id == customerEntity.Id);

            // Assert 
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldNotFindCustomerAndRemoveIt_ReturnFalse()
        {
            // Arrange
            var customerRepository = new CustomerRepository(_context);
            var customerEntity = new CustomerEntity { Id = 1 };

            // Act
            var result = await customerRepository.DeleteAsync(x => x.Id == customerEntity.Id);

            // Assert 
            Assert.False(result);
        }
    }
}
