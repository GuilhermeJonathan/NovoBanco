using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoBanco.Api.v1.Controllers
{
    /// <summary>
    /// ContaBancariaController
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ContaBancariaController : ControllerBase
    {
        public ContaBancariaController()
        {

        }

        /// <summary>
        /// /Método Responsável para retornar todas as contas
        /// </summary>
        /// <returns></returns>
        [HttpGet("BuscarContas")]
        public IActionResult Get()
        {
            return Ok("Lista de Contas");
        }
    }
}
