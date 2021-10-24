using Microsoft.AspNetCore.Mvc;
using NovoBanco.Aplicacao.Web.GestaoDeBancos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoBanco.Web.Controllers
{
    public class BancoController : Controller
    {
        private readonly IServicoDeGestaoDeBancos _servicoDeGestaoDeBancos;

        public BancoController(IServicoDeGestaoDeBancos servicoDeGestaoDeBancos)
        {
            _servicoDeGestaoDeBancos = servicoDeGestaoDeBancos;

        }

        public async Task<IActionResult> Index()
        {
            var lista = await _servicoDeGestaoDeBancos.BuscarListaDeBancos();
            return View(lista);
        }

    }
}
