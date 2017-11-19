using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IvoRakar.Business.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityFrameworkDBContext _context;

        public UnitOfWork(EntityFrameworkDBContext context)
        {
            _context = context;

        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}