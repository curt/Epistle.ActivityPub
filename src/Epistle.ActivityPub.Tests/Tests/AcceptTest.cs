namespace Epistle.ActivityPub.Tests;

[TestClass]
public class AcceptTest
{
    [TestMethod]
    public void Instantiate()
    {
        Activity obj = new() { Type = "Accept" };
        // StringAssert.StartsWith(obj.Id.ToString(), "https://example.com/activity/");
    }

    [TestMethod]
    public void Example9()
    {
        string json = Examples.GetExample(9);
        var obj = ActivityPubJsonSerializer.Deserialize(json);

        Assert.IsInstanceOfType(obj, typeof(Accept));

        Accept accept = (Accept)obj;
        Assert.AreEqual(accept.Summary, "Sally accepted an invitation to a party");

        object? acceptActorObj = accept.Actor;
        object? acceptObjectObj = accept.Object;

        Assert.IsInstanceOfType(acceptActorObj, typeof(EnumerableTriple));
        Assert.IsInstanceOfType(acceptObjectObj, typeof(EnumerableTriple));

        Triple actorTriple = ((EnumerableTriple)acceptActorObj!).First();
        Triple objectTriple = ((EnumerableTriple)acceptObjectObj!).First();

        Assert.IsInstanceOfType(actorTriple, typeof(Triple));
        Assert.IsInstanceOfType(objectTriple, typeof(Triple));
        Assert.IsInstanceOfType(actorTriple.Base, typeof(Person));
        Assert.IsInstanceOfType(objectTriple.Base, typeof(Invite));

        Person actorPerson = (Person)actorTriple.Base!;
        Invite objectInvite = (Invite)objectTriple.Base!;

        Assert.AreEqual(actorPerson.Name, "Sally");

        object? innerActorObj = objectInvite.Actor;
        object? innerObjectObj = objectInvite.Object;

        Assert.IsInstanceOfType(innerActorObj, typeof(EnumerableTriple));
        Assert.IsInstanceOfType(innerObjectObj, typeof(EnumerableTriple));

        Triple innerActorTriple = ((EnumerableTriple)innerActorObj!).First();
        Triple innerObjectTriple = ((EnumerableTriple)innerObjectObj!).First();

        Assert.IsInstanceOfType(innerActorTriple, typeof(Triple));
        Assert.IsInstanceOfType(innerObjectTriple, typeof(Triple));
        Assert.IsInstanceOfType(innerActorTriple.Base, typeof(Uri));
        Assert.IsInstanceOfType(innerObjectTriple.Base, typeof(Event));

        Uri innerActorUri = (Uri)innerActorTriple.Base!;
        Event innerObjectEvent = (Event)innerObjectTriple.Base!;

        Assert.AreEqual(innerActorUri, new Uri("http://john.example.org"));
        Assert.AreEqual(innerObjectEvent.Name, "Going-Away Party for Jim");
    }

    [TestMethod]
    public void Example10()
    {
        string json = Examples.GetExample(10);
        var obj = ActivityPubJsonSerializer.Deserialize(json);

        Assert.IsInstanceOfType(obj, typeof(Accept));

        Accept accept = (Accept)obj;
        Assert.AreEqual(accept.Summary, "Sally accepted Joe into the club");

        object? acceptActorObj = accept.Actor;
        object? acceptObjectObj = accept.Object;
        object? acceptTargetObj = accept.Target;

        Assert.IsInstanceOfType(acceptActorObj, typeof(EnumerableTriple));
        Assert.IsInstanceOfType(acceptObjectObj, typeof(EnumerableTriple));
        Assert.IsInstanceOfType(acceptTargetObj, typeof(EnumerableTriple));

        Triple actorTriple = ((EnumerableTriple)acceptActorObj!).First();
        Triple objectTriple = ((EnumerableTriple)acceptObjectObj!).First();
        Triple targetTriple = ((EnumerableTriple)acceptTargetObj!).First();

        Assert.IsInstanceOfType(actorTriple, typeof(Triple));
        Assert.IsInstanceOfType(objectTriple, typeof(Triple));
        Assert.IsInstanceOfType(targetTriple, typeof(Triple));
        Assert.IsInstanceOfType(actorTriple.Base, typeof(Person));
        Assert.IsInstanceOfType(objectTriple.Base, typeof(Person));
        Assert.IsInstanceOfType(targetTriple.Base, typeof(Group));

        Person actorPerson = (Person)actorTriple.Base!;
        Person objectPerson = (Person)objectTriple.Base!;
        Group targetGroup = (Group)targetTriple.Base!;

        Assert.AreEqual(actorPerson.Name, "Sally");
        Assert.AreEqual(objectPerson.Name, "Joe");
        Assert.AreEqual(targetGroup.Name, "The Club");
    }
}