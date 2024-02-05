using Infrastructure.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services;

public class DataManufacturerService(DataManufacturerRepo dataManufacturerRepo)
{
    private readonly DataManufacturerRepo _dataManufacturerRepo = dataManufacturerRepo;

    // Create
    public Manufacturer CreateManufacturer(string manufacturerName)
    {
        var
        manufacturer = _dataManufacturerRepo.Get(x => x.ManufacturerName == manufacturerName);
        manufacturer ??= _dataManufacturerRepo.Create(new Manufacturer { ManufacturerName = manufacturerName });

        return manufacturer;
    }

    // Read
    public Manufacturer GetManufacturerByName(string manufacturerName)
    {
        var manufacturer = _dataManufacturerRepo.Get(x => x.ManufacturerName == manufacturerName);
        return manufacturer;
    }

    public Manufacturer GetManufacturerById(int id)
    {
        var manufacturer = _dataManufacturerRepo.Get(x => x.ManufacturerId == id);
        return manufacturer;
    }

    public IEnumerable<Manufacturer> GetManufacturers()
    {
        var manufacturers = _dataManufacturerRepo.GetAll();
        return manufacturers;
    }

    // Update
    public Manufacturer UpdateManufacturer(Manufacturer manufacturer)
    {
        var updatedManufacturer = _dataManufacturerRepo.Update(x => x.ManufacturerId == manufacturer.ManufacturerId, manufacturer);
        return updatedManufacturer;
    }

    // Delete
    public void DeleteManufacturer(int id)
    {
        _dataManufacturerRepo.Delete(x => x.ManufacturerId == id);
    }
}