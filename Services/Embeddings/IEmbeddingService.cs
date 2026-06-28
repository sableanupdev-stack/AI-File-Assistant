namespace FileAssistant1.Services.Embeddings
{
    public interface IEmbeddingService
    {
        Task<ReadOnlyMemory<float>> GenerateEmbeddingAsync(string text);
    }
}
