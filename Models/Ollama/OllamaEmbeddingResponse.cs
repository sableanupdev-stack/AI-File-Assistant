namespace FileAssistant1.Models.Ollama
{
    public class OllamaEmbeddingResponse
    {
        public string Model { get; set; } = string.Empty;

        public List<List<float>> Embeddings { get; set; } = new();

    }
}
