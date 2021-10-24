using Microsoft.AspNetCore.Mvc;
using NovoBanco.Aplicacao.Web;
using NovoBanco.Aplicacao.Web.GestaoDeBancos;
using NovoBanco.Aplicacao.Web.GestaoDeBancos.Modelos;
using NovoBanco.Aplicacao.Web.GestaoDeContas;
using NovoBanco.Aplicacao.Web.GestaoDeContas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoBanco.Web.Controllers
{
    public class ContaController : Controller
    {
        [TempData]
        public string MensagemDeSucesso { get; set; }
        [TempData]
        public string MensagemDeErro { get; set; }
        private readonly IServicoDeGestaoDeContas _servicoDeGestaoDeContas;
        private readonly IServicoDeGestaoDeBancos _servicoDeGestaoDeBancos;

        public ContaController(IServicoDeGestaoDeContas servicoDeGestaoDeContas,
            IServicoDeGestaoDeBancos servicoDeGestaoDeBancos)
        {
            _servicoDeGestaoDeContas = servicoDeGestaoDeContas;
            _servicoDeGestaoDeBancos = servicoDeGestaoDeBancos;
        }

        public async Task<IActionResult> Index(ModeloDeFiltroDeContasBancarias filtro)
        {
            var lista = await _servicoDeGestaoDeContas.BuscarContasPorFiltro(filtro);
            return View(lista);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var retorno = await _servicoDeGestaoDeContas.BuscarContaPorId(id);
            var bancos = await _servicoDeGestaoDeBancos.BuscarBancos();

            retorno.Bancos = Util.DaClasseComOpcaoPadrao<ModeloDeBancoDaLista>(nameof(ModeloDeBancoDaLista.Nome), nameof(ModeloDeBancoDaLista.Id),
                   () => bancos);

            return View(retorno);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ModeloDeEdicaoDeContaBancaria modelo)
        {
            var retorno = await _servicoDeGestaoDeContas.SalvarConta(modelo);

            if (retorno != null)
                MensagemDeSucesso = "Conta salva com sucesso.";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            var modelo = new ModeloDeCadastroDeContaBancaria();
            var bancos = await _servicoDeGestaoDeBancos.BuscarBancos();
            modelo.Bancos = Util.DaClasseComOpcaoPadrao<ModeloDeBancoDaLista>(nameof(ModeloDeBancoDaLista.Nome), nameof(ModeloDeBancoDaLista.Id),
                   () => bancos);

            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(ModeloDeCadastroDeContaBancaria modelo)
        {
            var retorno = await _servicoDeGestaoDeContas.CadastrarConta(modelo);

            if (retorno == null)
                MensagemDeErro = "Não foi possível realizar cadastro.";

            MensagemDeSucesso = "Conta cadastrada com sucesso.";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> AtivarDesativarConta(int id, int ativo)
        {
            var modelo = await this._servicoDeGestaoDeContas.AtivarDesativarConta(id, ativo);
            return Content(modelo);
        }

        [HttpGet]
        public async Task<IActionResult> ExcluirConta(int id)
        {
            var retorno = await this._servicoDeGestaoDeContas.ExcluirConta(id);
            MensagemDeSucesso = retorno;
            return RedirectToAction(nameof(Index));
        }
    }
}
