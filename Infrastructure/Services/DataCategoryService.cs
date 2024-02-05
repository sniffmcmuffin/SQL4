using Infrastructure.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services;

public class DataCategoryService(DataCategoryRepo dataCategoryRepo)
{
    private readonly DataCategoryRepo _dataCategoryRepo = dataCategoryRepo;

    // Create
    public Category CreateCategory(string categoryName)
    {
        var
        category = _dataCategoryRepo.Get(x => x.CategoryName == categoryName);
        category ??= _dataCategoryRepo.Create(new Category { CategoryName = categoryName });

        return category;
    }

    // Read
    public Category GetCategoryByName(string categoryName)
    {
        var category = _dataCategoryRepo.Get(x => x.CategoryName == categoryName);
        return category;
    }

    public Category GetCategoryById(int id)
    {
        var category = _dataCategoryRepo.Get(x => x.CategoryId == id);
        return category;
    }

    public IEnumerable<Category> GetCategories()
    {
        var categories = _dataCategoryRepo.GetAll();
        return categories;
    }

    // Update
    public Category UpdateCategory(Category category)
    {
        var updatedCategory = _dataCategoryRepo.Update(x => x.CategoryId == category.CategoryId, category);
        return updatedCategory;
    }

    // Delete
    public void DeleteCategory(int id) 
    {
        _dataCategoryRepo.Delete(x => x.CategoryId == id);
    }
}