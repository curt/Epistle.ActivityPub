
namespace Epistle.ActivityPub;

public partial class Core : ICore
{
    private string? _type;

    public string? Type { get { return _type ?? GetType().Name; } set { _type = value; } }

    [JsonPropertyName("@context")]
    public IEnumerableTriple? JsonLdContext { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object>? ExtraElements { get; set; }
}
