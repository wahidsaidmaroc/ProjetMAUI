using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Infra
{
    public interface IPayementRepository
    {
        public IList<Payement> GetPayements();
    }
}
