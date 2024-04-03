namespace Epistle.ActivityPub;

[JsonConverter(typeof(EnumerableTripleJsonConverter))]
public partial interface IEnumerableTriple : IEnumerable<Triple>
{
}

public partial class EnumerableTriple : List<Triple>, IEnumerableTriple
{
}
