

namespace OrderManagement.Application;

record ProductAdmin { }


public record ProductDto { public int Cle; public string Description; public decimal Prix; }

public record InvoiceDto { public int KeyInvoice; public DateTime DtInvoice; public decimal Mnt; }
