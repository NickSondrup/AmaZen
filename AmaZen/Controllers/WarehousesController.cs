using System.Collections.Generic;
using System.Threading.Tasks;
using AmaZen.Models;
using AmaZen.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmaZen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WareHousesController : ControllerBase
  {
    private readonly WareHousesService _warehousesService;

    public WareHousesController(WareHousesService warehousesService)
    {
      _warehousesService = warehousesService;
    }

    [HttpGet]
    public ActionResult<List<Warehouse>> Get()
    {
      try
      {
        var warehouses = _warehousesService.Get();
        return warehouses;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{warehouseId}")]
    public ActionResult<Warehouse> Get(int warehouseId)
    {
      try
      {
      var warehouse = _warehousesService.Get(warehouseId);
      return warehouse;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public async  Task<ActionResult<Warehouse>> Post([FromBody] Warehouse warehouseData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        warehouseData.CreatorId = userInfo.Id;
        var createdWarehouse = _warehousesService.Post(warehouseData);
        return createdWarehouse; 
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}