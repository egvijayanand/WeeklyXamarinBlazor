using System.Text.Json.Serialization;

namespace WeeklyXamarin.Core.Models
{
    public record Index
    {
        public DateTime UpdatedTimeStamp { get; init; }

        public List<Edition> Editions { get; init; }

        public DateTime FetchedDate { get; set; }

        [JsonIgnore]
        public bool IsStale => FetchedDate < DateTime.UtcNow.AddMinutes(-5);
    }
}
