using FileAssistant1.Configuration;
using FileAssistant1.Models.Entities;
using Microsoft.Extensions.Options;
using Qdrant.Client;
using Qdrant.Client.Grpc;

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

        public async Task InitializeCollectionAsync()
        {
            var collections = await _client.ListCollectionsAsync();

            if (collections.Contains(_settings.CollectionName))
                return;

            await _client.CreateCollectionAsync(
                collectionName: _settings.CollectionName,
                vectorsConfig: new VectorParams
                {
                    Size = 768,
                    Distance = Distance.Cosine
                });
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
