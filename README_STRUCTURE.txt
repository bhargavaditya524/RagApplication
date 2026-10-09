RagApplication/
├── Properties/launchSettings.json
├── wwwroot/
├── Controllers/        HomeController.cs  (+ ChatController.cs, DocumentsController.cs later)
├── Models/             ErrorViewModel.cs, DocumentWithEmbedding.cs
├── Options/            Settings.cs
├── Services/
│   ├── Interfaces/     IVectorStore, IRagService, IDocumentIngestionService
│   └── (implementations)
├── Views/
├── appsettings.json
├── Program.cs
└── RagApplication.csproj   (renamed from RAG.csproj)
