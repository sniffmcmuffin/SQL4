using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using KonsolApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// START Database builder
//var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
//{
//    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Code\ecutbildning\SQL\SQL4\SQL4\Infrastructure\Data\CodeSql.mdf;Integrated Security=True;Connect Timeout=30"));
//}).Build();
// STOP Database builder

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    // Code First
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Code\ecutbildning\SQL\SQL4\SQL4\Infrastructure\Data\CodeSql.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));

    // Database First
    services.AddDbContext<ApplicationDataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Code\\ecutbildning\\SQL\\SQL4\\SQL4\\Infrastructure\\Data\\ProductCatalog.mdf;Integrated Security=True;Connect Timeout=30"));

    // Code First Repos
    services.AddScoped<AddressRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<RoleRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<CustomerRepository>();
    // Code First Services
    services.AddScoped<AddressService>();
    services.AddScoped<CategoryService>();
    services.AddScoped<RoleService>();
    services.AddScoped<ProductService>();
    services.AddScoped<CustomerService>();

    services.AddSingleton<ConsoleUI>();
}).Build();

var consoleUI = builder.Services.GetRequiredService<ConsoleUI>();
// consoleUI.CreateProductUi();
// consoleUI.GetProductsUi();
// consoleUI.UpdateProductUi();
// consoleUI.DeleteProductUi();

// consoleUI.CreateCustomerUi();
// consoleUI.GetCustomersUi();
// consoleUI.UpdateCustomerUi();
consoleUI.DeleteCustomerUi();