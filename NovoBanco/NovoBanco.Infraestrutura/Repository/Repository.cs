using Microsoft.EntityFrameworkCore;
using NovoBanco.Dominio.Repositories;
using NovoBanco.Infraestrutura.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovoBanco.Infraestrutura.Repository
{
    public abstract class Repository : IRepository
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T item) where T : class
        {
            _context.Add(item);
        }

        public void Update<T>(T item) where T : class
        {
            _context.Update(item);
        }

        public void Delete<T>(T item) where T : class
        {
            _context.Remove(item);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}
