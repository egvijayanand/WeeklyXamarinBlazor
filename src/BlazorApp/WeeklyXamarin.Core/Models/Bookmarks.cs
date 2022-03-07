namespace WeeklyXamarin.Core.Models
{
    public class Bookmark
    {
        public List<Article> Articles { get; set; } = new();

        public void Add(Article articleToSave)
        {
            var article = Articles.FirstOrDefault(a => a.Id == articleToSave.Id);

            if (article == null)
            {
                Articles.Add(articleToSave);
            }
        }

        public void Remove(Article articleToRemove)
        {
            var article = Articles.FirstOrDefault(a => a.Id == articleToRemove.Id);

            if (article != null)
            {
                Articles.Remove(article);
            }
        }
    }
}
