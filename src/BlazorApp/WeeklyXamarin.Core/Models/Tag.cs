namespace WeeklyXamarin.Core.Models
{
    public class Tag
    {
        public List<Category> Categories { get; set; }
    }

    public class Category
    {
        public string Name { get; set; }
    }
}
