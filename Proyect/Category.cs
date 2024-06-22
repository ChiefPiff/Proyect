using System.Text.Json;

public interface IJsonSerializable
{
    string ToJson();
}

public class Category : IJsonSerializable
{
    public int CategoryId { get; set; }
    public string Name { get; set; }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}
