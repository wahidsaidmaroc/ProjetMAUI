using OrderManagement.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.PayementService
{
    public class PayementServices : IPayementService
    {
        private readonly IPayementRepository _payementtRepository;
        public PayementServices(IPayementRepository payementtRepository)
        {
            _payementtRepository = payementtRepository;
        }

        public PayementDto AddPayement(PayementDto payementDto)
        {
            var payementDate = DateTime.Parse(payementDto.DatePayement);

            var payement = new Payement
            {
                PayementNbr = payementDto.PaymentNbr,
                PayementDate = payementDate,
                Montant = payementDto.Montant
            };

            var created = _payementtRepository.AddPayement(payement);

            return new PayementDto
            {
                PaymentNbr = created.Id,
                DatePayement = created.PayementDate.ToString("O"),
                Montant = created.Montant
            };
        }

        public bool DeletePayement(int id)
        {
            return _payementtRepository.Delete(id);
        }

        public PayementDto? GetPayement(int id)
        {
            var payement = _payementtRepository.Get(id);

            if (payement == null)
            {
                return null;
            }

            return new PayementDto
            {
                PaymentNbr = payement.Id,
                DatePayement = payement.PayementDate.ToString("O"),
                Montant = payement.Montant
            };
        }

        public List<PayementDto> GetPayements()
        {
            var list = _payementtRepository.GetPayements();
            return list
                .Select(payement => new PayementDto
                {
                    PaymentNbr = payement.Id,
                    DatePayement = payement.PayementDate.ToString("O"),
                    Montant = payement.Montant
                })
                .ToList();
        }

        public bool UpdatePayement(int id, PayementDto payementDto)
        {
            var payement = _payementtRepository.Get(id);

            if (payement == null)
            {
                return false;
            }

            payement.PayementNbr = id;
            payement.PayementDate = DateTime.Parse(payementDto.DatePayement);
            payement.Montant = payementDto.Montant;

            return _payementtRepository.Update(payement);
        }
    }
}
