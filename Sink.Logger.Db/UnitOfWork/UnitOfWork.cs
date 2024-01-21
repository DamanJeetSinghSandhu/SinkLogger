using Microsoft.EntityFrameworkCore;
using Sink.Logger.Db.Interface;
using Sink.Logger.Db.Repository;
using Sink.Logger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sink.Logger.Db.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LoggerDbContext _context;

        public UnitOfWork(LoggerDbContext context)
        {
            _context = context;
            Repository = new LoggerRepository<LogMessage>(_context);
        }

        public IRepository<LogMessage> Repository { get; private set; }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
