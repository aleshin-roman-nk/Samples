using AuthentExample.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthentExample.Pages.users
{
    public class RegistrationModel : PageModel
    {
        public void OnGet()
        {
            User = new User { };
        }

        public void OnPost()
        {

        }

        public User User { get; set; }
    }
}
