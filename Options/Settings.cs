namespace RagApplication.Options;

/// <summary>Root of appsettings.json (sections "AzureOpenAI" and "AzureOpenAIEmbedding").</summary>
public class Settings
{
    public AzureOpenAI AzureOpenAI { get; set; } = new();
    public AzureOpenAIEmbedding AzureOpenAIEmbedding { get; set; } = new();
}

public class AzureOpenAI
{
    public string Endpoint { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public string Deployment { get; set; } = string.Empty;
}

public class AzureOpenAIEmbedding
{
    /// <summary>Optional. Falls back to AzureOpenAI:Endpoint when empty.</summary>
    public string Endpoint { get; set; } = string.Empty;
    /// <summary>Optional. Falls back to AzureOpenAI:ApiKey when empty.</summary>
    public string ApiKey { get; set; } = string.Empty;
    public string Deployment { get; set; } = string.Empty;
}
