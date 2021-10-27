using System.Collections.Generic;
using System.Data;
using System.Linq;
using AmaZen.Models;
using Dapper;

namespace AmaZen.Repositories
{
  public class WarehouseProductsRepository
  {
    private readonly IDbConnection _db;

    public WarehouseProductsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<WarehouseProduct> Get()
    {
     var sql = @"
      SELECT
      wp.*,
      w.*,
      p.*
      FROM warehouse_products wp
      JOIN products p on p.id = wp.productId
      JOIN warehouses w on w.id = wp.warehouseId;
      ";
      return _db.Query<WarehouseProduct, Warehouse, Product, WarehouseProduct>(sql, (wp, w, p) => {
        wp.Warehouse = w;
        wp.Product = p;
        return wp;
      }).ToList();
    }

    internal WarehouseProduct Get(int warehouseproductId)
    {
      var sql = @"
      SELECT
      wp.*,
      w.*,
      p.*
      FROM warehouse_products wp
      JOIN products p on p.id = wp.productId
      JOIN warehouses w on w.id = wp.warehouseId
      WHERE wp.id = @warehouseproductId;
      ";
      return _db.Query<WarehouseProduct, Warehouse, Product, WarehouseProduct>(sql, (wp, w, p) => {
        wp.Warehouse = w;
        wp.Product = p;
        return wp;
      }, new{warehouseproductId}).FirstOrDefault();
    }

    internal WarehouseProduct Post(WarehouseProduct newItem)
    {
      var sql = @"
      INSERT INTO warehouse_products(productId, warehouseId, creatorId)
      VALUES(@ProductId, @WarehouseId, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newItem);
      newItem.Id = id;
      return newItem;
    }

  }
}