using MyAcademyCQRS.Context;
using MyAcademyCQRS.DataAccess.Concrete;
using MyAcademyCQRS.Entities;
using System;

namespace MyAcademyCQRS.DesignPatterns.Observer
{
    public class DbLoggerObserver : IObserver
    {
        private readonly AppDbContext _context;

        public DbLoggerObserver(AppDbContext context)
        {
            _context = context;
        }

        public void CreateLog(string message, string section, string detail = null)
        {
            var log = new Log
            {
                Message = message,
                Section = section,
                Date = DateTime.Now,
                Detail = detail ?? "Detay Belirtilmedi"
            };

            _context.Logs.Add(log);
            _context.SaveChanges();
        }
    }
}
