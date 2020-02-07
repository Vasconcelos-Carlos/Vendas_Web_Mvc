using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;

namespace VendasWebMvc.Servicos
{
    public class ServicoRegistroVendas
    {
        private readonly VendasWebMvcContext _context;

        public ServicoRegistroVendas(VendasWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroVendas>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.RegistroVenda select obj;
            if (minDate.HasValue)
            {
               resultado = resultado.Where(x => x.Data >= minDate.Value);

            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= maxDate.Value);

            }
            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .ToListAsync();

        }
    }
}
