
using MongoDB.Bson;
using MongoDB.Driver;

public class Item
{
    public ObjectId Id { get; set; }
    public string? Name { get; set; }
    public bool InStock { get; set; }
    public int Serial { get; set; }
    public int Size { get; set; }
    public int NumStock { get; set; }
}