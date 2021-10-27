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
  public class WarehouseProductsController : ControllerBase
  {
    private readonly WarehouseProductsService _warehouseProductsService;

    public WarehouseProductsController(WarehouseProductsService warehouseProductsService)
    {
      _warehouseProductsService = warehouseProductsService;
    }

    [HttpGet]
    public ActionResult<List<WarehouseProduct>> Get()
    {
      try
      {
      var warehouseProducts = _warehouseProductsService.Get();
      return Ok(warehouseProducts);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{warehouseproductId}")]
    public ActionResult<WarehouseProduct> Get(int warehouseproductId)
    {
      try
      {
        return Ok(_warehouseProductsService.Get(warehouseproductId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<WarehouseProduct>> Post([FromBody] WarehouseProduct newItem)
    {
      try
      {
      var userInfo = await HttpContext.GetUserInfoAsync<Account>();
      newItem.CreatorId = userInfo.Id;
      WarehouseProduct createdItem = _warehouseProductsService.Post(newItem);
      return createdItem;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}