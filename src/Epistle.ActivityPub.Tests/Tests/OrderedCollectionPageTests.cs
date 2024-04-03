namespace Epistle.ActivityPub.Tests;

[TestClass]
public class OrderedCollectionPageTests
{
    [TestMethod]
    public void Instantiate()
    {
        OrderedCollectionPage obj = new();
        // StringAssert.StartsWith(obj.Id.ToString(), "https://example.com/object/");
    }

    [TestMethod]
    public void Example8()
    {
        string json = Examples.GetExample(8);
        var obj = ActivityPubJsonSerializer.Deserialize(json);

        Assert.IsInstanceOfType(obj, typeof(OrderedCollectionPage));

        OrderedCollectionPage pages = (OrderedCollectionPage)obj;
        Assert.AreEqual(pages.Summary, "Page 1 of Sally's notes");
        Assert.AreEqual(pages.OrderedItems!.Count(), 2);
        Assert.AreEqual(pages.PartOf!.First().Base!, new Uri("http://example.org/foo"));
    }
}
