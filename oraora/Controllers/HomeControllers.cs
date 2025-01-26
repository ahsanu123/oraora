using Microsoft.AspNetCore.Mvc;
using Oraora.Models.ViewModels;
using Oraora.Repository;

namespace Oraora.Controllers;

public class HomeController : Controller
{
    private readonly IProductRepository _productRepo;

    public HomeController(IProductRepository productRepository)
    {
        _productRepo = productRepository;
    }

    public async Task<ViewResult> Index()
    {
        var products = await _productRepo.GetProducts();
        var viewProducts = new ProductListViewModel { Products = products };

        return View(viewProducts);
    }
}
