using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Models;
namespace VendasWebMvc.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> Lista = new List<Departamento>();
            Lista.Add(new Departamento { Id = 1, Nome = "Eletonicos" });
            Lista.Add(new Departamento { Id = 2, Nome = "Moda" });

            return View(Lista);
        }
    }
}