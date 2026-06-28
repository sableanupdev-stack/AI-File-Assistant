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

        public async Task StoreAsync(DocumentVector document)
        {
            var point = new PointStruct
            {
                Id = new PointId
                {
                    Uuid = document.Id.ToString()
                },
                Vectors = new Vectors
                {
                    Vector = new Vector
                    {
                        Data = { document.Embedding.ToArray() }
                    }
                },
                Payload =
                {
                    ["text"] = document.Text,
                    ["fileName"] = document.FileName,
                    ["chunkIndex"] = document.ChunkIndex,
                    ["uploadedAt"] = DateTime.UtcNow.ToString("O")
                }
            };

            await _client.UpsertAsync(
                collectionName: _settings.CollectionName,
                points: new[] { point });
        }
    }
}
