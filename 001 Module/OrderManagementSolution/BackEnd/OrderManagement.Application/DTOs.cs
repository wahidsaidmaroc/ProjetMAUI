

namespace OrderManagement.Application;

record ProductAdmin { }
record CategoryAdmin { }

public record ProductDto
{
	public int Cle { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
	public decimal Prix { get; set; }
}

public record CategoryDto
{
	public int Cle { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
}

public record InvoiceDto
{
	public int KeyInvoice { get; set; }
	public DateTime DtInvoice { get; set; }
	public decimal Mnt { get; set; }
}


public record PayementDto
{
	public int PaymentNbr { get; set; }
	public string DatePayement { get; set; } = string.Empty;
	public decimal Montant { get; set; }
}

public record OrderDto
{
	public int Cle { get; set; }
	public int OrderNbr { get; set; }
	public DateTime OrderDate { get; set; }
	public decimal Montant { get; set; }
}

public record OrderItemDto
{
	public int Cle { get; set; }
	public int ProductId { get; set; }
	public int Qnt { get; set; }
	public int OrderId { get; set; }
}


