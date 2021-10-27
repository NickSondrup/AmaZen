using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Repositories;

namespace AmaZen.Services
{
  public class ProductsService
  {
    private readonly ProductsRepository _productsRepository;

    public ProductsService(ProductsRepository productsRepository)
    {
      _productsRepository = productsRepository;
    }

    public List<Product> Get()
    {
      return _productsRepository.Get();
    }

    public Product Get(int productId)
    {
      return _productsRepository.Get(productId);
    }

    public Product Post(Product productData)
    {
      return _productsRepository.Post(productData);
    }
  }
}