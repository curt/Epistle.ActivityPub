namespace Epistle.ActivityPub;

public class EnumerableTripleJsonConverter : JsonConverter<IEnumerableTriple>
{
    public override IEnumerableTriple? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        EnumerableTriple list = [];

        if (reader.TokenType == JsonTokenType.String)
        {
            JsonReadString(ref reader, list);
            return list;
        }
        else if (reader.TokenType == JsonTokenType.StartObject)
        {
            JsonReadObject(ref reader, list);
            return list;
        }
        else if (reader.TokenType == JsonTokenType.StartArray)
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    return list;
                }
                else if (reader.TokenType == JsonTokenType.String)
                {
                    JsonReadString(ref reader, list);
                }
                else if (reader.TokenType == JsonTokenType.StartObject)
                {
                    JsonReadObject(ref reader, list);
                }
            }
        }

        throw new InvalidOperationException($"unable to parse {typeof(Triple).Name} object");
    }

    private static void JsonReadString(ref Utf8JsonReader reader, EnumerableTriple list)
    {
        string? read = reader.GetString();
        if (read != null)
        {
            list.Add(new(new Uri(read)));
        }
    }

    private static void JsonReadObject(ref Utf8JsonReader reader, EnumerableTriple list)
    {
        // See https://stackoverflow.com/a/60402592
        using var jsonDoc = JsonDocument.ParseValue(ref reader);

        object? obj = ActivityPubJsonSerializer.Deserialize(jsonDoc.RootElement.ToString());

        if (obj is Link link)
        {
            list.Add(new Triple(link));
        }
        else if (obj is Object objet)
        {
            list.Add(new Triple(objet));
        }
        else
        {
            throw new InvalidOperationException($"could not read object of type {obj.GetType().Name}");
        }
    }

    public override void Write(Utf8JsonWriter writer, IEnumerableTriple triages, JsonSerializerOptions options)
    {
        if (triages.Count() == 1)
        {
            JsonWriteTriple(writer, triages.First());
        }
        else
        {
            writer.WriteStartArray();

            foreach (var triage in triages)
            {
                JsonWriteTriple(writer, triage);
            }

            writer.WriteEndArray();
        }
    }

    private static void JsonWriteTriple(Utf8JsonWriter writer, Triple triage)
    {
        switch (triage.EntityType)
        {
            case TripleEnum.Uri:
                writer.WriteStringValue(triage.Uri.ToString());
                return;
            default:
                string obj = ActivityPubJsonSerializer.Serialize(triage.Base!);

                // See https://stackoverflow.com/a/68394777
                using (JsonDocument document = JsonDocument.Parse(obj))
                {
                    document.RootElement.WriteTo(writer);
                }

                return;
        }

        throw new NotImplementedException();
    }
}