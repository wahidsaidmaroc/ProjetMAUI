using OrderManagement.Domain.Entities;

namespace OrderManagement.Infra
{
    public interface IInvoiceRepository
    {
        public Invoice AddInvoice(Invoice invoice);
        public bool Delete(int id);
        public Invoice? Get(int id);
        public IList<Invoice> GetInvoices();
        public bool Update(Invoice invoice);
    }
}
