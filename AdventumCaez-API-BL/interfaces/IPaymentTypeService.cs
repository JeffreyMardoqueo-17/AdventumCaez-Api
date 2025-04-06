using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventumCaez_API_EN;

namespace AdventumCaez_API_BL.interfaces
{
    public interface IPaymentTypeService
    {
        Task<List<PaymentType>> GetAllAsync();
        Task<PaymentType?> GetByIdAsync(int id);
        Task<PaymentType> CreateAsync(PaymentType entity);
        Task<PaymentType?> UpdateAsync(PaymentType entity);
        Task<bool> DeleteAsync(int id);
    }
}