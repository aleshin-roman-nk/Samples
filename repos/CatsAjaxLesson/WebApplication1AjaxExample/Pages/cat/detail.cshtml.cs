using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1AjaxExample.Pages.cat
{
    public class detailModel : PageModel
    {
        CatsModel m;

        public detailModel()
        {
            m = new CatsModel();
        }

        public void OnGet(int catid)
        {
            Cat = m.GetSingle(catid);
        }

        public Cat? Cat { get; set; }
    }
}
