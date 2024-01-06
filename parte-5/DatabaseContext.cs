using AutoBogus;
using Bogus.Extensions;
using Cf.Dotnet.EntityFramework.Parte5.Models;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte5;

/// <summary>
/// Contexto de la base de datos para la aplicación, que utiliza Entity Framework.
/// </summary>
public class DatabaseContext : DbContext
{
    /// <summary>
    /// Constructor sin parámetros para el contexto de la base de datos.
    /// </summary>
    /// <remarks>
    /// Este constructor es utilizado principalmente por frameworks y herramientas de desarrollo, como por ejemplo, para la creación de migraciones.
    /// </remarks>
    public DatabaseContext()
    {
    }

    /// <summary>
    /// Constructor que toma opciones de DbContext para configurar el contexto.
    /// </summary>
    /// <param name="options">Opciones de configuración para el contexto de la base de datos.</param>
    /// <remarks>
    /// Este constructor permite configurar el contexto con opciones específicas, como la cadena de conexión a la base de datos.
    /// </remarks>
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        const int seedItems = 10;
        var customers = new AutoFaker<Customer>()
            .RuleFor(x => x.Id, f => f.Random.Int(min: 0))
            .RuleFor(x => x.Orders, new List<Order>())
            .Generate(seedItems);
        var catalogitems = new AutoFaker<CatalogItem>()
            .RuleFor(x => x.Id, f => f.Random.Int(min: 0))
            .Generate(seedItems);
        var orders = new AutoFaker<Order>()
            .RuleFor(x => x.Id, f => f.Random.Int(min: 0))
            .RuleFor(x => x.CustomerId, f => f.PickRandom(customers.Select(c => c.Id)))
            .RuleFor(x => x.CatalogItemId, f => f.PickRandom(catalogitems.Select(c => c.Id)))
            .RuleFor(x => x.Customer, default(Customer))
            .RuleFor(x => x.CatalogItem, default(CatalogItem))
            .RuleFor(x => x.Quantity, f => f.Random.Decimal2(min: 0, max: 999999))
            .Generate(seedItems);
        modelBuilder.Entity<Customer>().HasData(customers);
        modelBuilder.Entity<CatalogItem>().HasData(catalogitems);
        modelBuilder.Entity<Order>().HasData(orders);
    }

    /// <summary>
    /// Conjunto de entidades de tipo CatalogItem en la base de datos.
    /// </summary>
    /// <value>
    /// Proporciona acceso a las operaciones CRUD para los elementos del catálogo.
    /// </value>
    public DbSet<CatalogItem> CatalogItems { get; set; } = null!; // Inicializa con null! para indicar que EF se encargará de su inicialización.

    /// <summary>
    /// Conjunto de entidades de tipo Order en la base de datos.
    /// </summary>
    /// <value>
    /// Proporciona acceso a las operaciones CRUD para las órdenes.
    /// </value>
    public DbSet<Order> Orders { get; set; } = null!; // DbSet<Order> se inicializa con null! como una convención de EF.

    /// <summary>
    /// Conjunto de entidades de tipo Customer en la base de datos.
    /// </summary>
    /// <value>
    /// Proporciona acceso a las operaciones CRUD para los clientes.
    /// </value>
    public DbSet<Customer> Customers { get; set; } = null!; // DbSet<Customer> también se inicializa con null!, delegando la inicialización a EF.
}
