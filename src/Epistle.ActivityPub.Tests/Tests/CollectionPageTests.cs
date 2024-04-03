namespace Epistle.ActivityPub.Tests;

[TestClass]
public class CollectionPageTests
{
    [TestMethod]
    public void Instantiate()
    {
        CollectionPage obj = new();
        // StringAssert.StartsWith(obj.Id.ToString(), "https://example.com/object/");
    }

    [TestMethod]
    public void Example7()
    {
        string json = Examples.GetExample(7);
        var obj = ActivityPubJsonSerializer.Deserialize(json);

        Assert.IsInstanceOfType(obj, typeof(CollectionPage));

        CollectionPage pages = (CollectionPage)obj;
        Assert.AreEqual(pages.Summary, "Page 1 of Sally's notes");
        Assert.AreEqual(pages.Items!.Count(), 2);
        Assert.AreEqual(pages.PartOf!.First().Base!, new Uri("http://example.org/foo"));
    }
}
