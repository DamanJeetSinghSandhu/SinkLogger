using Serilog.Configuration;
using Serilog;
using Serilog.Events;
using Sink.Logger.Lib.SinkInterface;
using Sink.Logger.Models;
using Serilog.Core;
using Sink.Logger.Lib;

namespace Sink.Logger.Serilog
{
    public class SeriLogger :  ILogEventSink
    {
        public void LogMessage(LogMessage message)
        {
            throw new NotImplementedException();
        }


        private readonly IFormatProvider _formatProvider;
        private readonly  List<ILogSink> _sinks = new List<ILogSink>();
        private LogLevel minLogLevel;
        public SeriLogger(IFormatProvider formatProvider, List<ILogSink> sinks)
        {
            _formatProvider = formatProvider;
            if (sinks == null)
            {
                _sinks.Add(new ConsoleSink());
            }
            else
            {
                _sinks = sinks;
            }
        }

      

        public void Emit(LogEvent logEvent)
        {
            //capturing log raised by logger 
            var message = logEvent.RenderMessage(_formatProvider);            
            Log(message, MapLogLevel(logEvent.Level), message);
        }

        public void SetMinLogLevel(LogLevel minLogLevel)
        {
           
            this.minLogLevel = minLogLevel;
        }

        public Models.LogLevel MapLogLevel(LogEventLevel level)
        {
            //selecting loglevel through log event
            switch (level)
            {
                case LogEventLevel.Debug:
                    return LogLevel.DEBUG;
                case LogEventLevel.Information:
                    return LogLevel.INFO;
                case LogEventLevel.Warning:
                    return LogLevel.WARN;
                case LogEventLevel.Error:
                    return LogLevel.ERROR;
                case LogEventLevel.Fatal:
                    return LogLevel.FATAL;
                default:
                    return LogLevel.WARN; // Default to WARN if the input level is not recognized
            }
        }


        public void Log(string content, LogLevel level, string namespaceStr)
        {
            if (level < minLogLevel)
            {
                return; // Skip logging if the log level is below the minimum threshold
            }

            LogMessage message = new LogMessage
            {
                Content = content,
                Level = level.ToString(),
                Namespace = namespaceStr
            };

            foreach (var sink in _sinks)
            {
                // Route the message to sinks supporting the specified log level
                if (IsLogLevelSupported(sink, level))
                {
                    sink.LogMessage(message);
                }
            }
        }

        private bool IsLogLevelSupported(ILogSink sink, LogLevel level)
        {

            
            return true;
        }

    }

   
}
