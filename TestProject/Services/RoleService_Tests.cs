using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace TestProject.Services;

public class RoleService_Tests
{
    private readonly DataContext _context = new DataContext(new DbContextOptionsBuilder<DataContext>()
    .UseInMemoryDatabase($"{Guid.NewGuid()}")
    .Options);

    [Fact]
    public async Task CreateRoleAsyncShouldCreateNewRole_ReturnTrue()
    {
        // Arrange
        var roleRepository = new RoleRepository(_context);
        var roleService = new RoleService(roleRepository);

        string roleName = "Guest";

        // Act
        var result = await roleService.CreateRoleAsync(roleName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(roleName, result.RoleName);
    }
}
