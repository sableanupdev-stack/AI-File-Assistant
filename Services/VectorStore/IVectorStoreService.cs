using FileAssistant1.Models.Entities;
using FileAssistant1.Models.Search;

namespace FileAssistant1.Services.VectorStore
{
    public interface IVectorStoreService
    {
         Task InitializeCollectionAsync();

          Task StoreAsync(DocumentVector document);

        Task<List<SearchResult>> SearchAsync(
         ReadOnlyMemory<float> embedding,
         int top = 5);
    }
}
