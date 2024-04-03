namespace Epistle.ActivityPub;

public partial class Collection : Object
{
    public long? TotalItems { get; set; }

    public IEnumerableTriple? Items { get; set; }

    public IEnumerableTriple? Current { get; set; }

    public IEnumerableTriple? First { get; set; }

    public IEnumerableTriple? Last { get; set; }

    // Note: This property is not specified in the W3C vocabulary
    // but is implied in its examples.    
    public IEnumerableTriple? OrderedItems { get; set; }
}