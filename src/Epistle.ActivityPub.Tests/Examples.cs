namespace Epistle.ActivityPub.Tests;

public class Examples
{
    public static string GetExample(int number)
    {
        string filename = $"Examples.{number}.json";

        // See https://stackoverflow.com/a/56753308
        var assembly = typeof(Examples).Assembly;
        var resourceNames = assembly.GetManifestResourceNames();
        var resourceName = resourceNames.First(s => s.EndsWith(filename, StringComparison.CurrentCultureIgnoreCase));

        using var stream = assembly.GetManifestResourceStream(resourceName)
            ?? throw new InvalidOperationException($"could not find resource '{filename}'");
        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }
}
