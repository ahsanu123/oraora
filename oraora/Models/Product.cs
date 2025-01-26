namespace Oraora.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public float Price { get; set; }
    public string Category { get; set; } = String.Empty;
}
