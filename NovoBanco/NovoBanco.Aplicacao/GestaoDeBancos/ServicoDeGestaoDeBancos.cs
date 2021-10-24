using NovoBanco.Aplicacao.GestaoDeBancos.Modelos;
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

        public IList<ModeloDeBancoDaLista> ListarTodosBancos()
        {
            var bancos = this._servicoExternoDePersistencia.RepositorioDeBancos.ListarTodosBancos();
            var modelo = new List<ModeloDeBancoDaLista>();

            bancos.ToList().ForEach(a => modelo.Add(new ModeloDeBancoDaLista(a)));
            return modelo;
        }
    }
}
