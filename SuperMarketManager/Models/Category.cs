using System.ComponentModel.DataAnnotations;

namespace SuperMarketManager.Models;

public class Category
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = default!;
    public string? Description { get; set; } = default!;
}
