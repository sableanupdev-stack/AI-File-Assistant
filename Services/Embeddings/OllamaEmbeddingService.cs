using FileAssistant1.Configuration;
using FileAssistant1.Models.Ollama;
using Microsoft.Extensions.Options;

namespace FileAssistant1.Services.Embeddings
{
    public class OllamaEmbeddingService : IEmbeddingService
    {
        private readonly HttpClient _httpClient;
        private readonly OllamaSettings _settings;

        public OllamaEmbeddingService(
                           HttpClient httpClient,
                           IOptions<OllamaSettings> options)
        {
            _httpClient = httpClient;
            _settings = options.Value;
        }

        public async Task<ReadOnlyMemory<float>> GenerateEmbeddingAsync(string text)
        {
            var request = new OllamaEmbeddingRequest
            {
                Model = _settings.EmbeddingModel,
                Input = text
            };

            var response = await _httpClient.PostAsJsonAsync(
                $"{_settings.Endpoint}/api/embed",
                request);

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                                       .ReadFromJsonAsync<OllamaEmbeddingResponse>();

            if (result == null || result.Embeddings.Count == 0)
            {
                throw new Exception("Embedding generation failed.");
            }

            return new ReadOnlyMemory<float>(
                result.Embeddings.First().ToArray());
          
        }
    }
}
