namespace Epistle.ActivityPub;

public interface ICore
{
    string? Type { get; set; }
    IEnumerableTriple? JsonLdContext { get; set; }
    IDictionary<string, object>? ExtraElements { get; set; }
}
