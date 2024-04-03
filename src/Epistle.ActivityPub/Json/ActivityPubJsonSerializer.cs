namespace Epistle.ActivityPub;

public class ActivityPubJsonSerializer
{
    public static string Serialize<T>(T obj) where T : Core
    {
        return JsonSerializer.Serialize(obj, typeof(T), DefaultJsonSerializerOptions());
    }

    public static string Serialize(object obj)
    {
        return JsonSerializer.Serialize(obj, obj.GetType(), DefaultJsonSerializerOptions());
    }

    public static object Deserialize(string json, Type t)
    {
        return JsonSerializer.Deserialize(json, t, DefaultJsonSerializerOptions())
            ?? throw new InvalidOperationException($"could not deserialize {t.Name} object");
    }

    public static object Deserialize(string json)
    {
        Core obj = (Core)Deserialize(json, typeof(Core));
        string names = typeof(Core).Namespace
            ?? throw new InvalidOperationException("could not find Core namespace");
        Type objType = Type.GetType($"{names}.{obj.Type}")!
            ?? throw new InvalidOperationException($"could not find type '{names}.{obj.Type}'");

        return Deserialize(json, objType);
    }

    public static JsonSerializerOptions DefaultJsonSerializerOptions()
    {
        return new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };
    }
}
