using Microsoft.AspNetCore.Mvc;
using Oraora.Models.ViewModels;
using Oraora.Repository;

namespace Oraora.Controllers;

public class AboutController : Controller
{
    private IProductRepository _productRepo;

    public AboutController(IProductRepository productRepository)
    {
        _productRepo = productRepository;
    }

    public async Task<ViewResult> Index()
    {
        var aboutViewModel = new AboutViewModel();
        return View(aboutViewModel);
    }
}
