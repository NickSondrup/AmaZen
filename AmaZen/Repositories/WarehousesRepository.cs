using System.Collections.Generic;
using System.Data;
using System.Linq;
using AmaZen.Models;
using Dapper;

namespace AmaZen.Repositories
{
  public class WareHousesRepository
  {
    private readonly IDbConnection _db;

    public WareHousesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Warehouse> Get()
    {
     var sql = @"
      SELECT 
      w.*,
      a.*
      FROM warehouses w
      JOIN accounts a on a.id = w.creatorId
      ";
      return _db.Query<Warehouse, Account, Warehouse>(sql, (w, a) => {
        w.Creator = a;
        return w;
      }).ToList();
    }

    internal Warehouse Post(Warehouse warehouseData)
    {
      var sql = @"
      INSERT INTO warehouses(location, creatorId)
      VALUES(@Location, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, warehouseData);
      warehouseData.Id = id;
      return warehouseData;

    }

    internal Warehouse Get(int warehouseId)
    {
      var sql = @"
      SELECT 
      w.*,
      a.*
      FROM warehouses w
      JOIN accounts a on a.id = w.creatorId
      WHERE w.id = @warehouseId;
      ";
      return _db.Query<Warehouse, Account, Warehouse>(sql, (w, a) => {
        w.Creator = a;
        return w;
      }, new{warehouseId}).FirstOrDefault();
    }

    
  }
}