namespace Epistle.ActivityPub;

public partial class Object : Core
{
    public static readonly string[] ObjectTypes = [
        "Object",
        "Article",
        "Audio",
        "Document",
        "Event",
        "Image",
        "Note",
        "Page",
        "Place",
        "Profile",
        "Relationship",
        "Tombstone",
        "Video"
    ];

    public Uri? Id { get; set; }

    public IEnumerableTriple? Attachment { get; set; }

    public IEnumerableTriple? AttributedTo { get; set; }

    public IEnumerableTriple? Audience { get; set; }

    public string? Content { get; set; }

    public IDictionary<string, string>? ContentMap { get; set; }

    public IEnumerableTriple? Context { get; set; }

    public string? Name { get; set; }

    public DateTime? EndTime { get; set; }

    public IEnumerableTriple? Generator { get; set; }

    public IEnumerableTriple? Icon { get; set; }

    public IEnumerableTriple? Image { get; set; }

    public IEnumerableTriple? InReplyTo { get; set; }

    public IEnumerableTriple? Location { get; set; }

    public IEnumerableTriple? Preview { get; set; }

    public DateTime? Published { get; set; }

    public IEnumerableTriple? Replies { get; set; }

    public DateTime? StartTime { get; set; }

    public string? Summary { get; set; }

    public IDictionary<string, string>? SummaryMap { get; set; }

    public IEnumerableTriple? Tag { get; set; }

    public DateTime? Updated { get; set; }

    public IEnumerableTriple? Url { get; set; }

    public IEnumerableTriple? To { get; set; }

    public IEnumerableTriple? Bto { get; set; }

    public IEnumerableTriple? Cc { get; set; }

    public IEnumerableTriple? Bcc { get; set; }

    public string? MediaType { get; set; }

    public string? Duration { get; set; }
}