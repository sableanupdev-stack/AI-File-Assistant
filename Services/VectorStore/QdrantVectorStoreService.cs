using FileAssistant1.Configuration;
using FileAssistant1.Models.Entities;
using FileAssistant1.Models.Search;
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

        public async Task<List<SearchResult>> SearchAsync(ReadOnlyMemory<float> embedding,int top = 5)
        {
            var results = await _client.QueryAsync(
                collectionName: _settings.CollectionName,
                query: embedding.ToArray(),
                limit: (ulong)top);

            var documents = new List<SearchResult>();

            foreach (var point in results)
            {
                var document = new DocumentVector
                {
                    Id = Guid.Parse(point.Id.Uuid),

                    Text = point.Payload["text"].StringValue,

                    FileName = point.Payload["fileName"].StringValue,

                    ChunkIndex = (int)point.Payload["chunkIndex"].IntegerValue
                };

                documents.Add(new SearchResult
                {
                    Document = document,
                    Score = point.Score
                });
            }

            return documents;
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
