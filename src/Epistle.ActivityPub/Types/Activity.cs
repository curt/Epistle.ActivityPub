namespace Epistle.ActivityPub;

public partial class Activity : Object
{
    public static readonly string[] ActivityTypes = [
        "Accept",
        "Add",
        "Announce",
        "Arrive",
        "Block",
        "Create",
        "Delete",
        "Dislike",
        "Flag",
        "Follow",
        "Ignore",
        "Invite",
        "Join",
        "Leave",
        "Like",
        "Listen",
        "Move",
        "Offer",
        "Question",
        "Reject",
        "Read",
        "Remove",
        "TentativeReject",
        "TentativeAccept",
        "Travel",
        "Undo",
        "Update",
        "View",
    ];

    public IEnumerableTriple? Actor { get; set; }

    public IEnumerableTriple? Object { get; set; }

    public IEnumerableTriple? Target { get; set; }

    public IEnumerableTriple? Result { get; set; }

    public IEnumerableTriple? Origin { get; set; }

    public IEnumerableTriple? Instrument { get; set; }
}
