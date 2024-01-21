using Microsoft.Extensions.Configuration;
using Sink.Logger.Lib.SinkInterface;
using Sink.Logger.Models;

namespace Sink.Logger.Lib
{
    public class FileSink : ILogSink
    {
        private readonly string filePath;

        public FileSink()
        {
            //reading config details from appsetting.json, it can be handle more efficiently but due to short of time using like this 

            IConfiguration configuration = new ConfigurationBuilder()
         .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
         .AddJsonFile("appsettings.json")
         .Build();

            // Read the connection string
            string filePath = configuration["FilePath"];
            this.filePath = filePath;
        }

        public void LogMessage(LogMessage message)
        {
            //Appending logs here in the file
           System.IO.File.AppendAllText(this.filePath, $"{message.Level}: [{message.Namespace}] - {message.Content}\n");
        }
    }
}
