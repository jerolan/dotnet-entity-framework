namespace Cf.Dotnet.EntityFramework.Parte4.Models;

/// <summary>
/// Representa una orden en el contexto del negocio.
/// </summary>
public partial class Order
{
    public decimal GetOrderTotal()
    {
        return this.CatalogItem.Price * this.Quantity;
    }
}