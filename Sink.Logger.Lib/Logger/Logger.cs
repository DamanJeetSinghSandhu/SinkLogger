using Sink.Logger.Lib.SinkInterface;
using Sink.Logger.Models;

namespace Sink.Logger.Lib
{
    public class Logger
    {
        private readonly List<ILogSink> sinks;
        private LogLevel minLogLevel;

        public Logger()
        {
            sinks = new List<ILogSink>();
            minLogLevel = LogLevel.DEBUG; //Setting default minimum log level
        }

        public void AddSink(ILogSink sink)
        {
            //Keeping this default if null is passed.
            if(sink == null)
            {
                ConsoleSink consoleSink = new ConsoleSink();
                sinks.Add(consoleSink);
            }else
            {
            sinks.Add(sink);
            }
           
        }

        //setting up minimum log level in this method
        public void SetMinLogLevel(LogLevel minLogLevel)
        {
            this.minLogLevel = minLogLevel;
        }

        public void Log(string content, LogLevel level, string namespaceStr)
        {
            if (level < minLogLevel)
            {
                return; // Skip logging if the log level is below the minimum log level
            }

            LogMessage message = new LogMessage
            {
                Content = content,
                Level = level.ToString(),
                Namespace = namespaceStr
            };

            foreach (var sink in sinks)
            {
                // process the type of logger we want to use. by this making it flexible to add more types of logger in future like email, appinsight etc 
                if (IsLogLevelSupported(sink, level))
                {
                    sink.LogMessage(message);
                }
            }
        }

        private bool IsLogLevelSupported(ILogSink sink, LogLevel level)
        {

            //keeping true in case if we want to implement any logic to check which log level is supported we can use this space
            return true;
        }
    }

}
