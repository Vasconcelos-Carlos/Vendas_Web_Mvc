using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Servicos;

namespace VendasWebMvc.Controllers
{
    public class RegistroVendassController : Controller
    {
        private readonly ServicoRegistroVendas _servicoRegistroVendas;

        public RegistroVendassController(ServicoRegistroVendas servicoRegistroVendas)
        {
            _servicoRegistroVendas = servicoRegistroVendas;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscaSimples(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyy-MM-dd");
            var resultado = await _servicoRegistroVendas.FindByDateAsync(minDate, maxDate);
            return View(resultado);
        }

        public IActionResult BuscaAgrupada()
        {
            return View();
        }

    }
}