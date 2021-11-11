using System;
using System.Collections.Generic;

namespace WeeklyXamarin.Core.Models
{
    public record Edition
    {
        public string Id { get; init; }

        public string Name { get; init; }

        public DateTime UpdatedTimestamp { get; init; }

        public string Summary { get; init; }

        public string Introduction { get; init; }

        public DateTime? PublishDate { get; init; }

        public string Curators { get; init; }

        public List<Article> Articles { get; init; }
    }
}
