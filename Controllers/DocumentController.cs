using FileAssistant1.Models;
using FileAssistant1.Services.Embeddings;
using FileAssistant1.Services.Ingestion;
using Microsoft.AspNetCore.Mvc;

namespace FileAssistant1.Controllers
{

    public class DocumentController : Controller
    {

        private readonly IDocumentIngestionService _documentIngestionService;

        public DocumentController(
            IDocumentIngestionService documentIngestionService)
        {
            _documentIngestionService = documentIngestionService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UploadDocumentViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(UploadDocumentViewModel model)
        {
            if (model.File == null)
                return View(model);

            await _documentIngestionService.ProcessDocumentAsync(model.File);

            ViewBag.Message = "Document uploaded successfully and indexed.";

            return View(new UploadDocumentViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> TestEmbedding(
        [FromServices] IEmbeddingService embeddingService)
        {
            var embedding = await embeddingService.GenerateEmbeddingAsync("I love .NET");

            return Json(new
            {
                Dimension = embedding.Length,
                First10Values = embedding.ToArray().Take(10)
            });
        }
    }
}
