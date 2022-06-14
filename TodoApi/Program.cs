using Customers.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Todos") ?? "Data Source=Todos.db";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlServer<CustomerContext>(connectionString);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = builder.Environment.ApplicationName, Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{builder.Environment.ApplicationName} v1"));
}

app.MapFallback(() => Results.Redirect("/swagger"));

app.MapGet("/customers", async (CustomerContext db) =>
{
    return await db.Customers.ToListAsync();
});

app.MapGet("/customers/{id}", async (CustomerContext db, int id) =>
{
    return await db.Customers.FindAsync(id) switch
    {
        Customer customer => Results.Ok(customer),
        null => Results.NotFound()
    };
});

app.MapPost("/customers", async (CustomerContext db, Customer customer) =>
{
    await db.Customers.AddAsync(customer);
    await db.SaveChangesAsync();

    return Results.Created($"/customers/{customer.Id}", customer);
});

app.MapPut("/customers/{id}", async (CustomerContext db, int id, Customer customer) =>
{
    if (id != customer.Id)
    {
        return Results.BadRequest();
    }

    if (!await db.Customers.AnyAsync(x => x.Id == id))
    {
        return Results.NotFound();
    }

    db.Update(customer);
    await db.SaveChangesAsync();

    return Results.Ok();
});

app.MapDelete("/customers/{id}", async (CustomerContext db, int id) =>
{
    var customer = await db.Customers.FindAsync(id);
    if (customer is null)
    {
        return Results.NotFound();
    }

    db.Customers.Remove(customer);
    await db.SaveChangesAsync();

    return Results.Ok();
});

app.Run();
