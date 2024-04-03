namespace Epistle.ActivityPub.Tests;

[TestClass]
public class FollowTest
{
    [TestMethod]
    public void Instantiate()
    {
        Follow obj = new();
        // StringAssert.StartsWith(obj.Id.ToString(), "https://example.com/activity/");
    }

    [TestMethod]
    public void Example17()
    {
        string json = Examples.GetExample(17);
        var obj = ActivityPubJsonSerializer.Deserialize(json);

        Assert.IsInstanceOfType(obj, typeof(Follow));

        Follow follow = (Follow)obj;
        object? followActorObj = follow.Actor;
        object? followObjectObj = follow.Object;

        Assert.IsInstanceOfType(followActorObj, typeof(EnumerableTriple));
        Assert.IsInstanceOfType(followObjectObj, typeof(EnumerableTriple));

        Triple actorTriple = ((EnumerableTriple)followActorObj!).First();
        Triple objectTriple = ((EnumerableTriple)followObjectObj!).First();

        Assert.IsInstanceOfType(actorTriple, typeof(Triple));
        Assert.IsInstanceOfType(objectTriple, typeof(Triple));
        Assert.IsInstanceOfType(actorTriple.Base, typeof(Person));
        Assert.IsInstanceOfType(objectTriple.Base, typeof(Person));

        Person actorPerson = (Person)actorTriple.Base!;
        Person objectPerson = (Person)objectTriple.Base!;

        Assert.AreEqual(actorPerson.Name, "Sally");
        Assert.AreEqual(objectPerson.Name, "John");
    }
}
