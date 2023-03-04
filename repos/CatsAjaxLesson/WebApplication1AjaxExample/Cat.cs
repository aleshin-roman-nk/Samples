namespace WebApplication1AjaxExample
{
    public class Cat
    {
        public int id { get; set; }
        public int parentId { get; set; }
        public string? name { get; set; }
        public IList<CatProperty> CatProperties { get; set; } = new List<CatProperty>();
    }
}
