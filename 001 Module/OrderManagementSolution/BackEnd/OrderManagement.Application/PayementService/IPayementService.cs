using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Application.PayementService
{
    public interface IPayementService
    {
        List<PayementDto> GetPayements();
    }
}
