namespace Epistle.ActivityPub;

public partial class CollectionPage : Collection
{
    public IEnumerableTriple? PartOf { get; set; }

    public IEnumerableTriple? Next { get; set; }

    public IEnumerableTriple? Prev { get; set; }
}
