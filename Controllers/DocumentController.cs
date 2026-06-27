using FileAssistant1.Models;
using FileAssistant1.Services.Interface;
using FileAssistant1.Services.Readers;
using Microsoft.AspNetCore.Mvc;

namespace FileAssistant1.Controllers
{
    public class DocumentController : Controller
    {
        private readonly PdfDocumentReader _reader;
        private readonly IChunkingService _chunkingService;

        public DocumentController(PdfDocumentReader reader, IChunkingService chunkingService)
        {
            _reader = reader;
            _chunkingService = chunkingService;
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

            using var stream = model.File.OpenReadStream();
            var text = await _reader.ReadAsync(stream);

            var chunks = _chunkingService.CreateChunks(text);
            return Content($"Total Chunks : {chunks.Count}");
        }
    }
}
