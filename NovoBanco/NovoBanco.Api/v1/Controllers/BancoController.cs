using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NovoBanco.Api.v1.Dtos;
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
        private readonly IMapper _mapper;

        public BancoController(IServicoDeGestaoDeBancos servicoDeGestaoDeBancos, IMapper mapper)
        {
            this._servicoDeGestaoDeBancos = servicoDeGestaoDeBancos;
            this._mapper = mapper;
        }

        /// <summary>
        /// Método Responsável para retornar todos os bancos
        /// </summary>
        /// <returns></returns>
        [HttpGet("BuscarBancos")]
        public IActionResult Get()
        {
            var resultado = this._servicoDeGestaoDeBancos.ListarTodosBancos();

            if (resultado.Sucesso)
                return Ok(_mapper.Map<IEnumerable<BancoDto>>(resultado.Dados));

            return BadRequest(resultado.Mensagem);
        }
    }
}
