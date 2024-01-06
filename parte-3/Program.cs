using Cf.Dotnet.EntityFramework.Parte3;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Nombre constante para la base de datos en memoria.
const string databaseName = "MyDatabaseName";

builder.Services.AddRazorPages();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite($"Data Source={databaseName}"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();