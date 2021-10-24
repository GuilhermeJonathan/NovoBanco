using NovoBanco.Aplicacao.GestaoDeBancos.Modelos;
using NovoBanco.Aplicacao.Shared;
using NovoBanco.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovoBanco.Aplicacao.GestaoDeBancos
{
    public class ServicoDeGestaoDeBancos : IServicoDeGestaoDeBancos
    {
        private readonly IServicoExternoDePersistencia _servicoExternoDePersistencia;

        public ServicoDeGestaoDeBancos(IServicoExternoDePersistencia servicoExternoDePersistencia)
        {
            this._servicoExternoDePersistencia = servicoExternoDePersistencia;
        }

        public BaseModel<List<ModeloDeBancoDaLista>> ListarTodosBancos()
        {
            try
            {
                var bancos = this._servicoExternoDePersistencia.RepositorioDeBancos.ListarTodosBancos();
                var modelo = new List<ModeloDeBancoDaLista>();

                bancos.ToList().ForEach(a => modelo.Add(new ModeloDeBancoDaLista(a)));
                if (bancos == null)
                    return new BaseModel<List<ModeloDeBancoDaLista>>(sucesso: false, mensagem: EnumMensagens.DadosNaoEncontrados);

                return new BaseModel<List<ModeloDeBancoDaLista>>(sucesso: true, mensagem: EnumMensagens.RealizadaComSucesso, dados: modelo);
            }
            catch (Exception ex)
            {
                return new BaseModel<List<ModeloDeBancoDaLista>>(sucesso: false, mensagem: EnumMensagens.ErroInterno);
            }
        }
    }
}
