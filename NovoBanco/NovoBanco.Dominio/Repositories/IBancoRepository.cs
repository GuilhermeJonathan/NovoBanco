using NovoBanco.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Dominio.Repositories
{
    public interface IBancoRepository
    {
        List<Banco> ListarTodosBancos();
    }
}
