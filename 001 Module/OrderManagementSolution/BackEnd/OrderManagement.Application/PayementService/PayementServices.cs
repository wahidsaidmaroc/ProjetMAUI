using OrderManagement.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Application.PayementService
{
    public class PayementServices : IPayementService
    {
        private readonly IPayementRepository _payementtRepository;
        public PayementServices(IPayementRepository payementtRepository)
        {
            _payementtRepository = payementtRepository;
        }

        public List<PayementDto> GetPayements()
        {
            var list = _payementtRepository.GetPayements();


            List<PayementDto> listRetdurn = new List<PayementDto>();

            return listRetdurn;
        }
    }
}
