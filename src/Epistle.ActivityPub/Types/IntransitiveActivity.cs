namespace Epistle.ActivityPub;

public abstract class IntransitiveActivity : Object
{
    public IEnumerableTriple? Actor { get; set; }

    public IEnumerableTriple? Target { get; set; }

    public IEnumerableTriple? Result { get; set; }

    public IEnumerableTriple? Origin { get; set; }

    public IEnumerableTriple? Instrument { get; set; }
}
