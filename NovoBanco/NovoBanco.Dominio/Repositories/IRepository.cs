using NovoBanco.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovoBanco.Dominio.Repositories
{
    public interface IRepository<T> where T : Entidade
    {
        T BuscarPorId(int id);
        IEnumerable<T> Listar();
        Task Inserir(T item);
        void Persistir();
    }
}
