using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class DataProductService
    {
        private readonly DataProductRepo _productRepository;
        private readonly DataManufacturerService _manufacturerService;
        private readonly DataCategoryService _categoryService;

        public DataProductService(DataProductRepo productRepository, DataManufacturerService manufacturerService, DataCategoryService categoryService)
        {
            _productRepository = productRepository;
            _manufacturerService = manufacturerService;
            _categoryService = categoryService;
        }

        // Create
        public Product CreateProduct(string productName, string description, string manufacturerName, string categoryName)
        {
            var manufacturerEntity = _manufacturerService.GetManufacturerByName(manufacturerName);
            var categoryEntity = _categoryService.GetCategoryByName(categoryName);

            var productEntity = new Product
            {
                ProductName = productName,
                Description = description,
                ManufacturerId = manufacturerEntity?.ManufacturerId,
                CategoryId = categoryEntity?.CategoryId
            };

            productEntity = _productRepository.Create(productEntity);

            return productEntity;
        }

        // Read
        public Product GetProductById(int id)
        {
            var productEntity = _productRepository.Get(x => x.Id == id);
            return productEntity;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _productRepository.GetAll();
            return products;
        }

        // Update
        public Product UpdateProduct(Product productEntity)
        {
            var updatedProductEntity = _productRepository.Update(x => x.Id == productEntity.Id, productEntity);
            return updatedProductEntity;
        }

        // Delete
        public void DeleteProduct(int id)
        {
            _productRepository.Delete(x => x.Id == id);
        }
    }
}
