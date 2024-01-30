using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ProductService(ProductRepository productRepository, CategoryService categoryService)
{
    private readonly ProductRepository _productRepository = productRepository;
    private readonly CategoryService _categoryService = categoryService;

    // Create
    public ProductEntity CreateProduct(string title, decimal price, string categoryName)
    {
        var categoryEntity = _categoryService.CreateCategory(categoryName);

        var productEntity = new ProductEntity
        {
            Title = title,
            Price = price,
            CategoryId = categoryEntity.Id,
        };

        productEntity = _productRepository.Create(productEntity);
        return productEntity;
    }

    // Read
    public ProductEntity GetProductById(int id) 
    {
        var productEntity = _productRepository.Get(x => x.Id == id);
        return productEntity;
    }

    public IEnumerable<ProductEntity> GetProducts()
    {
        var products = _productRepository.GetAll();
        return products;
    }

    // Update
    public ProductEntity UpdateProduct(ProductEntity productEntity)
    {
        var updatedProductEntity = _productRepository.Update(x => x.Id == productEntity.Id, productEntity);
        return updatedProductEntity;
    }

    // Delete
    public void DeleteProduct(int id) // Ändra till bool när jag lägger till checkar.
    {
        _productRepository.Delete(x => x.Id == id);
    }
}
