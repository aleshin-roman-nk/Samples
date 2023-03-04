namespace WebApplication1AjaxExample
{
    public class CatViewModel
    {
        public Cat? Cat { get; set; }
        public IEnumerable<Cat>? Children { get; set; }
        public string? Path { get; set; }
    }
}
