using NovoBanco.Aplicacao.Web.GestaoDeContas.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovoBanco.Aplicacao.Web.GestaoDeContas
{
    public interface IServicoDeGestaoDeContas
    {
        Task<ModeloDeListaDeContasBancarias> BuscarContasPorFiltro(ModeloDeFiltroDeContasBancarias filtro);
        Task<ModeloDeEdicaoDeContaBancaria> BuscarContaPorId(int id);
        Task<ModeloDeEdicaoDeContaBancaria> SalvarConta(ModeloDeEdicaoDeContaBancaria modelo);
        Task<ModeloDeEdicaoDeContaBancaria> CadastrarConta(ModeloDeCadastroDeContaBancaria modelo);
        Task<string> AtivarDesativarConta(int? id, int? ativo);
        Task<string> ExcluirConta(int? id);
    }
}
