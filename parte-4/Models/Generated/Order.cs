namespace Cf.Dotnet.EntityFramework.Parte4.Models;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int CatalogItemId { get; set; }

    public int Quantity { get; set; }

    public virtual CatalogItem CatalogItem { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
