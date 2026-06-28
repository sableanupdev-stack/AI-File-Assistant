using FileAssistant1.Services.Interfaces;

namespace FileAssistant1.Services.Readers
{
    public class WordDocumentReader : IDocumentReader
    {
        public Task<string> ReadAsync(Stream stream)
        {
            throw new NotImplementedException("Word reader is not implemented yet.");
        }
    }
}