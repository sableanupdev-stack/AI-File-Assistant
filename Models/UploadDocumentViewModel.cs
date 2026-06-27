namespace FileAssistant1.Models
{
    public class UploadDocumentViewModel
    {
        public IFormFile? File { get; set; }

        public string ExtractedText { get; set; } = string.Empty;
    }
}
