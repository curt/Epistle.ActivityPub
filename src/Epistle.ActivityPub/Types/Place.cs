namespace Epistle.ActivityPub;

public partial class Place : Object
{
    public double? Accuracy { get; set; }

    public double? Longitude { get; set; }

    public double? Latitude { get; set; }

    public double? Radius { get; set; }

    public string? Units { get; set; }
}
