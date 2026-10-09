using Microsoft.SemanticKernel;
using RagApplication.Options;

var builder = WebApplication.CreateBuilder(args);

// ---- MVC ----
builder.Services.AddControllersWithViews();

// ---- Strongly typed settings (appsettings.json / user-secrets / env vars) ----
builder.Services.Configure<Settings>(builder.Configuration);
var settings = builder.Configuration.Get<Settings>()
    ?? throw new InvalidOperationException("Missing configuration.");

if (string.IsNullOrWhiteSpace(settings.AzureOpenAI.Endpoint) ||
    string.IsNullOrWhiteSpace(settings.AzureOpenAI.ApiKey) ||
    string.IsNullOrWhiteSpace(settings.AzureOpenAI.Deployment) ||
    string.IsNullOrWhiteSpace(settings.AzureOpenAIEmbedding.Deployment))
{
    throw new InvalidOperationException(
        "Azure OpenAI settings are incomplete. Set them in appsettings.json or user-secrets.");
}

// ---- Semantic Kernel: chat + embeddings ----
builder.Services.AddKernel()
    .AddAzureOpenAIChatCompletion(
        deploymentName: settings.AzureOpenAI.Deployment,
        endpoint: settings.AzureOpenAI.Endpoint,
        apiKey: settings.AzureOpenAI.ApiKey)
    .AddAzureOpenAITextEmbeddingGeneration(
        deploymentName: settings.AzureOpenAIEmbedding.Deployment,
        endpoint: string.IsNullOrWhiteSpace(settings.AzureOpenAIEmbedding.Endpoint)
            ? settings.AzureOpenAI.Endpoint : settings.AzureOpenAIEmbedding.Endpoint,
        apiKey: string.IsNullOrWhiteSpace(settings.AzureOpenAIEmbedding.ApiKey)
            ? settings.AzureOpenAI.ApiKey : settings.AzureOpenAIEmbedding.ApiKey);

// ---- Your own services (uncomment as you create them) ----
// builder.Services.AddSingleton<IVectorStore, InMemoryVectorStore>();
// builder.Services.AddScoped<IDocumentIngestionService, DocumentIngestionService>();
// builder.Services.AddScoped<IRagService, RagService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
