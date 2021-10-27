using System;
using System.ComponentModel.DataAnnotations;

namespace AmaZen.Models
{
  public class Warehouse
  {
    public int Id { get; set; }
    [Required]
    public string Location { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
  }
}