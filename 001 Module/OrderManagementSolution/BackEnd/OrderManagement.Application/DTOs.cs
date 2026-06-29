

namespace OrderManagement.Application;

record ProductAdmin { }
record CategoryAdmin { }

public record ProductDto { public int Cle; public string Description; public decimal Prix; }
public record CategoryDto { public int Cle; public string Name; public string Description; }

public record InvoiceDto { public int KeyInvoice; public DateTime DtInvoice; public decimal Mnt; }
