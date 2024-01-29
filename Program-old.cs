// using Microsoft.EntityFrameworkCore;

// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<ItemDb>(opt => opt.UseInMemoryDatabase("ItemInventory"));
// builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// var app = builder.Build();

// app.MapGet("/", () =>
// {
//     return "Hello World!";
// });

// var inventoryItems = app.MapGroup("inventoryItems");

// inventoryItems.MapGet("/", GetAllItems);
// inventoryItems.MapGet("/inStock", GetInStockItems);
// inventoryItems.MapGet("/{id}", GetItem);
// inventoryItems.MapPost("/", CreateItem);
// inventoryItems.MapPut("/{id}", UpdateItem);
// inventoryItems.MapDelete("/{id}", DeleteItem);

// static async Task<IResult> GetAllItems(ItemDb db)
// {
//     return TypedResults.Ok(await db.Items.ToArrayAsync());
// }

// static async Task<IResult> GetInStockItems(ItemDb db)
// {
//     return TypedResults.Ok(await db.Items.Where(t => t.InStock).ToListAsync());
// }

// static async Task<IResult> GetItem(int id, ItemDb db)
// {
//     return await db.Items.FindAsync(id)
//         is Item item
//             ? TypedResults.Ok(item)
//             : TypedResults.NotFound();
// }

// static async Task<IResult> CreateItem(Item item, ItemDb db)
// {
//     db.Items.Add(item);
//     await db.SaveChangesAsync();

//     return TypedResults.Created($"/inventoryItems/{item.Id}", item);
// }

// static async Task<IResult> UpdateItem(int id, Item inputItem, ItemDb db)
// {
//     var item = await db.Items.FindAsync(id);

//     if (item is null) return TypedResults.NotFound();

//     item.Name = inputItem.Name;
//     item.InStock = inputItem.InStock;

//     await db.SaveChangesAsync();

//     return TypedResults.NoContent();
// }

// static async Task<IResult> DeleteItem(int id, ItemDb db)
// {
//     if (await db.Items.FindAsync(id) is Item item)
//     {
//         db.Items.Remove(item);
//         await db.SaveChangesAsync();
//         return TypedResults.NoContent();
//     }

//     return TypedResults.NotFound();
// }

// app.Run();
