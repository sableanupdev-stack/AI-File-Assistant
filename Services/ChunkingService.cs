using FileAssistant1.Models;
using FileAssistant1.Services.Interfaces;

namespace FileAssistant1.Services
{
    public class ChunkingService : IChunkingService
    {
        private const int ChunkSize = 500;

        public List<DocumentChunk> CreateChunks(string text)
        {
            var chunks = new List<DocumentChunk>();

            int chunkNumber = 1;

            for (int i = 0; i < text.Length; i += ChunkSize)
            {
                int length = Math.Min(ChunkSize, text.Length - i);

                chunks.Add(new DocumentChunk
                {
                    ChunkNumber = chunkNumber++,
                    Content = text.Substring(i, length)
                });
            }

            return chunks;
        }
    }
}
