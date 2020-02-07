using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace VendasWebMvc.Servicos
{
    public class ServicoDepartamento
    {
        private readonly VendasWebMvcContext _context;

        public ServicoDepartamento(VendasWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }



    }
}
