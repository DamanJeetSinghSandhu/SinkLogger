// See https://aka.ms/new-console-template for more information
using Serilog;
using Sink.Logger.Lib;
using Sink.Logger.Lib.SinkInterface;
using Sink.Logger.Serilog;

Console.WriteLine("Console Log App for Serilog Logger");

// Setup sinks with serilog during logger configuration; kept all the configurations to show; we can choose logging destination 
//from console, file or database tables.
var lSinks = new List<ILogSink>() { new ConsoleSink(), new FileSink(), new DataBaseSink() };

//setting up serilog logger
var log = new LoggerConfiguration()
               .MinimumLevel.Information()
               .WriteTo.SeriLogger(null,lSinks)
               .CreateLogger();

var nameSpace = "NameSpace1";
//sending messages to log
log.Information("InfoMessage",nameSpace);

log.Error("ErrorMessage", "NameSpace2");

log.Fatal("FatalMessage", "NameSpace3");

