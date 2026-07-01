


using OrderManagement.Application;

public interface IInvoiceService
{
    InvoiceDto AddInvoice(InvoiceDto invoiceDto);
    bool DeleteInvoice(int id);
    InvoiceDto? GetInvoice(int id);
    List<InvoiceDto> GetInvoices();
    bool UpdateInvoice(int id, InvoiceDto invoiceDto);
}
