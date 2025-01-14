using System.ComponentModel.DataAnnotations;

namespace LearnRazor.Model;

public class Book
{
    [Required]
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublisedDate { get; set; } = DateTime.Now;
}
