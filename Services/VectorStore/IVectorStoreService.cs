namespace FileAssistant1.Services.VectorStore
{
    public interface IVectorStoreService
    {
        Task InitializeCollectionAsync();

        Task StoreEmbeddingAsync(
            string id,
            ReadOnlyMemory<float> embedding,
            string text);
    }
}
