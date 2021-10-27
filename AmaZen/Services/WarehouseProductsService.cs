using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Repositories;

namespace AmaZen.Services
{
  public class WarehouseProductsService
  {
    private readonly WarehouseProductsRepository _warehouseProductsRepository;

    public WarehouseProductsService(WarehouseProductsRepository warehouseProductsRepository)
    {
      _warehouseProductsRepository = warehouseProductsRepository;
    }

    public List<WarehouseProduct> Get()
    {
      return _warehouseProductsRepository.Get();
    }

    public WarehouseProduct Get(int warehouseproductId)
    {
      return _warehouseProductsRepository.Get(warehouseproductId);
    }
    internal WarehouseProduct Post(WarehouseProduct newItem)
    {
      return _warehouseProductsRepository.Post(newItem);
    }

  }
}