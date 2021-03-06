using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NovoBanco.Aplicacao.Web.ComnunicacaoViaHttp
{
    public interface IServicoDeComunicacaoViaHttp
    {
        Task<T> Get<T>(Uri url, IDictionary<string, string> parametros = null,
           IDictionary<string, string> cabecalho = null);

        Task<string> Post<T>(Uri url, T dados, IDictionary<string, string> cabecalho,
            Func<object, HttpContent> montarConteudo);

        Task<TRetorno> PostJson<T, TRetorno>(Uri url, T dados, IDictionary<string, string> cabecalho = null);

        Task<TRetorno> PutJson<T, TRetorno>(Uri url, T dados, KeyValuePair<string, string> tokenDeAutorizacao = default(KeyValuePair<string, string>), IDictionary<string, string> cabecalho = null);

        Task<T> Delete<T>(Uri url, IDictionary<string, string> cabecalho = null);
    }
}
