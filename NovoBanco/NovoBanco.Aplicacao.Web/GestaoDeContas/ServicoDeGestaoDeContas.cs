using NovoBanco.Aplicacao.Shared;
using NovoBanco.Aplicacao.Web.ComnunicacaoViaHttp;
using NovoBanco.Aplicacao.Web.GestaoDeContas.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovoBanco.Aplicacao.Web.GestaoDeContas
{
    public class ServicoDeGestaoDeContas : IServicoDeGestaoDeContas
    {
        private readonly string _urlDaApi;
        private readonly IServicoDeComunicacaoViaHttp _servicoHttp;

        public ServicoDeGestaoDeContas(string urlDaApi, IServicoDeComunicacaoViaHttp servicoHttp)
        {
            this._urlDaApi = urlDaApi;
            _servicoHttp = servicoHttp;
        }

        public async Task<ModeloDeListaDeContasBancarias> BuscarContasPorFiltro(ModeloDeFiltroDeContasBancarias filtro)
        {
            try
            {
                if (String.IsNullOrEmpty(filtro.Nome))
                {
                    var retorno = await this._servicoHttp.Get<List<ContaBancaria>>(new Uri($"{this._urlDaApi}/ContaBancaria/BuscarContas"), null);
                    return new ModeloDeListaDeContasBancarias(retorno, retorno.Count, filtro);
                }
                else
                {
                    var retorno = await this._servicoHttp.Get<List<ContaBancaria>>(new Uri($"{this._urlDaApi}/ContaBancaria/BuscarPorNome/{filtro.Nome}"), null);
                    return new ModeloDeListaDeContasBancarias(retorno, retorno.Count, filtro);
                }
            }
            catch (InvalidOperationException)
            {
                throw new ExcecaoDeAplicacao("O serviço não está disponível.");
            }
        }

        public async Task<ModeloDeEdicaoDeContaBancaria> BuscarContaPorId(int id)
        {
            try
            {
                var retorno = await this._servicoHttp.Get<ContaBancaria>(new Uri($"{this._urlDaApi}/ContaBancaria/BuscarPorId/{id}"), null);
                return new ModeloDeEdicaoDeContaBancaria(retorno);
            }
            catch (InvalidOperationException)
            {
                throw new ExcecaoDeAplicacao("O serviço não está disponível.");
            }
        }

        public async Task<ModeloDeEdicaoDeContaBancaria> SalvarConta(ModeloDeEdicaoDeContaBancaria modelo)
        {
            try
            {
                var retorno = await this._servicoHttp.PutJson<ModeloDeEdicaoDeContaBancaria, ContaBancaria>(new Uri($"{this._urlDaApi}/ContaBancaria/EditarConta/{modelo.Id}"),
                    modelo);

                return new ModeloDeEdicaoDeContaBancaria(retorno);
            }
            catch (InvalidOperationException ex)
            {
                throw new ExcecaoDeAplicacao("O serviço não está disponível.");
            }
        }

        public async Task<ModeloDeEdicaoDeContaBancaria> CadastrarConta(ModeloDeCadastroDeContaBancaria modelo)
        {
            try
            {
                var retorno = await this._servicoHttp.PostJson<ModeloDeCadastroDeContaBancaria, ContaBancaria>(new Uri($"{this._urlDaApi}/ContaBancaria/CadastrarConta"),
                    modelo);

                return new ModeloDeEdicaoDeContaBancaria(retorno);
            }
            catch (InvalidOperationException)
            {
                throw new ExcecaoDeAplicacao("O serviço não está disponível.");
            }
        }

        public async Task<string> AtivarDesativarConta(int? id, int? ativo)
        {
            try
            {
                var modelo = new ModeloDeEdicaoDeContaBancaria() { Id = id.Value, Ativo = ativo.Value };

                var retorno = await this._servicoHttp.PutJson<ModeloDeEdicaoDeContaBancaria,
                    EnumModel>(new Uri($"{this._urlDaApi}/ContaBancaria/AtivarDesativarConta/{modelo.Id}"),
                    modelo);

                return retorno.Descricao;
            }
            catch (InvalidOperationException)
            {
                throw new ExcecaoDeAplicacao("O serviço não está disponível.");
            }
        }

        public async Task<string> ExcluirConta(int? id)
        {
            try
            {
                var retorno = await this._servicoHttp.Delete<EnumModel>(new Uri($"{this._urlDaApi}/ContaBancaria/ExcluirConta/{id.Value}"));
                return retorno.Descricao;
            }
            catch (InvalidOperationException)
            {
                throw new ExcecaoDeAplicacao("O serviço não está disponível.");
            }
        }
    }
}
