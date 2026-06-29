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

        public IList<Payement> GetPayements() => _appMyDbContext.Payements.ToList();
    }
}
