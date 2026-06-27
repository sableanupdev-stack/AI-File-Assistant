namespace FileAssistant1.Services.Embeddings
{
    public class OpenAIEmbeddingService : IEmbeddingService
    {
        public async Task<float[]> GenerateEmbeddingAsync(string text)
        {
            // We'll call OpenAI here in the next step.
            await Task.CompletedTask;

            return Array.Empty<float>();
        }
    }
}
