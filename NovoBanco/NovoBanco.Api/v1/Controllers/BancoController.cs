using Microsoft.AspNetCore.Mvc;
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
        public BancoController()
        {

        }

        /// <summary>
        /// Método Responsável para retornar todos os bancos
        /// </summary>
        /// <returns></returns>
        [HttpGet("BuscarBancos")]
        public IActionResult Get()
        {
            return Ok("Lista de Bancos");
        }
    }
}
