namespace Oraora.Models.ViewModels;

public class ProductListViewModel
{
    public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
}
