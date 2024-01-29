using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// Connect to MongoDB && Access the item collection
IMongoCollection<Item> itemCollection = new ItemCollection().Items;

// Sane default route for testing purposes
app.MapGet("/", () =>
{
    return "Hello World!";
});

var inventoryItems = app.MapGroup("inventoryItems");

// Registered routes (enables typed return in function handle)
inventoryItems.MapGet("/", GetAllItems);
inventoryItems.MapGet("/inStock", GetInStockItems);
inventoryItems.MapGet("/{id}", GetItem);
inventoryItems.MapPost("/", CreateItem);
inventoryItems.MapPut("/{id}", UpdateItem);
inventoryItems.MapDelete("/{id}", DeleteItem);

// Get a list of all items
async Task<ActionResult<List<Item>>> GetAllItems()
{
    var items = await itemCollection.Find(_ => true).ToListAsync();
    return items;
}

// Get a list of all in stock items
async Task<ActionResult<IEnumerable<Item>>> GetInStockItems()
{
    var filter = Builders<Item>.Filter
        .Eq(r => r.InStock, true);
    var items = await itemCollection.Find(filter).ToListAsync();

    return items;
}

// Get a specific item (based on an item id)
async Task<ActionResult<Item>> GetItem(string id)
{
    // .Eq(r => r.Id, id);
    var filter = Builders<Item>.Filter
        .Eq(r => r.Id, ObjectId.Parse(id));
    var item = await itemCollection.Find(filter).FirstOrDefaultAsync();
    return item;
}

// Create a new item
async Task<IResult> CreateItem(Item item)
{
    await itemCollection.InsertOneAsync(item);
    return TypedResults.Created($"/inventoryItems/{item.Id}", item);
}

// Update the size of an item
async Task<IResult> UpdateItem(string id, Item item)
{
    var retData = await itemCollection.FindOneAndUpdateAsync(
        t => t.Id == ObjectId.Parse(id),
        Builders<Item>.Update
            .Set(t => t.Size, item.Size));

    if (retData == null)
    {
        return TypedResults.NotFound();
    }
    return TypedResults.NoContent();
}

// Delete an item from the system
async Task<IResult> DeleteItem(string id)
{
    // var result = await itemCollection.DeleteOneAsync(t => t.Id == id);
    var result = await itemCollection.DeleteOneAsync(t => t.Id == ObjectId.Parse(id));
    if (result.DeletedCount == 0)
    {
        return TypedResults.NotFound();
    }
    return TypedResults.NoContent();
}

// Start the app
app.Run();
