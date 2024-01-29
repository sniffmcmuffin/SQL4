using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// START Database builder
var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Code\ecutbildning\SQL\SQL3\SQL3\Infrastructure\Data\ProductCatalog.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));
}).Build(); 

// STOP Database builder