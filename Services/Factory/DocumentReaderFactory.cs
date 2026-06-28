using FileAssistant1.Services.Interfaces;
using FileAssistant1.Services.Readers;

namespace FileAssistant1.Services.Factory
{
    public class DocumentReaderFactory
    {
        private readonly PdfDocumentReader _pdfReader;
        private readonly WordDocumentReader _wordReader;

        public DocumentReaderFactory(
            PdfDocumentReader pdfReader,
            WordDocumentReader wordReader)
        {
            _pdfReader = pdfReader;
            _wordReader = wordReader;
        }

        public IDocumentReader GetReader(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLower();

            return extension switch
            {
                ".pdf" => _pdfReader,
                ".docx" => _wordReader,
                _ => throw new NotSupportedException($"File type '{extension}' is not supported.")
            };
        }
    }
}