using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using VendasWebMvc.Servicos.Excecoes;

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

        public Vendedor FindById(int id)
        {
            return _context.Vendedor.Include(obj=>obj.Departamento).FirstOrDefault(obj => obj.Id == id);

        }

        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Vendedor obj)
        {
            if (!_context.Vendedor.Any(x => x.Id==obj.Id))
            {
                throw new NotFoundException("Id não encontrado");

            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();

            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }




        }
    }
}
