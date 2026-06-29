using OrderManagement.Domain.Entities;

namespace OrderManagement.Infra
{
    public interface IInvoiceRepository
    {
        public IList<Invoice> GetInvoices();
    }
}
