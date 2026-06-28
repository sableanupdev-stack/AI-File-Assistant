using FileAssistant1.Models.Entities;

namespace FileAssistant1.Services.VectorStore
{
    public interface IVectorStoreService
    {
         Task InitializeCollectionAsync();

    Task StoreAsync(DocumentVector document);

    Task<List<DocumentVector>> SearchAsync(
        ReadOnlyMemory<float> embedding,
        int top = 5);
    }
}
