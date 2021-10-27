namespace AmaZen.Models
{
  public class Product
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public string Sku { get; set; }
    public int Price { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
  }
}