using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;

namespace VendasWebMvc.Servicos
{
    public class ServicoVendedor
    {
        private readonly VendasWebMvcContext _context;

        public ServicoVendedor(VendasWebMvcContext context)
        {
            _context = context;
        }
        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }

        public void Iserir(Vendedor obj)
        {            
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
