using System.Collections.Generic;
using System.Data;
using System.Linq;
using AmaZen.Models;
using Dapper;

namespace AmaZen.Repositories
{
  public class ProductsRepository
  {
    private readonly IDbConnection _db;

    public ProductsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Product> Get()
    {
      var sql = @"
      SELECT 
      p.*,
      a.*
      FROM products p
      JOIN accounts a on a.id = p.creatorId;
      ";
      return _db.Query<Product, Account, Product>(sql, (p, a) => {
        p.Creator = a;
        return p;
      }).ToList();
    }

    internal Product Get(int productId)
    {
      var sql = @"
      SELECT 
      p.*,
      a.*
      FROM products p
      JOIN accounts a on a.id = p.creatorId
      WHERE p.id = @productId;
      ";
      return _db.Query<Product, Account, Product>(sql, (p, a) => {
        p.Creator = a;
        return p;
      }, new{productId}).FirstOrDefault();
    }

    internal Product Post(Product productData)
    {
      var sql = @"
      INSERT INTO products(description, sku, price, creatorId)
      VALUES(@Description, @Sku, @Price, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, productData);
      productData.Id = id;
      return productData;
    }

  }
}