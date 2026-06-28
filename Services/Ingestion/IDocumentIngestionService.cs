namespace FileAssistant1.Services.Ingestion
{
    public interface IDocumentIngestionService
    {
        Task ProcessDocumentAsync(IFormFile file);
    }
}
