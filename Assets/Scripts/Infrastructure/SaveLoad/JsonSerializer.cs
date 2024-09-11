using Newtonsoft.Json;

public class JsonSerializer : ISerializer
{
    public string Serialize(object obj) => JsonConvert.SerializeObject(obj, Formatting.Indented);
    public T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);
}