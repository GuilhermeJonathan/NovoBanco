using Microsoft.AspNetCore.Mvc;
using NovoBanco.Aplicacao.GestaoDeBancos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoBanco.Api.v1.Controllers
{
    /// <summary>
    /// BancoController
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IServicoDeGestaoDeBancos _servicoDeGestaoDeBancos;

        public BancoController(IServicoDeGestaoDeBancos servicoDeGestaoDeBancos)
        {
            this._servicoDeGestaoDeBancos = servicoDeGestaoDeBancos;
        }

        /// <summary>
        /// Método Responsável para retornar todos os bancos
        /// </summary>
        /// <returns></returns>
        [HttpGet("BuscarBancos")]
        public IActionResult Get()
        {
            return Ok(_servicoDeGestaoDeBancos.ListarTodosBancos());
        }
    }
}
