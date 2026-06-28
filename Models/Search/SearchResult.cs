using FileAssistant1.Models.Entities;

namespace FileAssistant1.Models.Search
{
    public class SearchResult
    {
        public DocumentVector Document { get; set; } = new();

        public float Score { get; set; }
    }
}
