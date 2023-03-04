namespace CatsRestAPILesson
{

    /*
     * Вариант упаковки блока данных для страницы
     * Но с другой стороны сама модель страницы и есть ViewModel
     * 
     * (!!!) Но вывод: если выбрал такую стилистику решений, то придерживаться ее.
     */
    public class CatViewModel
    {
        private readonly CatsModel repoService;

        public Cat? Cat { get; set; }
        public IEnumerable<Cat>? Children { get; set; }
        //public string? Path { get; set; }
        public IEnumerable<Cat>? Parents { get; set; }

        public CatViewModel(CatsModel repoService)
        {
            this.repoService = repoService;
        }

        public void LoadFor(int catid)
        {
            Cat = catid == 0 ? new Cat { id = 0, name = "" } : repoService.GetSingle(catid);
            Children = repoService.GetCatsOf(catid);
            Parents = repoService.GetAllParents(catid);
        }
    }
}
