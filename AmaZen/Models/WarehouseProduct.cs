using System.ComponentModel.DataAnnotations;

namespace AmaZen.Models
{
  public class WarehouseProduct
  {
    public int Id { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int WarehouseId { get; set; }
    public Product Product { get; set; }
    public Warehouse Warehouse { get; set; }
    public string CreatorId { get; set; }

  }
}