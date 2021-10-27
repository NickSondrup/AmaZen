using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Repositories;

namespace AmaZen.Services
{
  public class WareHousesService
  {
    private readonly WareHousesRepository _warehousesRepository;

    public WareHousesService(WareHousesRepository warehousesRepository)
    {
      _warehousesRepository = warehousesRepository;
    }

    public List<Warehouse> Get()
    {
      return _warehousesRepository.Get();
    }

    public Warehouse Post(Warehouse warehouseData)
    {
      return _warehousesRepository.Post(warehouseData);
    }

    public Warehouse Get(int warehouseId)
    {
      return _warehousesRepository.Get(warehouseId);
    }
  }
}