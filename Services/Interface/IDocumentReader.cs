namespace FileAssistant1.Services.Interface
{
    public interface IDocumentReader
    {
        Task<string> ReadAsync(Stream stream);
    }
}
