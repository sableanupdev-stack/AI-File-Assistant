using FileAssistant1.Services.Interfaces;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System.Text;

namespace FileAssistant1.Services.Readers
{
    public class PdfDocumentReader : IDocumentReader
    {
        public Task<string> ReadAsync(Stream stream)
        {
            var builder = new StringBuilder();

            using var reader = new PdfReader(stream);
            using var pdf = new PdfDocument(reader);

            for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
            {
                builder.AppendLine(
                    PdfTextExtractor.GetTextFromPage(pdf.GetPage(i)));
            }

            return Task.FromResult(builder.ToString());
        }
    }
}
