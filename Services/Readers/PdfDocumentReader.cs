using FileAssistant1.Services.Interfaces;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System.Text;

namespace FileAssistant1.Services.Readers
{
    public class PdfDocumentReader : IDocumentReader
    {
        public async Task<string> ReadAsync(Stream stream)
        {
            var builder = new StringBuilder();

            using var reader = new PdfReader(stream);
            using var pdf = new PdfDocument(reader);

            for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
            {
                var page = pdf.GetPage(i);

                string text = PdfTextExtractor.GetTextFromPage(page);

                builder.AppendLine(text);
            }

            await Task.CompletedTask;

            return builder.ToString();
        }
    }
}
