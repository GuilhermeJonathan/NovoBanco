using NovoBanco.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Dominio.Repositories
{
    public interface IBancoRepository : IRepository<Banco>
    {
        Banco PegarPorId(int id);
        List<Banco> ListarTodosBancos();
    }
}
