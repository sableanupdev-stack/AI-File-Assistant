using FileAssistant1.Models.Entities;
using FileAssistant1.Services.Embeddings;
using FileAssistant1.Services.Factory;
using FileAssistant1.Services.Interfaces;
using FileAssistant1.Services.VectorStore;

namespace FileAssistant1.Services.Ingestion
{
    public class DocumentIngestionService : IDocumentIngestionService
    {
        private readonly DocumentReaderFactory _readerFactory;
        private readonly IChunkingService _chunkingService;
        private readonly IEmbeddingService _embeddingService;
        private readonly IVectorStoreService _vectorStore;

        public DocumentIngestionService(
                                         DocumentReaderFactory readerFactory,
                                         IChunkingService chunkingService,
                                         IEmbeddingService embeddingService,
                                         IVectorStoreService vectorStore
                                       )
        {
            _readerFactory = readerFactory;
            _chunkingService = chunkingService;
            _embeddingService = embeddingService;
            _vectorStore = vectorStore;
        }
        public async Task ProcessDocumentAsync(IFormFile file)
        {
            var reader = _readerFactory.GetReader(file.FileName);

            using var stream = file.OpenReadStream();

            var text = await reader.ReadAsync(stream);

            var chunks = _chunkingService.CreateChunks(text);

            await _vectorStore.InitializeCollectionAsync();

            foreach (var chunk in chunks)
            {
                var embedding = await _embeddingService.GenerateEmbeddingAsync(chunk.Content);

                var vector = new DocumentVector
                {
                    Id = Guid.NewGuid(),
                    Text = chunk.Content,
                    FileName = file.FileName,
                    ChunkIndex = chunk.ChunkNumber,
                    Embedding = embedding
                };

                await _vectorStore.StoreAsync(vector);
            }
        }
    }
}
