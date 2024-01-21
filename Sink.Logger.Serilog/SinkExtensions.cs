using Serilog.Configuration;
using Serilog;
using Sink.Logger.Lib.SinkInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sink.Logger.Serilog
{
    public static class SinkExtensions
    {
        public static LoggerConfiguration SeriLogger(
                  this LoggerSinkConfiguration loggerConfiguration,
                  IFormatProvider formatProvider = null, List<ILogSink> sinks = null)
        {
            return loggerConfiguration.Sink(new SeriLogger(formatProvider, sinks));
        }
    }
}
