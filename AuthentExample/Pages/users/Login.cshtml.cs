using AuthentExample.Model;
using AuthentExample.Service.Repos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;

namespace AuthentExample.Pages.users
{
    public class LoginModel : PageModel
    {
        private readonly IUserRepo repo;

        public LoginModel(IUserRepo r)
        {
            repo = r;
        }

        public void OnGet()
        {
            //            User = new User { };
            //Usr = new Usr { };
        }

        public async Task<IActionResult> OnPost()
        {
            ModelState.Remove("Error");
            ModelState.Remove("Success");

            if (ModelState.IsValid)
            {
                User user = repo.Get(Usr.Name, Usr.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToPage("/Index");
                }
                Error = "Некорректные логин и(или) пароль";
            }
            //else
            //{
            //    StringBuilder sb = new StringBuilder();

            //    foreach (var item in ModelState)
            //    {
            //        sb.AppendLine($"***([{item.Key}] : [{item.Value.AttemptedValue}])*** ");
            //    }

            //    Error = sb.ToString();
            //}

            return Page();
        }

        public async Task<IActionResult> OnGetLogout()
        {
            await HttpContext.SignOutAsync("lngCollectorAppCookie");
            return RedirectToPage("/Index");
        }

        private async Task Authenticate(User usr)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                //new Claim(ClaimsIdentity.DefaultNameClaimType, userName)

                new Claim(ClaimTypes.Name, usr.name),
                new Claim(ClaimTypes.NameIdentifier, usr.id.ToString())

                //new Claim("Name", usr.name),
                //new Claim("Id", usr.id.ToString())

            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "lngCollectorAppCookie");
            // установка аутентификационных куки
            await HttpContext.SignInAsync("lngCollectorAppCookie", new ClaimsPrincipal(id));
        }

        [BindProperty]
        public string Error { get; set; }

        [BindProperty]
        public string Success { get; set; }

        //[BindProperty]
        //[Required(ErrorMessage = "Не указан Name")]
        //public string Name { get; set; }

        //[BindProperty]
        //[Required(ErrorMessage = "Не указан пароль")]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        [BindProperty]
        public Usr Usr { get; set; }
    }

    public class Usr
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
