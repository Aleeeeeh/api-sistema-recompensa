using api_sistema_recompensas.Config;
using api_sistema_recompensas.Models.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<Context>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
);

// Add services to the container.
builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
