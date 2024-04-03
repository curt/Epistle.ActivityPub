namespace Epistle.ActivityPub.Tests;

[TestClass]
public class OrderedCollectionTests
{
    [TestMethod]
    public void Instantiate()
    {
        OrderedCollection obj = new();
        // StringAssert.StartsWith(obj.Id.ToString(), "https://example.com/object/");
    }

    [TestMethod]
    public void Example6()
    {
        string json = Examples.GetExample(6);
        var obj = ActivityPubJsonSerializer.Deserialize(json);

        Assert.IsInstanceOfType(obj, typeof(OrderedCollection));

        OrderedCollection collection = (OrderedCollection)obj;
        Assert.AreEqual(collection.Summary, "Sally's notes");
        Assert.AreEqual(collection.TotalItems, 2);

        Assert.IsInstanceOfType(collection.OrderedItems, typeof(IEnumerableTriple));
        Assert.AreEqual(collection.OrderedItems!.Count(), 2);
    }
}
