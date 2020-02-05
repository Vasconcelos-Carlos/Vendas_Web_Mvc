using System;

namespace VendasWebMvc.Servicos.Excecoes
{
    public class DbConcurrencyException:ApplicationException
    {
        public DbConcurrencyException(string message) : base(message)
        {

        }
    }
}
