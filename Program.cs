

using Keko.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("KekoDbConnection");
builder.Services.AddDbContext<KekoDbContext>(options => 
{
    options.UseSqlServer(connection);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Keko API",
        Description = "A .NET 7 minimal API for managing ToDo items"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/tasks", async (KekoDbContext context) => {
    return await context.Tasks.ToListAsync();
});

app.MapGet("/tasks/{id}", async (KekoDbContext context, int id) => {
    return await context.Tasks.FindAsync(id) is TaskEntity task ? Results.Ok(task) : Results.NotFound();
});

app.MapPost("/tasks", async (KekoDbContext context, TaskEntity task) =>
{
    await context.AddAsync(task);
    await context.SaveChangesAsync();

    return Results.Created($"/tasks/{task.Id}", task);
});

app.Run();
