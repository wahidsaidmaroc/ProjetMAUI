using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Infra
{
    public interface IPayementRepository
    {
        public Payement AddPayement(Payement payement);
        public bool Delete(int id);
        public Payement? Get(int id);
        public IList<Payement> GetPayements();
        public bool Update(Payement payement);
    }
}
