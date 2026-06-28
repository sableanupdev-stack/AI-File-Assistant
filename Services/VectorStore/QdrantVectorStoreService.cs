using FileAssistant1.Configuration;
using FileAssistant1.Models.Entities;
using Microsoft.Extensions.Options;
using Qdrant.Client;

namespace FileAssistant1.Services.VectorStore
{
    public class QdrantVectorStoreService : IVectorStoreService
    {
        private readonly QdrantClient _client;
        private readonly QdrantSettings _settings;
        public QdrantVectorStoreService(
     QdrantClient client,
     IOptions<QdrantSettings> options)
        {
            _client = client;
            _settings = options.Value;
        }

        public Task InitializeCollectionAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<DocumentVector>> SearchAsync(ReadOnlyMemory<float> embedding, int top = 5)
        {
            throw new NotImplementedException();
        }

        public Task StoreAsync(DocumentVector document)
        {
            throw new NotImplementedException();
        }
    }
}
