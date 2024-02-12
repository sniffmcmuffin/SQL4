namespace KonsolApp.Services;

public class MenuService // This is awful, but the best I could do in the 11th hour.
{
    private readonly ConsoleUI _consoleUI;

    public MenuService(ConsoleUI consoleUI)
    {
        _consoleUI = consoleUI;
    }

    public void ShowMainMenu() 
    {
        Console.WriteLine("Welcome to the Main Menu!"); 
        Console.WriteLine("1. Manage Products");
        Console.WriteLine("2. Manage Customers");
        Console.WriteLine("3. Manage Reviews");
        Console.WriteLine("4. Exit");

        Console.Write("Enter your choice: ");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ShowProductMenu();
                break;
            case "2":
                ShowCustomerMenu();
                break;
            case "3":
                ShowReviewMenu();
                break;
            case "4":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    private void ShowProductMenu()
    {
        Console.WriteLine("Manage Products Menu");
        Console.WriteLine("1. Create CodeFirst Product");
        Console.WriteLine("2. Get CodeFirst Products");
        Console.WriteLine("3. Update CodeFirst Product");
        Console.WriteLine("4. Delete CodeFirst Product");
        Console.WriteLine("5. Create DataFirst Product");
        Console.WriteLine("6. Get DataFirst Products - Not implemented yet ");
        Console.WriteLine("7. Update DataFirst Product - Not implemented yet ");
        Console.WriteLine("8. Delete DataFirst Product - Not implemented yet ");
        Console.WriteLine("9. Back to Main Menu - Not implemented yet ");

        Console.Write("Enter your choice: ");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                _consoleUI.CreateProductUi();
                break;
            case "2":
                _consoleUI.GetProductsUi();
                break;
            case "3":
                _consoleUI.UpdateProductUi();
                break;
            case "4":
                _consoleUI.DeleteProductUi();
                break;
            case "5":
                _consoleUI.DbCreateProductUi();
                break;
            case "6":
              //  _consoleUI.DbGetProductsUi();
                break;
            case "7":
              //  _consoleUI.DbUpdateProductUi();
                break;
            case "8":
             //   _consoleUI.DbDeleteProductUi();
                break;
            case "9":
                ShowMainMenu();
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    private void ShowCustomerMenu()
    {
        Console.WriteLine("Manage Customers Menu");
        Console.WriteLine("1. Create CodeFirst Customer");
        Console.WriteLine("2. Get CodeFirst Customers");
        Console.WriteLine("3. Update CodeFirst Customer");
        Console.WriteLine("4. Delete CodeFirst Customer");
        Console.WriteLine("5. Create DataFirst Customer");
        Console.WriteLine("6. Get DataFirst Customers");
        Console.WriteLine("7. Update DataFirst Customer");
        Console.WriteLine("8. Delete DataFirst Customer");
        Console.WriteLine("9. Back to Main Menu");

        Console.Write("Enter your choice: ");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                _consoleUI.CreateCustomerUi();
                break;
            case "2":
                _consoleUI.GetCustomersUi();
                break;
            case "3":
                _consoleUI.UpdateCustomerUi();
                break;
            case "4":
                _consoleUI.DeleteCustomerUi();
                break;
            case "5":
                _consoleUI.DbCreateCustomerUi();
                break;
            case "6":
                _consoleUI.DbGetCustomersUi();
                break;
            case "7":
                _consoleUI.DbUpdateCustomerUi();
                break;
            case "8":
                _consoleUI.DbDeleteCustomerUi();
                break;
            case "9":
                ShowMainMenu();
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    private void ShowReviewMenu()
    {
        Console.WriteLine("Manage Customers Menu");
        Console.WriteLine("1. Create Database First Review");
        Console.WriteLine("2. Back to Main Menu");

        Console.Write("Enter your choice: ");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                _consoleUI.DbCreateReviewUi();
                break;
            case "2":
                ShowMainMenu();
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }
}
