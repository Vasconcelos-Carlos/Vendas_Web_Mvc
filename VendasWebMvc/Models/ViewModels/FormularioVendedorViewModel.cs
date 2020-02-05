using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMvc.Models.ViewModels
{
    public class FormularioVendedorViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
