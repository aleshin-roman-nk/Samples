using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace CatsRestAPILesson.Pages.cat
{
    public class IndexModel : PageModel
    {
        CatsModel m;

        public IndexModel()
        {
            m = new CatsModel();
            CurrentCat = new CatViewModel(m);
        }

        public void OnGet()
        {
            //__loadCurrentCat(0);
            CurrentCat.LoadFor(0);
        }
        public PartialViewResult OnPostAddCat(string catname, int catid)
        {
            m.Add(new Cat { name = catname, parentId = catid });

            //__loadCurrentCat(catid);
            CurrentCat.LoadFor(catid);
            return Partial("_CatsPartial", CurrentCat);
        }

        //public ActionResult OnGetCatProp()
        //{
        //    return Content("ha ha");
        //}

        public PartialViewResult OnPostAddProperty(string catpropertyname, int catid)
        {
            if(catid != 0) m.AddProperty(catid, catpropertyname);

            //__loadCurrentCat(catid);
            CurrentCat.LoadFor(catid);
            return Partial("_CatsPartial", CurrentCat);
        }
        public PartialViewResult OnGetEnterCatPartial(int catid)
        {
            //__loadCurrentCat(catid);
            CurrentCat.LoadFor(catid);
            return Partial("_CatsPartial", CurrentCat);
        }
        //private void __loadCurrentCat(int catid)
        //{
        //    CurrentCat.Cat = catid == 0 ? new Cat { id = 0, name = "" } : m.GetSingle(catid);
        //    CurrentCat.Children = m.GetCatsOf(catid);
        //    CurrentCat.Parents = m.GetAllParents(catid);
        //}

        public CatViewModel CurrentCat { get; set; }
    }
}
