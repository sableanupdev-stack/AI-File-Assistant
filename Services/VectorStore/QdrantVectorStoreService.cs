using FileAssistant1.Configuration;
using Microsoft.Extensions.Options;
using Qdrant.Client;

namespace FileAssistant1.Services.VectorStore
{
    public class QdrantVectorStoreService : IVectorStoreService
    {
        private readonly QdrantClient _client;
        private readonly QdrantSettings _settings;
        public QdrantVectorStoreService(IOptions<QdrantSettings> options)
        {
            _settings = options.Value;

            _client = new QdrantClient(
                _settings.Host,
                _settings.Port);
        }
        public Task InitializeCollectionAsync()
        {
            throw new NotImplementedException();
        }

        public Task StoreEmbeddingAsync(
            string id,
            ReadOnlyMemory<float> embedding,
            string text)
        {
            throw new NotImplementedException();
        }
    }
}
