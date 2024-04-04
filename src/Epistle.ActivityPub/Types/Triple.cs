namespace Epistle.ActivityPub;

public partial class Triple
{
    private readonly TripleEnum _type;
    private readonly Uri? _uri;
    private readonly Object? _obj;
    private readonly Link? _link;

    public Triple(Uri uri)
    {
        _type = TripleEnum.Uri;
        _uri = uri;
    }

    public Triple(Object obj)
    {
        _type = TripleEnum.Object;
        _obj = obj;
    }

    public Triple(Link link)
    {
        if (link.Href == null)
            throw new ArgumentException($"argument has null {nameof(link.Href)} property", nameof(link));

        _type = TripleEnum.Link;
        _link = link;
    }

    public Uri Uri
    {
        get
        {
            return _type switch
            {
                TripleEnum.Uri => _uri,
                TripleEnum.Object => _obj!.Id,
                TripleEnum.Link => _link!.Href!,
                _ => throw new NotImplementedException()
            } ?? throw new NullReferenceException();
        }
    }

    public TripleEnum EntityType { get { return _type; } }

    public object? Base
    {
        get
        {
            return _type switch
            {
                TripleEnum.Uri => _uri,
                TripleEnum.Object => _obj,
                TripleEnum.Link => _link,
                _ => throw new NotImplementedException()
            };
        }
    }
}
