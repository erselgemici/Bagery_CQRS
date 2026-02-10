using MyAcademyCQRS.Context;
using MyAcademyCQRS.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAcademyCQRS.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            // Eğer bu repository daha önce oluşturulduysa, onu geri döndür
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IGenericRepository<T>)_repositories[typeof(T)];
            }

            // Yoksa yenisini oluştur ve listeye ekle
            var repository = new GenericRepository<T>(_context);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
