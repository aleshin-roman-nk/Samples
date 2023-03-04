using AuthentExample.Model;
using AuthentExample.Service.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AuthentExample.Pages.users
{
    [Authorize]
    public class allusersviewModel : PageModel
    {
        private readonly IUserRepo _repo;

        public allusersviewModel(IUserRepo r)
        {
            _repo = r;
        }

        public void OnGet()
        {
            Users = _repo.GetAll();
        }

        [BindProperty]
        public IEnumerable<User> Users { get; set; }
    }
}
