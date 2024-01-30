using Infrastructure.Services;
using System.Diagnostics;

namespace KonsolApp;

public class ConsoleUI
{
    private readonly ProductService _productService;
    private readonly CustomerService _customerService;

    public ConsoleUI(ProductService productService, CustomerService customerService)
    {
        _productService = productService;
        _customerService = customerService;
    }

    // Products
    public void CreateProductUi()
    {
        Console.Clear();
        Console.WriteLine("---- CREATE PRODUCT ----");
        
        Console.Write("Product Title: ");
        var title = Console.ReadLine()!;

        Console.WriteLine("Product Price ");
        var price = decimal.Parse(Console.ReadLine()!);

        Console.WriteLine("Product Category ");
        var categoryName = Console.ReadLine()!;

        var result = _productService.CreateProduct(title, price, categoryName);

        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Product was created.");
            Console.ReadKey();
        }
    }
    public void GetProductsUi()
    {
        var products = _productService.GetProducts();

        foreach(var product in products)
        {
            Console.WriteLine($" {product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
        }

        Console.ReadKey();
        Console.Clear();
    }
    public void UpdateProductUi()
    {
        Console.Clear();
        Console.WriteLine("Enter product id: ");
        var id = int.Parse(Console.ReadLine()!);

        var product = _productService.GetProductById(id); 
        if (product != null)
        {
            Console.WriteLine($" {product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
            Console.WriteLine();
         
            Console.Write("New Product Title: ");
            product.Title = Console.ReadLine()!;

            var newProduct = _productService.UpdateProduct(product);
            Console.WriteLine($" {product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
        }
        else
        {
            Console.WriteLine("No product found.");
        }

        Console.ReadKey();
    }
    public void DeleteProductUi()
    {
        Console.Clear();
        Console.WriteLine("Enter product id: ");
        var id = int.Parse(Console.ReadLine()!);

        var product = _productService.GetProductById(id);
        if (product != null)
        {
            _productService.DeleteProduct(product.Id);
            Console.WriteLine("Product deleted.");
        }
        else
        {
            Console.WriteLine("No product found.");
        }

        Console.ReadKey();
    }

    // Customers
    public void CreateCustomerUi()
    {
        Console.Clear();
        Console.WriteLine("---- CREATE CUSTOMER ----");

        Console.Write("First Name: ");
        var firstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        var lastName = Console.ReadLine()!;

        Console.Write("Street Name: ");
        var streetName = Console.ReadLine()!;

        Console.Write("ZipCode: ");
        var postalCode = Console.ReadLine()!;

        Console.Write("City: ");
        var city = Console.ReadLine()!;

        Console.Write("Email: ");
        var email = Console.ReadLine()!;

        Console.Write("Role Name: ");
        var roleName = Console.ReadLine()!;

        var result = _customerService.CreateCustomer(firstName, lastName, email, roleName, streetName, postalCode, city);
        
        Debug.WriteLine(result);

        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Customer was created.");
            Console.ReadKey();
        }
    }
    public void GetCustomersUi()
    {
        var customers = _customerService.GetCustomers();

        foreach (var customer in customers)
        {
            Console.WriteLine($" {customer.FirstName} - {customer.Role.RoleName} ({customer.Email} )");
        }

        Console.ReadKey();
        Console.Clear();
    }
    public void UpdateCustomerUi()
    {
        Console.Clear();
        Console.WriteLine("Enter customer id: ");
        var id = int.Parse(Console.ReadLine()!);

        var customer = _customerService.GetCustomerById(id);
        if (customer != null)
        {
            Console.WriteLine($" {customer.FirstName} - {customer.Role.RoleName} ({customer.Email} )");
            Console.WriteLine();

            Console.Write("New Customer Email: ");
            customer.Email = Console.ReadLine()!;

            var newCustomer = _customerService.UpdateCustomer(customer);
            Console.WriteLine($" {customer.FirstName} - {customer.Role.RoleName} ({customer.Email} )");
        }
        else
        {
            Console.WriteLine("No customer found.");
        }

        Console.ReadKey();
    }
    public void DeleteCustomerUi()
    {
        Console.Clear();
        Console.WriteLine("Enter customer id: ");
        var id = int.Parse(Console.ReadLine()!);

        var customer = _customerService.GetCustomerById(id);
        if (customer != null)
        {
            _customerService.DeleteCustomer(customer.Id);
            Console.WriteLine("Customer deleted.");
        }
        else
        {
            Console.WriteLine("No customer found.");
        }

        Console.ReadKey();
    }
}
