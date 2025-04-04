using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventumCaez_API_DAL;

namespace AdventumCaez_API_BL
{
    public interface IDataService
    {
        // Métodos que la UI pueda consumir, por ejemplo:
        Task<List<string>> GetSomeDataAsync();
    }

    public class DataService : IDataService
    {
        private readonly ApplicationDbContext _context;

        // Inyectamos el DbContext en el constructor
        public DataService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método ejemplo que simplemente devuelve algo (puedes modificarlo según tus necesidades)
        public async Task<List<string>> GetSomeDataAsync()
        {
            // Lógica para obtener datos de la base de datos (aunque aún no tengas entidades)
            return await Task.FromResult(new List<string> { "Data1", "Data2", "Data3" });
        }
    }
}