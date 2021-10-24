using NovoBanco.Aplicacao.Web.ComnunicacaoViaHttp;
using NovoBanco.Aplicacao.Web.GestaoDeBancos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoBanco.Aplicacao.Web.GestaoDeBancos
{
    public class ServicoDeGestaoDeBancos : IServicoDeGestaoDeBancos
    {
        private readonly string _urlDaApi;
        private readonly IServicoDeComunicacaoViaHttp _servicoHttp;

        public ServicoDeGestaoDeBancos(string urlDaApi, IServicoDeComunicacaoViaHttp servicoHttp)
        {
            this._urlDaApi = urlDaApi;
            _servicoHttp = servicoHttp;
        }

        public async Task<List<ModeloDeBancoDaLista>> BuscarBancos()
        {
            try
            {
                var lista = new List<ModeloDeBancoDaLista>();
                var retorno = await this._servicoHttp.Get<List<Banco>>(new Uri($"{this._urlDaApi}/Banco/BuscarBancos"), null);
                retorno.ToList().ForEach(a => lista.Add(new ModeloDeBancoDaLista(a)));
                return lista;
            }
            catch (InvalidOperationException)
            {
                throw new ExcecaoDeAplicacao("O serviço não está disponível.");
            }
        }

        public async Task<ModeloDeListaDeBancos> BuscarListaDeBancos()
        {
            try
            {
                var lista = new List<ModeloDeBancoDaLista>();
                var retorno = await this._servicoHttp.Get<List<Banco>>(new Uri($"{this._urlDaApi}/Banco/BuscarBancos"), null);
                return new ModeloDeListaDeBancos(retorno, retorno.Count);
            }
            catch (InvalidOperationException)
            {
                throw new ExcecaoDeAplicacao("O serviço não está disponível.");
            }
        }

    }
}
