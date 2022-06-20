using AuthentExample.Model;
using AuthentExample.Service.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AuthentExample.Pages
{
    [Authorize]
    public class UserOrdersModel : PageModel
    {
        private readonly IUserOrdersRepo _r;

        public UserOrdersModel(IUserOrdersRepo r)
        {
            _r = r;
        }

        public void OnGet()
        {
            UserOrders = _r.GetAllOrders();
        }

        [BindProperty]
        public IEnumerable<UserOrder> UserOrders { get; set; }
    }
}
