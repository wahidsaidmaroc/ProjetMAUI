

namespace OrderManagement.Domain.Entities;

public class Product : BaseEntity
{
    public string? ProdCode { get; set; }
    public string ProdName { get; set; } = string.Empty;
    public string? ProdDescription { get; set; }
    public decimal UnitPrice { get; set; }

}
