

using OrderManagement.Infra;

namespace OrderManagement.Application.invoice
{
    public class InvoiceServices : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceServices(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }


        public List<InvoiceDto> GetInvoices()
        {

            var list = _invoiceRepository.GetInvoices();
            List<InvoiceDto> listRetdurn = new List<InvoiceDto>();

            return listRetdurn;

        }

        
    }
}
