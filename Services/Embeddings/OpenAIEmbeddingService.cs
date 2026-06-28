namespace FileAssistant1.Services.Embeddings
{
    public class OpenAIEmbeddingService : IEmbeddingService
    {
        

        Task<ReadOnlyMemory<float>> IEmbeddingService.GenerateEmbeddingAsync(string text)
        {
            throw new NotImplementedException();
        }
    }
}
