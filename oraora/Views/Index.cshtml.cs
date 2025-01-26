using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oraora.Models;

namespace Oraora.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public Book Book { get; set; }

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet() { }

    public void OnPost()
    {
        var postedBookForm = JsonSerializer.Serialize(Request.Form.ToList());
        var postedBook = JsonNode.Parse(postedBookForm);

        var formatedRequest = JsonSerializer.Serialize(
            Book,
            new JsonSerializerOptions { WriteIndented = true }
        );

        Console.WriteLine(formatedRequest);
    }
}
