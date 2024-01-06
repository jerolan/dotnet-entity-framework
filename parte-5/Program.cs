using Cf.Dotnet.EntityFramework.Parte5;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Nombre constante para la base de datos en memoria.
const string databaseName = "MyDatabaseName";

builder.Services.AddRazorPages();

builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseSqlServer($"Data Source=localhost,1433;User ID=sa;Password=Passw@rd;Database={databaseName};Encrypt=False"));

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