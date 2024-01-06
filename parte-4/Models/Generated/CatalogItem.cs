namespace Cf.Dotnet.EntityFramework.Parte4.Models;

public partial class CatalogItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}