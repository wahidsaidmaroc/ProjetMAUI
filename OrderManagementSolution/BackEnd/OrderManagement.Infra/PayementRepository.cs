using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Infra
{
    public class PayementRepository : IPayementRepository
    {
        private AppMyDbContext _appMyDbContext; 

        public PayementRepository(AppMyDbContext appMyDbContext)
        {
            _appMyDbContext = appMyDbContext;
        }

        public Payement AddPayement(Payement payement)
        {
            _appMyDbContext.Payements.Add(payement);
            _appMyDbContext.SaveChanges();

            payement.PayementNbr = payement.Id;
            _appMyDbContext.SaveChanges();

            return payement;
        }

        public bool Delete(int id)
        {
            var existing = _appMyDbContext.Payements.Find(id);

            if (existing == null)
            {
                return false;
            }

            _appMyDbContext.Payements.Remove(existing);
            _appMyDbContext.SaveChanges();

            return true;
        }

        public Payement? Get(int id)
        {
            return _appMyDbContext.Payements.Find(id);
        }

        public IList<Payement> GetPayements() => _appMyDbContext.Payements.ToList();

        public bool Update(Payement payement)
        {
            var existing = _appMyDbContext.Payements.Find(payement.Id);

            if (existing == null)
            {
                return false;
            }

            existing.PayementNbr = payement.PayementNbr;
            existing.PayementDate = payement.PayementDate;
            existing.Montant = payement.Montant;
            existing.IsActive = payement.IsActive;
            existing.UpdatedAt = DateTime.UtcNow;

            _appMyDbContext.SaveChanges();

            return true;
        }
    }
}
