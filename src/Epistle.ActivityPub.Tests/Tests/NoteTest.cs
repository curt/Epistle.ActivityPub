namespace Epistle.ActivityPub.Tests;

[TestClass]
public class NoteTest
{
    [TestMethod]
    public void Instantiate()
    {
        Note obj = new();
        // StringAssert.StartsWith(obj.Id.ToString(), "https://example.com/object/");
    }
}
