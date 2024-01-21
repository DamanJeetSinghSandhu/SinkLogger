using Microsoft.EntityFrameworkCore;
using Sink.Logger.Models;

namespace Sink.Logger.Db
{
    public class LoggerDbContext:DbContext
    {
        public DbSet<LogMessage> LogMessage { get; set; }

       

        public LoggerDbContext(DbContextOptions<LoggerDbContext> options) : base(options)
        {
        }
    }
}
