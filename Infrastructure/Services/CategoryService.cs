// Felet jag gjort i mina egna försök på uppgiften är nog att jag bara använt en service. Antagligen.
using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class CategoryService(CategoryRepository categoryRepository)
{
    private readonly CategoryRepository _categoryRepository = categoryRepository;

    // Create
    public CategoryEntity CreateCategory(string categoryName)
    {
        var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
        categoryEntity ??= _categoryRepository.Create(new CategoryEntity { CategoryName = categoryName });

        return categoryEntity;
    }

    // Read
    public CategoryEntity GetCategoryByCategoryName(string categoryName) // By name
    {
        var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
        return categoryEntity;
    }

    public CategoryEntity GetCategorybyCategoryId(int id) // By Id
    {
        var categoryEntity = _categoryRepository.Get(x => x.Id == id);
        return categoryEntity;
    }

    public IEnumerable<CategoryEntity> GetCategories() 
    {
        var categories = _categoryRepository.GetAll();
        return categories;
    }

    // Update
    public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
    {
        var updatedCategoryEntity = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
        return updatedCategoryEntity;
    }

    // Delete
    public void DeleteCategory(int id) // Ändra till bool när jag lägger till checkar.
    {
        _categoryRepository.Delete(x => x.Id == id);
    }
}