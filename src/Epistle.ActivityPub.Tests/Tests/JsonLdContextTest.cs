namespace Epistle.ActivityPub.Tests;

[TestClass]
public class JsonLdContextTest
{
    [TestMethod]
    public void Example5()
    {
        string json = Examples.GetExample(5);
        var obj = ActivityPubJsonSerializer.Deserialize(json);

        Assert.IsInstanceOfType(obj, typeof(Collection));

        Collection collection = (Collection)obj;
        Assert.AreEqual("https://www.w3.org/ns/activitystreams", collection.JsonLdContext?.First().Uri.ToString());
    }
}