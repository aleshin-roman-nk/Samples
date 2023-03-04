using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthentExample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        
        public IActionResult OnGet()
        {
            //return Content(User.Identity.Name);

            Nme = User.Identity.Name;
            //Nme = User.Claims.FirstOrDefault(x => x.Type == "Name").Value;
            return Page();
        }

        [BindProperty]
        public string Nme { get; set; }
    }
}