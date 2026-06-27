using FileAssistant1.Models;

namespace FileAssistant1.Services.Interface
{
    public interface IChunkingService
    {
        List<DocumentChunk> CreateChunks(string text);

    }
}
