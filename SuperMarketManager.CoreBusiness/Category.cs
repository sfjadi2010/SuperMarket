using System.ComponentModel.DataAnnotations;

namespace SuperMarketManager.CoreBusiness;

public class Category
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = default!;
    public string? Description { get; set; } = default!;

    // navigation property for related products
    public List<Product> Products { get; set; } = new List<Product>();
}
