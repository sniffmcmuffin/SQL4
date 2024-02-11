using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;

namespace TestProject.Services;

public class AddressService_Tests
{
    private readonly DataContext _context = new DataContext(new DbContextOptionsBuilder<DataContext>()
    .UseInMemoryDatabase($"{Guid.NewGuid()}")
    .Options);

    [Fact]
    public async Task CreateAddressAsyncShouldCreateNewAddress_ReturnTrue()
    {
        // Arrange
        var addressRepository = new AddressRepository(_context);
        var addressService = new AddressService(addressRepository);

        string streetName = "123 Main St";
        string postalCode = "12345";
        string city = "SomeCity";

        // Act
        var result = await addressService.CreateAddressAsync(streetName, postalCode, city);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(streetName, result.StreetName);
        Assert.Equal(postalCode, result.PostalCode);
        Assert.Equal(city, result.City);
    }
}

