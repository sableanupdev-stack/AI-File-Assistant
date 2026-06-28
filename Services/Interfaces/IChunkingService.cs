using FileAssistant1.Models;

namespace FileAssistant1.Services.Interfaces
{
    public interface IChunkingService
    {
        List<DocumentChunk> CreateChunks(string text);

    }
}
