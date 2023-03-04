using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WebApplication1AjaxExample.Pages.cat
{
    public class IndexModel : PageModel
    {
        CatsModel m;

        public IndexModel()
        {
            m = new CatsModel();
        }

        public void OnGet()
        {
            CurrentCat = new CatViewModel
            {
                Cat = new Cat { id = 0, name = "-root-" },
                Children = m.GetCatsOf(0),
                Path = m.GetFullPath(0)
            };
        }



        public PartialViewResult OnPost(string catname, int catid)
        {
            m.Add(new Cat { name = catname, parentId = catid });

            if(catid == 0)
            {
                CurrentCat = new CatViewModel
                {
                    Cat = new Cat { id = 0, name = "-root-" },
                    Children = m.GetCatsOf(0)
                };
            }
            else
            {
                CurrentCat.Cat = m.GetSingle(catid);// приходит то 0 если корень
                CurrentCat.Children = m.GetCatsOf(catid);
            }

            CurrentCat.Path = m.GetFullPath(catid);

            return Partial("_CatsPartial", CurrentCat);
        }

        public ActionResult OnGetCatProp()
        {
            return Content("ha ha");
        }

        public PartialViewResult OnPostAddProperty(string catpropertyname, int catid)
        {
            // имущество не может быть без кота.
            // Товары не могут быть без раздела.
            if (catid == 0)
            {
                CurrentCat.Cat = m.GetSingle(catid);// приходит то 0 если корень
                CurrentCat.Children = m.GetCatsOf(catid);
                CurrentCat.Path = m.GetFullPath(catid);
                return Partial("_CatsPartial", CurrentCat);
            }

            m.AddProperty(catid, catpropertyname);
            CurrentCat.Cat = m.GetSingle(catid);// приходит то 0 если корень
            CurrentCat.Children = m.GetCatsOf(catid);
            CurrentCat.Path = m.GetFullPath(catid);
            return Partial("_CatsPartial", CurrentCat);
        }


        public PartialViewResult OnGetEnterCatPartial(int catid)
        {
            CurrentCat.Cat = m.GetSingle(catid);
            CurrentCat.Children = m.GetCatsOf(CurrentCat.Cat.id);
            CurrentCat.Path = m.GetFullPath(catid);
            return Partial("_CatsPartial", CurrentCat);
        }

        public PartialViewResult OnGetExitCatPartial(int catid)
        {
            CurrentCat = new CatViewModel();

            if(catid == 0)
            {
                CurrentCat = new CatViewModel
                {
                    Cat = new Cat { id = 0, name = "-root-" },
                };
            }
            else
            {
                var c = m.GetSingle(catid);
                CurrentCat.Cat = m.GetSingle(c.parentId);

                if(CurrentCat.Cat == null)
                {
                    CurrentCat = new CatViewModel
                    {
                        Cat = new Cat { id = 0, name = "-root-" },
                    };
                }

            }

            CurrentCat.Path = m.GetFullPath(CurrentCat.Cat.id);
            CurrentCat.Children = m.GetCatsOf(CurrentCat.Cat.id);

            return Partial("_CatsPartial", CurrentCat);
        }

        public CatViewModel CurrentCat { get; set; } = new CatViewModel();
    }
}
