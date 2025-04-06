using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventumCaez_API_EN;

namespace AdventumCaez_API_DAL.interfaces
{
    public interface IPaymentTypes
    {
        Task<List<PaymentType>> GetAllPaymentType();
        Task<List<PaymentType>> GetPaymentTypeById(int id);
    }
}