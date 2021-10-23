using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovoBanco.Dominio.Repositories
{
    public interface IRepository
    {
        void Add<T>(T item) where T : class;
        void Update<T>(T item) where T : class;
        void Delete<T>(T item) where T : class;
        bool SaveChanges();
    }
}
