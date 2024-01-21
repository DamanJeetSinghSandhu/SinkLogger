// See https://aka.ms/new-console-template for more information
using Sink.Logger.Lib;
using Sink.Logger.Models;

Console.WriteLine("Console Log App for Customer Logger.");


// Setup sinks during logger configuration; kept all the configurations to show; we can choose logging destination 
//from console, file or database tables.
var consoleSink = new ConsoleSink();
var fileSink = new FileSink();
var databaseSink = new DataBaseSink();

// Create a logger with configured sinks
var logger = new Logger();

// Add configured sinks to the logger
logger.AddSink(consoleSink);
logger.AddSink(fileSink);
logger.AddSink(databaseSink);

// Set the minimum log level for the logger here
logger.SetMinLogLevel(LogLevel.INFO);

// Log messages from the application
logger.Log("This is an informational message", LogLevel.INFO, "ApplicationNamespace");
logger.Log("A warning message", LogLevel.WARN, "ApplicationNamespace");
logger.Log("A debug message", LogLevel.DEBUG, "ApplicationNamespace");
