using Sink.Logger.Models;

namespace Sink.Logger.Db.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<LogMessage> Repository { get; }
        void SaveChanges();
    }
}
