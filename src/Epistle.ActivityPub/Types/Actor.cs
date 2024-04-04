namespace Epistle.ActivityPub;

public partial class Actor : Object
{
    public static readonly string[] ActorTypes = [
        "Application",
        "Group",
        "Organization",
        "Person",
        "Service"
    ];

    public string? PreferredUsername { get; set; }

    public Uri? Inbox { get; set; }

    public Uri? Outbox { get; set; }

    public Uri? Following { get; set; }

    public Uri? Followers { get; set; }

    public PublicKey? PublicKey { get; set; }
}
