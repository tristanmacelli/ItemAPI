
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using MongoDB.Driver.Linq;

public class Item
{
    // [BsonId]
    // [JsonConverter(typeof(StringToObjectId))]
    public ObjectId Id { get; set; }
    public string? Name { get; set; }
    public bool InStock { get; set; }
    public int Serial { get; set; }
    public int Size { get; set; }
    public int NumStock { get; set; }
}