Solution contains 7 Projects
1. Console.Logger.Test
2. Serilog.Console.Sink.Test
3. Sink.Logger.Db
4. Sink.Logger.Lib
5. Sink.Logger.Models
6. Sink.Logger.Serilog
7. Sink.Logger.Tests
   

Solution is divided into two approaches 
1. Custom Logger
2. Serilog Logger

Console.Logger.Test and Serilog.Console.Sink.Test are the end to end testing applications(for integration tests)
Console.Logger.Test is used to test custom logger approach & Serilog.Console.Sink.Test is used to test Serilog approach.

Both approachs can keep the logs in console,file and database.

In Source code  Sink.Logger.Lib have a folder named as **DBScripts** having forward script to create db objects and make the logger work.
Also the same project holds the **appsettings.json **file in which we can set **connection string** for db and **file path** for the log file.

