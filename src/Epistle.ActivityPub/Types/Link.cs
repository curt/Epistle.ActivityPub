namespace Epistle.ActivityPub;

public partial class Link : Core
{
    public static readonly string[] LinkTypes = [
        "Link",
        "Mention"
    ];

    public string? Id
    {
        get
        {
            return Href?.ToString();
        }
        set
        {
            if (value is not null)
                Href = new Uri(value);
        }
    }

    public Uri? Href { get; set; }

    public string? Rel { get; set; }

    public string? MediaType { get; set; }

    public string? Name { get; set; }

    public string? Hreflang { get; set; }

    public long? Height { get; set; }

    public long? Width { get; set; }

    public IEnumerableTriple? Preview { get; set; }
}
