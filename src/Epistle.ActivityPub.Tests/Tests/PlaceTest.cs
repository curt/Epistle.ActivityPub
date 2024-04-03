namespace Epistle.ActivityPub.Tests;

[TestClass]
public class PlaceTest
{
    [TestMethod]
    public void Instantiate()
    {
        Place obj = new();
        // StringAssert.StartsWith(obj.Id.ToString(), "https://example.com/object/");
    }

    [TestMethod]
    public void Example56()
    {
        string json = Examples.GetExample(56);
        var obj = ActivityPubJsonSerializer.Deserialize(json);

        Assert.IsInstanceOfType(obj, typeof(Place));

        Place place = (Place)obj;

        Assert.AreEqual(place.Name, "Work");
    }

    [TestMethod]
    public void Example57()
    {
        string json = Examples.GetExample(57);
        var obj = ActivityPubJsonSerializer.Deserialize(json);

        Assert.IsInstanceOfType(obj, typeof(Place));

        Place place = (Place)obj;

        Assert.AreEqual(place.Name, "Fresno Area");
        Assert.AreEqual(place.Latitude, 36.75);
        Assert.AreEqual(place.Longitude, 119.7667);
        Assert.AreEqual(place.Radius, 15);
        Assert.AreEqual(place.Units, "miles");
    }
}