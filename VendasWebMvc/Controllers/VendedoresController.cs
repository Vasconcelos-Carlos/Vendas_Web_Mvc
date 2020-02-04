using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Models;
using VendasWebMvc.Servicos;

namespace VendasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoVendedor _servicoVendedor;

        public VendedoresController(ServicoVendedor servicoVendedor)
        {
            _servicoVendedor = servicoVendedor;
        }

        public IActionResult Index()
        {
            var listaVendedores = _servicoVendedor.FindAll();
            return View(listaVendedores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _servicoVendedor.Iserir(vendedor);
            return RedirectToAction(nameof(Index));
        }

    }
}