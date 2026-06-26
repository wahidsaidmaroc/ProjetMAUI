namespace OrderManagement.Domain.Entities;

public class Order : BaseEntity
{
    public int OrderNbr { get; set; }
    public DateTime OrderDate { get; set; }
    public Decimal Montant { get; set; }
}

public class OrderItems : BaseEntity
{
    public int ProductId { get; set; }
    public int Qnt { get; set; }
    public int OrderId { get; set; }
}
