using MongoDB.Driver;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;

public class ItemCollection
{
    public IMongoCollection<Item> Items { get; }

    public ItemCollection()
    {
        // string mongoConnectionString = Environment.GetEnvironmentVariable("MongoConnectionString");
        // string mongoConnectionString = Configuration["ConnectionStrings:MongoDB"];
        // Console.WriteLine($"ItemCollection.cs:10 MongoConnectionString {mongoConnectionString}");

        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("ItemsDB");
        database.CreateCollection("Items");
        Items = database.GetCollection<Item>("Items");

        List<Item> list = Items.Find(p => true).ToList();

        foreach (Item item in list)
        {
            Console.WriteLine($"ItemID: {item.Id} - Items Name: {item.Name}");
        }
    }
}