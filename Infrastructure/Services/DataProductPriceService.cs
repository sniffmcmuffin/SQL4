using Infrastructure.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services;

public class DataProductPriceService(DataProductPriceRepo dataProductPriceRepo)
{
    private readonly DataProductPriceRepo _dataProductPriceRepo = dataProductPriceRepo;

    // Create
    public ProductPrice CreatePrice(decimal price)
    {
        var
        productPrice = _dataProductPriceRepo.Get(x => x.Price == price);
        productPrice ??= _dataProductPriceRepo.Create(new ProductPrice { Price = price });

        return productPrice;
    }

    // Read
    public ProductPrice GetPricesByPrice(decimal price)
    {
        var productPrice = _dataProductPriceRepo.Get(x => x.Price == price);
        return productPrice;
    }

    public ProductPrice GetPricesById(int id)
    {
        var productPrice = _dataProductPriceRepo.Get(x => x.ProductId == id);
        return productPrice;
    }

    public IEnumerable<ProductPrice> GetPrices()
    {
        var prices = _dataProductPriceRepo.GetAll();
        return prices;
    }

    // Update
    public ProductPrice UpdatePrice(ProductPrice productPrice)
    {
        var updatedproductPrice = _dataProductPriceRepo.Update(x => x.ProductId == productPrice.ProductId, productPrice);
        return updatedproductPrice;
    }

    // Delete
    public void DeletePrice(int id) 
    {
        _dataProductPriceRepo.Delete(x => x.ProductId == id);
    }
}