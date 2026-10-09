namespace RagApplication.Models;

public class DocumentWithEmbedding
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Source { get; set; } = string.Empty;   // file name / url
    public string Content { get; set; } = string.Empty;  // the text chunk
    public ReadOnlyMemory<float> Embedding { get; set; } // vector for the chunk
}
