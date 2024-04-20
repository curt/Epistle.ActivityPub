namespace Epistle.ActivityPub.Tests;

[TestClass]
public class ExtraElementsTest
{
    [TestMethod]
    public void DeserializeExtraElements()
    {
        string json = """
            {
                "@context": "https://www.w3.org/ns/activitystreams",
                "type": "Person",
                "id": "http://www.test.example/actor/1",
                "bogusElement": "Gobbledygook!"
            }
            """;

        var baseObj = ActivityPubJsonSerializer.Deserialize(json)!;

        Assert.IsInstanceOfType(baseObj, typeof(ICore));
        Assert.IsInstanceOfType(baseObj, typeof(Person));

        var person = (Person)baseObj;
        Assert.IsNotNull(person.ExtraElements);
        Assert.AreEqual(1, person.ExtraElements.Count);
        Assert.IsTrue(person.ExtraElements.ContainsKey("bogusElement"));
        Assert.AreEqual("Gobbledygook!", person.ExtraElements["bogusElement"].ToString());
    }
}
