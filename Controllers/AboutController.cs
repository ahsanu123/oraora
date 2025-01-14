using LearnRazor.Models.ViewModels;
using LearnRazor.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LearnRazor.Controllers;

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
