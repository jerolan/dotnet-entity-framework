using Cf.Dotnet.EntityFramework.Parte1;
using Cf.Dotnet.EntityFramework.Parte1.Models;
using Microsoft.EntityFrameworkCore;

// Creación de un logger para registrar la actividad del programa.
var logger = LoggerFactory
    .Create(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Debug))
    .CreateLogger<Program>();

// Nombre constante para la base de datos en memoria.
const string databaseName = "MyDatabaseName";

// Configuración de opciones para el contexto de la base de datos, utilizando una base de datos en memoria.
// Con base de datos en memoria para fines de demostración y pruebas.
var databaseOptions = new DbContextOptionsBuilder<DatabaseContext>()
    .UseInMemoryDatabase(databaseName) 
    .Options;

// Creación de una instancia del contexto de la base de datos con las opciones configuradas.
var context = new DatabaseContext(databaseOptions);
logger.LogDebug("Database {DatabaseName} created", databaseName);

// Creación y adición de un nuevo cliente al contexto.
var customer = new Customer
{
    Name = "Miguel"
};

context.Customers.Add(customer); 
context.SaveChanges();
logger.LogDebug("Customer {CustomerId} created", customer.Id);

// Creación y adición de una lista de artículos del catálogo al contexto.
var catalogItems = new List<CatalogItem>
{
    new()
    {
        Name = "Item 1", 
        Price = 10
    },
    new()
    {
        Name = "Item 2", 
        Price = 20
    }
};

context.CatalogItems.AddRange(catalogItems); 
context.SaveChanges(); 
logger.LogDebug("Catalog items {CatalogItemIds} created", string.Join(", ", catalogItems.Select(x => x.Id))); 

// Creación y adición de una orden al contexto.
var order = new Order
{
    CustomerId = customer.Id, 
    CatalogItemId = catalogItems.First().Id, 
    Quantity = 1 
};

context.Orders.Add(order); 
context.SaveChanges(); 
