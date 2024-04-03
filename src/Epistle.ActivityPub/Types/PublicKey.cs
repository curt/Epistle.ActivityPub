namespace Epistle.ActivityPub;

public partial class PublicKey
{
    public Uri? Id { get; set; }

    public Uri? Owner { get; set; }

    public string? PublicKeyPem { get; set; }
}
