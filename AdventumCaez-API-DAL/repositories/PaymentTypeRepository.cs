using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventumCaez_API_DAL.interfaces.PaymentTypes;
using AdventumCaez_API_EN;
using Microsoft.EntityFrameworkCore;

namespace AdventumCaez_API_DAL.repositories
{
    public class PaymentTypeRepository : IPaymentType
    {
        private readonly ApplicationDbContext _appDBContext;

        public PaymentTypeRepository (ApplicationDbContext context){
            _appDBContext = context;
        }

        /// <summary>
        /// Metodo para traer todos los tipos de pagos, usando EF con SP
        /// </summary>
        /// <returns></returns> <summary>
        public async Task<List<PaymentType>> GetAllPaymentTypesAsync(){
            return await _appDBContext.PaymentTypes
                .FromSqlRaw("EXEC SP_GetAllTipoPago")
                .ToListAsync();
        }

        public async Task<PaymentType?> GetPaymentTypesByIdAsync(int id)
        {
            var result = await _appDBContext.PaymentTypes
                .FromSqlInterpolated($"EXEC SP_GetTipoPagoById @Id = {id}")
                .ToListAsync();

            return result.FirstOrDefault();
        }

        //metdo con full EF
        public async Task<PaymentType> CreatePaymentTypeAsync(PaymentType paymentType)
        {
            if (paymentType == null)
                throw new ArgumentNullException(nameof(paymentType));

            // await _appDBContext.PaymentTypes.AddAsync(paymentType);
            await _appDBContext.PaymentTypes.AddAsync(paymentType);
            await _appDBContext.SaveChangesAsync();
            return paymentType;
        }

        public async Task<PaymentType?> UpdatePaymentTypeAsync(PaymentType paymentType)
        {
            if (paymentType == null)
                throw new ArgumentNullException(nameof(paymentType));

            var existingPaymentType = await _appDBContext.PaymentTypes.FindAsync(paymentType.Id);

            if (existingPaymentType == null)
                return null;

            existingPaymentType.Name = paymentType.Name;

            _appDBContext.PaymentTypes.Update(existingPaymentType);
            await _appDBContext.SaveChangesAsync();

            return existingPaymentType;
        }

        public async Task<bool> DeletePaymentTypeAsync(int id)
        {
            var paymentType = await _appDBContext.PaymentTypes.FindAsync(id);

            if (paymentType == null)
                return false;

            _appDBContext.PaymentTypes.Remove(paymentType);
            await _appDBContext.SaveChangesAsync();
            return true;
        }

    }
}