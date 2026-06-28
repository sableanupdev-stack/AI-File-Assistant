namespace FileAssistant1.Models.Entities
{
    public class DocumentVector
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = string.Empty;

        public string FileName { get; set; } = string.Empty;

        public int ChunkIndex { get; set; }

        public ReadOnlyMemory<float> Embedding { get; set; }
    }
}
