namespace Epistle.ActivityPub.Tests;

[TestClass]
public class CreateTest
{
    [TestMethod]
    public void Instantiate()
    {
        Create obj = new();
        // StringAssert.StartsWith(obj.Id.ToString(), "https://example.com/activity/");
    }

    [TestMethod]
    public void Example15()
    {
        string json = Examples.GetExample(15);
        var obj = ActivityPubJsonSerializer.Deserialize(json);

        Assert.IsInstanceOfType(obj, typeof(Create));

        Create create = (Create)obj;
        object? createActorObj = create.Actor;
        object? createObjectObj = create.Object;

        Assert.IsInstanceOfType(createActorObj, typeof(EnumerableTriple));
        Assert.IsInstanceOfType(createObjectObj, typeof(EnumerableTriple));

        Triple actorTriple = ((EnumerableTriple)createActorObj!).First();
        Triple objectTriple = ((EnumerableTriple)createObjectObj!).First();

        Assert.IsInstanceOfType(actorTriple, typeof(Triple));
        Assert.IsInstanceOfType(objectTriple, typeof(Triple));
        Assert.IsInstanceOfType(actorTriple.Base, typeof(Person));
        Assert.IsInstanceOfType(objectTriple.Base, typeof(Note));

        Person actorPerson = (Person)actorTriple.Base!;
        Note objectPerson = (Note)objectTriple.Base!;

        Assert.AreEqual(actorPerson.Name, "Sally");
        Assert.AreEqual(objectPerson.Name, "A Simple Note");
    }
}
