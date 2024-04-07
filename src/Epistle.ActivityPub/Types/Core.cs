namespace Epistle.ActivityPub;

public partial class Core
{
    private string? _type;

    public string? Type { get { return _type ?? GetType().Name; } set { _type = value; } }

    [JsonPropertyName("@context")]
    public IEnumerableTriple? JsonLdContext { get; set; }
}
