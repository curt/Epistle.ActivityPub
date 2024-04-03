namespace Epistle.ActivityPub.Tests;

[TestClass]
public class PersonTest
{
    [TestMethod]
    public void InstantiatePerson()
    {
        Person obj = new();
        // Assert.IsTrue(obj.Id.ToString().StartsWith("https://example.com/actor/"));
    }

    [TestMethod]
    public void DeserializeMinimalPerson()
    {
        var now = DateTime.Parse("2023-11-08T14:09:48.372475Z").ToUniversalTime();
        string json = """
            {
                "@context": "https://www.w3.org/ns/activitystreams",
                "type": "Person",
                "id": "http://www.test.example/actor/1",
                "name": "A Simple, non-specific object",
                "endTime": "2023-11-08T14:09:48.372475Z",
                "published": "2023-11-08T14:09:48.372475Z",
                "startTime": "2023-11-08T14:09:48.372475Z",
                "updated": "2023-11-08T14:09:48.372475Z"
            }
            """;

        var baseObj = ActivityPubJsonSerializer.Deserialize(json)!;

        Assert.IsInstanceOfType(baseObj, typeof(Person));

        var obj = (Person)baseObj;

        Assert.AreEqual(obj.Id!.ToString(), "http://www.test.example/actor/1");
        Assert.AreEqual(obj.Name, "A Simple, non-specific object");
        Assert.AreEqual(obj.StartTime, now);
        Assert.AreEqual(obj.EndTime, now);
        Assert.AreEqual(obj.Published, now);
        Assert.AreEqual(obj.Updated, now);
    }

    [TestMethod]
    public void DeserializePersonToString()
    {
        string json = """
            {
                "@context": "https://www.w3.org/ns/activitystreams",
                "type": "Person",
                "id": "http://www.test.example/object/1",
                "to": "http://www.test.example/actor/1"
            }
            """;

        var baseObj = ActivityPubJsonSerializer.Deserialize(json)!;

        Assert.IsInstanceOfType(baseObj, typeof(Person));

        var obj = (Person)baseObj;

        Assert.AreEqual(obj.To!.First().Uri.ToString(), "http://www.test.example/actor/1");
    }

    [TestMethod]
    public void DeserializePersonToArray()
    {
        string json = """
            {
                "@context": "https://www.w3.org/ns/activitystreams",
                "type": "Person",
                "id": "http://www.test.example/object/1",
                "to": [
                    "http://www.test.example/actor/1"
                ]
            }
            """;

        var baseObj = ActivityPubJsonSerializer.Deserialize(json)!;

        Assert.IsInstanceOfType(baseObj, typeof(Person));

        var obj = (Person)baseObj;

        Assert.AreEqual(obj.To!.First().Uri.ToString(), "http://www.test.example/actor/1");
    }

    [TestMethod]
    public void DeserializePersonToArrayLinkObject()
    {
        string json = """
            {
                "@context": "https://www.w3.org/ns/activitystreams",
                "type": "Person",
                "id": "http://www.test.example/object/1",
                "to": [
                    {
                        "type": "Link",
                        "href": "http://www.test.example/actor/1"
                    }
                ]
            }
            """;

        var baseObj = ActivityPubJsonSerializer.Deserialize(json)!;

        Assert.IsInstanceOfType(baseObj, typeof(Person));

        var obj = (Person)baseObj;

        Assert.AreEqual(obj.To!.First().Uri.ToString(), "http://www.test.example/actor/1");
    }

    [TestMethod]
    public void DeserializePersonToArrayObjectObject()
    {
        // TODO: Better if this were a person.
        string json = """
            {
                "@context": "https://www.w3.org/ns/activitystreams",
                "type": "Person",
                "id": "http://www.test.example/object/1",
                "to": [
                    {
                        "type": "Person",
                        "id": "http://www.test.example/actor/1"
                    }
                ]
            }
            """;

        var baseObj = ActivityPubJsonSerializer.Deserialize(json)!;

        Assert.IsInstanceOfType(baseObj, typeof(Person));

        var obj = (Person)baseObj;

        Assert.AreEqual(obj.To!.First().Uri.ToString(), "http://www.test.example/actor/1");
    }

    [TestMethod]
    public void SerializeMinimalPerson()
    {
        var now = DateTime.UtcNow;
        var obj = new Person
        {
            Id = new Uri("https://example.com/object/321"),
            Name = "Simple name",
            Published = now,
            Updated = now,
            StartTime = now,
            EndTime = now
        };

        var json = ActivityPubJsonSerializer.Serialize<Person>(obj);

        Assert.IsInstanceOfType(json, typeof(string));
    }

    [TestMethod]
    public void SerializeToUri()
    {
        var obj = new Person
        {
            Id = new Uri("https://example.com/object/321"),
            Name = "Simple name",
            To = new EnumerableTriple() { new Triple(new Uri("http://www.test.example/actor/1")) }
        };

        var json = ActivityPubJsonSerializer.Serialize<Person>(obj);

        Assert.IsInstanceOfType(json, typeof(string));
        StringAssert.Contains(json, "\"to\":\"http://www.test.example/actor/1\"");
    }

    [TestMethod]
    public void SerializeToLink()
    {
        var obj = new Person
        {
            Id = new Uri("https://example.com/object/321"),
            Name = "Simple name",
            To = new EnumerableTriple() { new Triple(new Link { Href = new Uri("http://www.test.example/actor/1") }) }
        };

        var json = ActivityPubJsonSerializer.Serialize<Person>(obj);

        Assert.IsInstanceOfType(json, typeof(string));
        StringAssert.Contains(json, "\"type\":\"Link\"");
        StringAssert.Contains(json, "\"href\":\"http://www.test.example/actor/1\"");
    }

    [TestMethod]
    public void SerializeToMultipleUri()
    {
        var obj = new Person
        {
            Id = new Uri("https://example.com/object/321"),
            Name = "Simple name",
            To = new EnumerableTriple() {
                new Triple(new Uri("http://www.test.example/actor/1")),
                new Triple(new Uri("http://www.test.example/actor/2"))
                }
        };

        var json = ActivityPubJsonSerializer.Serialize<Person>(obj);

        Assert.IsInstanceOfType(json, typeof(string));
        StringAssert.Contains(json, "\"to\":[\"http://www.test.example/actor/1\",\"http://www.test.example/actor/2\"]");
    }
}