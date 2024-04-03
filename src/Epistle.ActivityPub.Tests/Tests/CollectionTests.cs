namespace Epistle.ActivityPub.Tests;

[TestClass]
public class CollectionTests
{
    [TestMethod]
    public void Instantiate()
    {
        Collection obj = new();
        // StringAssert.StartsWith(obj.Id.ToString(), "https://example.com/object/");
    }

    [TestMethod]
    public void Example5()
    {
        string json = Examples.GetExample(5);
        var obj = ActivityPubJsonSerializer.Deserialize(json);

        Assert.IsInstanceOfType(obj, typeof(Collection));

        Collection collection = (Collection)obj;
        Assert.AreEqual(collection.Summary, "Sally's notes");
        Assert.AreEqual(collection.TotalItems, 2);
        Assert.AreEqual(collection.Items!.Count(), 2);
    }
}
