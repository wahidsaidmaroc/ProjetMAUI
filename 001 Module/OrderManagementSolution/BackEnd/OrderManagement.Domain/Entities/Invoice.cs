using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Domain.Entities
{
    public class Invoice : BaseEntity
    {

        public int InvoiceId { get; set; }
        public DateTime DateInvoice { get; set; }
        public decimal Montant { get; set; }
        
    
    }
}
