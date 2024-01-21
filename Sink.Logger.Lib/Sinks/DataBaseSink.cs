using Sink.Logger.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sink.Logger.Db;
using Sink.Logger.Db.Interface;
using Sink.Logger.Db.UnitOfWork;
using Sink.Logger.Db.Repository;
using Microsoft.Extensions.Configuration;
using Sink.Logger.Lib.SinkInterface;

namespace Sink.Logger.Lib
{
    public class DataBaseSink:ILogSink
    {
       
        private readonly ServiceProvider serviceCollection;
        public DataBaseSink()
        {
            //reading config details from appsetting.json, it can be handle more efficiently but due to short of time using like this 
            IConfiguration configuration = new ConfigurationBuilder()
         .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
         .AddJsonFile("appsettings.json")
         .Build();

            // Read the connection string
            string connectionString = configuration.GetConnectionString("ConnectionString");

            //Dependency injection logic here
            serviceCollection = new ServiceCollection()
           .AddDbContext<LoggerDbContext>(options =>
               options.UseSqlServer(connectionString))
            .AddTransient<IRepository<LogMessage>, LoggerRepository<LogMessage>>()
            .AddTransient<IUnitOfWork, UnitOfWork>()
           .BuildServiceProvider();
        }



        public void LogMessage(LogMessage message)
        {
            using (var scope = serviceCollection.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                unitOfWork.Repository.Add(message);

                unitOfWork.SaveChanges();
            }

          }

    }
}
