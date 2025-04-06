using AdventumCaez_API_BL.interfaces;
using AdventumCaez_API_DAL.interfaces.PaymentTypes;
using AdventumCaez_API_EN;

namespace AdventumCaez_API_BL.services
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IPaymentType _repo;

        public PaymentTypeService(IPaymentType repo)
        {
            _repo = repo;
        }

        public async Task<List<PaymentType>> GetAllAsync()
        {
            return await _repo.GetAllPaymentTypesAsync();
        }

        public async Task<PaymentType?> GetByIdAsync(int id)
        {
            return await _repo.GetPaymentTypesByIdAsync(id);
        }

        public async Task<PaymentType> CreateAsync(PaymentType entity)
        {
            return await _repo.CreatePaymentTypeAsync(entity);
        }

        public async Task<PaymentType?> UpdateAsync(PaymentType entity)
        {
            return await _repo.UpdatePaymentTypeAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeletePaymentTypeAsync(id);
        }
    }
}
