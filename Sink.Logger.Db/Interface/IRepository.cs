public interface IRepository<LoggerMessage> where LoggerMessage : class
{
  
    void Add(LoggerMessage entity);
   
}