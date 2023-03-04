using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorAPI.Pages;

public class IndexModel : PageModel
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Colour { get; set; }
    public int Doors { get; set; }
    public int Price { get; set; }
}
