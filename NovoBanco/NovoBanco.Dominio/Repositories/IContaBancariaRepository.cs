using NovoBanco.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Dominio.Repositories
{
    public interface IContaBancariaRepository : IRepository<ContaBancaria>
    {
        List<ContaBancaria> ListarTodasContas();
        List<ContaBancaria> ListarContasPorFiltro(string nome);
    }
}
