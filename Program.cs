using FileAssistant1.Configuration;
using FileAssistant1.Services;
using FileAssistant1.Services.Embeddings;
using FileAssistant1.Services.Ingestion;
using FileAssistant1.Services.Interfaces;
using FileAssistant1.Services.Readers;
using FileAssistant1.Services.VectorStore;
using Microsoft.Extensions.Options;
using Qdrant.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<PdfDocumentReader>();
builder.Services.AddScoped<IChunkingService, ChunkingService>();
builder.Services.Configure<OllamaSettings>(
    builder.Configuration.GetSection("Ollama"));
builder.Services.AddHttpClient<IEmbeddingService, OllamaEmbeddingService>();
builder.Services.AddScoped<
    IVectorStoreService,
    QdrantVectorStoreService>();
builder.Services.Configure<QdrantSettings>(
    builder.Configuration.GetSection("Qdrant"));
builder.Services.AddScoped<
    IDocumentIngestionService,
    DocumentIngestionService>();

builder.Services.AddSingleton<QdrantClient>(sp =>
{
    var settings = sp
        .GetRequiredService<IOptions<QdrantSettings>>()
        .Value;

    return new QdrantClient(
        host: settings.Host,
        port: settings.Port);
});
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var vectorStore = scope.ServiceProvider
        .GetRequiredService<IVectorStoreService>();

    await vectorStore.InitializeCollectionAsync();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
