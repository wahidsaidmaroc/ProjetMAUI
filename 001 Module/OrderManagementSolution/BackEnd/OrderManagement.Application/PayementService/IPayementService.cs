using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Application.PayementService
{
    public interface IPayementService
    {
        PayementDto AddPayement(PayementDto payementDto);
        bool DeletePayement(int id);
        PayementDto? GetPayement(int id);
        List<PayementDto> GetPayements();
        bool UpdatePayement(int id, PayementDto payementDto);
    }
}
