using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infra
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private AppMyDbContext _appMyDbContext;

        public InvoiceRepository(AppMyDbContext appMyDbContext)
        {
            _appMyDbContext = appMyDbContext;
        }

        void Add (Invoice invoice)
        {
            
        }

        void Update(Invoice invoice)
        {
            _appMyDbContext.Update<Invoice>(invoice);
            _appMyDbContext.SaveChanges();
        }
        Invoice? Get(int id)
        {
            return _appMyDbContext.Find<Invoice>(id);
        }

        

 
        public IList<Invoice> GetInvoices() => _appMyDbContext.Invoices.ToList();
    }
}
