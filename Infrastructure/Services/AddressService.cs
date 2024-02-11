using Infrastructure.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services;

public class AddressService(AddressRepository addressRepository)
{
    private readonly AddressRepository _addressRepository = addressRepository;

    // Create
    public AddressEntity CreateAddress(string streetName, string postalCode, string city)
    {
        var
        addressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        addressEntity ??= _addressRepository.Create(new AddressEntity { StreetName = streetName, PostalCode = postalCode, City = city });

        return addressEntity;
    }

    public async Task<AddressEntity> CreateAddressAsync(string streetName, string postalCode, string city)
    {
        var addressEntity = await _addressRepository.GetAsync(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);

        if (addressEntity == null)
        {
            addressEntity = await _addressRepository.CreateAsync(new AddressEntity { StreetName = streetName, PostalCode = postalCode, City = city });
        }

        return addressEntity;
    }

    // Read
    public AddressEntity GetAddressbyAddressName(string streetName, string postalCode, string city) 
    {
        var addressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        return addressEntity;
    }

    public AddressEntity GetAddressByAddressId(int id) 
    {
        var addressEntity = _addressRepository.Get(x => x.Id == id);
        return addressEntity;
    }

    public IEnumerable<AddressEntity> GetAddresses()
    {
        var addresses = _addressRepository.GetAll();
        return addresses;
    }

    // Update
    public AddressEntity UpdateAddress(AddressEntity addressEntity)
    {
        var updatedAddressEntity = _addressRepository.Update(x => x.Id == addressEntity.Id, addressEntity);
        return updatedAddressEntity;
    }

    // Delete
    public void DeleteAddress(int id) // Ändra till bool när jag lägger till checkar.
    {
        _addressRepository.Delete(x => x.Id == id);
    }
}
