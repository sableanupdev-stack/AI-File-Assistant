namespace FileAssistant1.Services.Interfaces
{
    public interface IDocumentReader
    {
        Task<string> ReadAsync(Stream stream);
    }
}
