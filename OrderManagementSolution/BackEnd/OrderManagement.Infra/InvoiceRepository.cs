using OrderManagement.Domain.Entities;

namespace OrderManagement.Infra
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppMyDbContext _appMyDbContext;

        public InvoiceRepository(AppMyDbContext appMyDbContext)
        {
            _appMyDbContext = appMyDbContext;
        }

        public Invoice AddInvoice(Invoice invoice)
        {
            _appMyDbContext.Invoices.Add(invoice);
            _appMyDbContext.SaveChanges();

            invoice.InvoiceId = invoice.Id;
            _appMyDbContext.SaveChanges();

            return invoice;
        }

        public bool Delete(int id)
        {
            var existing = _appMyDbContext.Invoices.Find(id);

            if (existing == null)
            {
                return false;
            }

            _appMyDbContext.Invoices.Remove(existing);
            _appMyDbContext.SaveChanges();

            return true;
        }

        public Invoice? Get(int id)
        {
            return _appMyDbContext.Invoices.Find(id);
        }

        public IList<Invoice> GetInvoices() => _appMyDbContext.Invoices.ToList();

        public bool Update(Invoice invoice)
        {
            var existing = _appMyDbContext.Invoices.Find(invoice.Id);

            if (existing == null)
            {
                return false;
            }

            existing.InvoiceId = invoice.InvoiceId;
            existing.DateInvoice = invoice.DateInvoice;
            existing.Montant = invoice.Montant;
            existing.IsActive = invoice.IsActive;
            existing.UpdatedAt = DateTime.UtcNow;

            _appMyDbContext.SaveChanges();

            return true;
        }
    }
}
