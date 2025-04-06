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
    }
}