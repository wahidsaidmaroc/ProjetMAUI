using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Domain.Entities
{
    public class Payement : BaseEntity
    {

        public int PayementNbr { get; set; }
        public DateTime PayementDate { get; set; }
        public Decimal Montant { get; set; }
        
    }
}
