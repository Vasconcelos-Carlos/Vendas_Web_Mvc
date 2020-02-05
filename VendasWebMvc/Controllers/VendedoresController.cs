﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Models;
using VendasWebMvc.Models.ViewModels;
using VendasWebMvc.Servicos;

namespace VendasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoVendedor _servicoVendedor;
        private readonly ServicoDepartamento _servicoDepartamento;

        public VendedoresController(ServicoVendedor servicoVendedor, ServicoDepartamento servicoDepartamento)
        {
            _servicoVendedor = servicoVendedor;
            _servicoDepartamento = servicoDepartamento;

        }

        public IActionResult Index()
        {
            var listaVendedores = _servicoVendedor.FindAll();
            return View(listaVendedores);

        }

        public IActionResult Create()
        {
            var departamentos = _servicoDepartamento.FindAll();
            var viewModel = new FormularioVendedorViewModel { Departamentos = departamentos };
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _servicoVendedor.Iserir(vendedor);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            var obj = _servicoVendedor.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();

            }

            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _servicoVendedor.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            var obj = _servicoVendedor.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();

            }

            return View(obj);
        }
    }
}