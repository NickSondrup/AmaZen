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
  public class ProductsController : ControllerBase
  {
    private readonly ProductsService _productsService;

    public ProductsController(ProductsService productsService)
    {
      _productsService = productsService;
    }

    [HttpGet]
    public ActionResult<List<Product>> Get()
    {
      try
      {
        var products = _productsService.Get();
        return Ok(products);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{productId}")]
    public ActionResult<Product> Get(int productId)
    {
      try
      {
       Product product = _productsService.Get(productId);
       return product;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Product>> Post([FromBody] Product productData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        productData.CreatorId = userInfo.Id;
        Product createdProduct = _productsService.Post(productData);
        return createdProduct;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}