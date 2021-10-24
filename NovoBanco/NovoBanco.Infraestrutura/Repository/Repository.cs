using Microsoft.EntityFrameworkCore;
using NovoBanco.Dominio.Entidades;
using NovoBanco.Dominio.Repositories;
using NovoBanco.Infraestrutura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoBanco.Infraestrutura.Repository
{
    //public class Repository : IRepository
    public class Repository<T> : IRepository<T> where T : Entidade
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public T BuscarPorId(int id)
        {
            return this._context.Set<T>().Find(id);
        }

        public virtual async Task Inserir(T item)
        {
            await _context.Set<T>().AddAsync(item);
        }

        public void Deletar(T item)
        {
            _context.Remove(item);
        }
        
        public IEnumerable<T> Listar()
        {
            return this._context.Set<T>().ToList();
        }

        public void Persistir()
        {
            this._context.SaveChanges();
        }
    }
}
