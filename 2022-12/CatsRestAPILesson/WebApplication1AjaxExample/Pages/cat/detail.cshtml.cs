using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatsRestAPILesson.Pages.cat
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
