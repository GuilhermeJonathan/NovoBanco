using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NovoBanco.Api.v1.Dtos;
using NovoBanco.Aplicacao.GestaoDeContas;
using NovoBanco.Aplicacao.GestaoDeContas.Modelos;
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
        private readonly IServicoDeGestaoDeContas _servicoDeGestaoDeContas;
        private readonly IMapper _mapper;

        public ContaBancariaController(IServicoDeGestaoDeContas servicoDeGestaoDeContas, IMapper mapper)
        {
            this._servicoDeGestaoDeContas = servicoDeGestaoDeContas;
            this._mapper = mapper;
        }

        /// <summary>
        /// Método Responsável para retornar todas as contas
        /// </summary>
        /// <returns></returns>
        [HttpGet("BuscarContas")]
        public IActionResult BuscarContas()
        {
            var resultado = this._servicoDeGestaoDeContas.ListarTodasContas();

            if (resultado.Sucesso)
                return Ok(_mapper.Map<IEnumerable<ContaBancariaDto>>(resultado.Dados));

            return BadRequest(resultado.Mensagem);
        }

        /// <summary>
        /// Método Responsável para retornar todas as contas
        /// </summary>
        /// /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorNome/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            var resultado = this._servicoDeGestaoDeContas.BuscarPorNome(nome);

            if (resultado.Sucesso)
                return Ok(_mapper.Map<IEnumerable<ContaBancariaDto>>(resultado.Dados));

            return BadRequest(resultado.Mensagem);
        }

        /// <summary>
        /// Método responsável por realizar busca de Conta Bancária por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var resultado = this._servicoDeGestaoDeContas.BuscarPorId(id);

            if (resultado.Sucesso)
                return Ok(_mapper.Map<ContaBancariaDto>(resultado.Dados));

            return BadRequest(resultado.Mensagem);
        }

        /// <summary>
        /// Método responsável para cadastrar uma Fruta
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CadastrarConta")]
        public async Task<IActionResult> CadastrarConta(ContaBancariaRegistroDto model)
        {
            var modeloDeCadastro = _mapper.Map<ModeloDeCadastroDeContaBancaria>(model);
            var resultado = await this._servicoDeGestaoDeContas.CadastrarConta(modeloDeCadastro);
            var retornoConta = _mapper.Map<ContaBancariaDto>(resultado.Dados);

            if (resultado.Sucesso)
                return Ok(resultado.Mensagem);
            
            return BadRequest(resultado.Mensagem);
        }

        /// <summary>
        /// Método responsável para editar uma Conta Bancária
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("EditarConta/{id}")]
        public IActionResult EditarConta(int? id, ContaBancariaEdicaoDto model)
        {
            if (id.HasValue)
                model.Id = id.Value;

            var modeloDeEdicao = _mapper.Map<ModeloDeEdicaoDeContaBancaria>(model);
            var resultado = this._servicoDeGestaoDeContas.EditarConta(modeloDeEdicao);
            
            if (resultado.Sucesso)
                return Ok(resultado.Mensagem);

            return BadRequest(resultado.Mensagem);
        }

        /// <summary>
        /// Método responsável para Ativar ou Desativar Conta Bancária
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("AtivarDesativarConta/{id}")]
        public IActionResult AtivarDesativarConta(int? id, ContaBancariaAtivacaoDto model)
        {
            if (id.HasValue)
                model.Id = id.Value;

            var modeloDeEdicao = _mapper.Map<ModeloDeEdicaoDeContaBancaria>(model);
            var resultado = this._servicoDeGestaoDeContas.AtivarDesativarConta(modeloDeEdicao);

            if (resultado.Sucesso)
                return Ok(resultado.Mensagem);

            return BadRequest(resultado.Mensagem);
        }

        /// <summary>
        /// Método responsável para excluir uma Conta Bancária
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("ExcluirConta/{id}")]
        public IActionResult ExcluirConta(int? id)
        {
            var modeloDeEdicao = _mapper.Map<ModeloDeEdicaoDeContaBancaria>(new ContaBancariaExclusaoDto() { Id = id.Value});
            var resultado = this._servicoDeGestaoDeContas.ExcluirConta(modeloDeEdicao);

            if (resultado.Sucesso)
                return Ok(resultado.Mensagem);

            return BadRequest(resultado.Mensagem);
        }
    }
}
