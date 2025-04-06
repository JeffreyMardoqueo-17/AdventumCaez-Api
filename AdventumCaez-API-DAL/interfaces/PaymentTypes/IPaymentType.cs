using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventumCaez_API_EN;

namespace AdventumCaez_API_DAL.interfaces.PaymentTypes
{
    public interface IPaymentType
    {
        Task<List<PaymentType>>  GetAllPaymentTypesAsync();
        Task<PaymentType?> GetPaymentTypesByIdAsync(int id);        
    }
}