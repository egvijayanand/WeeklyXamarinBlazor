namespace WeeklyXamarin.Core.Models
{
    public record ExternalLinks
    {
        public ExternalLinks()
        {

        }

        public ExternalLinks(string url, string description)
        {
            Url = url;
            Description = description;
        }

        public string Url { get; init; }

        public string Description { get; init; }
    }
}
