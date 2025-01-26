using LearnRazor.Models.ViewModels;
using LearnRazor.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LearnRazor.Controllers;

public class HomeController : Controller
{
    private IProductRepository _productRepo;

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
