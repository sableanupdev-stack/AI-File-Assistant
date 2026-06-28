namespace FileAssistant1.Configuration
{
    public class QdrantSettings
    {
        public string Host { get; set; } = "localhost";

        public int Port { get; set; } = 6334;

        public string CollectionName { get; set; } = "documents";
    }
}
