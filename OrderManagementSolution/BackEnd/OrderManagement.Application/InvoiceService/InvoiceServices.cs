
using OrderManagement.Domain.Entities;
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

        public InvoiceDto AddInvoice(InvoiceDto invoiceDto)
        {
            var invoice = new Invoice
            {
                InvoiceId = invoiceDto.KeyInvoice,
                DateInvoice = invoiceDto.DtInvoice,
                Montant = invoiceDto.Mnt
            };

            var created = _invoiceRepository.AddInvoice(invoice);

            return new InvoiceDto
            {
                KeyInvoice = created.Id,
                DtInvoice = created.DateInvoice,
                Mnt = created.Montant
            };
        }

        public bool DeleteInvoice(int id)
        {
            return _invoiceRepository.Delete(id);
        }

        public InvoiceDto? GetInvoice(int id)
        {
            var invoice = _invoiceRepository.Get(id);

            if (invoice == null)
            {
                return null;
            }

            return new InvoiceDto
            {
                KeyInvoice = invoice.Id,
                DtInvoice = invoice.DateInvoice,
                Mnt = invoice.Montant
            };
        }

        public List<InvoiceDto> GetInvoices()
        {
            var list = _invoiceRepository.GetInvoices();

            return list
                .Select(invoice => new InvoiceDto
                {
                    KeyInvoice = invoice.Id,
                    DtInvoice = invoice.DateInvoice,
                    Mnt = invoice.Montant
                })
                .ToList();
        }

        public bool UpdateInvoice(int id, InvoiceDto invoiceDto)
        {
            var invoice = _invoiceRepository.Get(id);

            if (invoice == null)
            {
                return false;
            }

            invoice.InvoiceId = id;
            invoice.DateInvoice = invoiceDto.DtInvoice;
            invoice.Montant = invoiceDto.Mnt;

            return _invoiceRepository.Update(invoice);
        }
    }
}
