namespace Sink.Logger.Db.Repository
{
    public class LoggerRepository<LoggerMessage> : IRepository<LoggerMessage> where LoggerMessage : class
    {
        private readonly LoggerDbContext _context;

        public LoggerRepository(LoggerDbContext context)
        {
            _context = context;
        }

        public void Add(LoggerMessage entity)
        {
            _context.Set<LoggerMessage>().Add(entity);
        }

    }
}
