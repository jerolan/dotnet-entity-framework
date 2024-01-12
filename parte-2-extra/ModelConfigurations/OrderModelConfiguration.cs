using Cf.Dotnet.EntityFramework.Parte2Extra.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cf.Dotnet.EntityFramework.Parte2Extra.ModelConfigurations;

/// <summary>
/// Clase de configuración para la entidad Order, que implementa la interfaz IEntityTypeConfiguration.
/// Esta configuración personaliza cómo Entity Framework mapea la entidad Order a la base de datos.
/// </summary>
public class OrderModelConfiguration : IEntityTypeConfiguration<Order>
{
    /// <summary>
    /// Configura la entidad Order.
    /// </summary>
    /// <param name="builder">Proporciona una API fluida para configurar la entidad Order.</param>
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // Configuración de una propiedad shadow llamada 'Version'.
        // Esta propiedad no está definida en la clase de modelo Order, pero EF la maneja directamente en la base de datos.
        builder.Property<byte[]>("Version")
            // Define la propiedad 'Version' como una versión de fila (row version).
            // Esto se utiliza para implementar un mecanismo de control de concurrencia optimista.
            // Cada vez que se actualiza un registro de Order, la versión de fila se incrementa automáticamente.
            // Esto permite a EF detectar y prevenir conflictos de concurrencia cuando se actualizan los registros.
            .IsRowVersion();
    }
}
