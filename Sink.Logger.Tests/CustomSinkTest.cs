using Sink.Logger.Lib.SinkInterface;
using Microsoft.Extensions.Logging;
using Models= Sink.Logger.Models;
using Sink.Logger.Lib;
using Sink.Logger.Models;

namespace Sink.Logger.Tests
{
    public class CustomSinkTest
    {
        [Fact]
        public void Logs_Are_Sent_To_Sinks()
        {
            // Arrange
            var sinkMock1 = new Mock<ILogSink>();
            var sinkMock2 = new Mock<ILogSink>();

            var logger = new Sink.Logger.Lib.Logger();

            logger.AddSink(sinkMock1.Object);
            logger.AddSink(sinkMock2.Object);
            //Act
            logger.Log("Test Content", Models.LogLevel.INFO, "TestNamespace");

            // Assert
            sinkMock1.Verify(s => s.LogMessage(It.IsAny<LogMessage>()), Times.Once);
            sinkMock2.Verify(s => s.LogMessage(It.IsAny<LogMessage>()), Times.Once);


        }

        [Fact]
        public void Logs_Are_Sent_With_Correct_Content()
        {
            // Arrange
            var sinkMock1 = new Mock<ILogSink>();
            
            var logger = new Sink.Logger.Lib.Logger();

            logger.AddSink(sinkMock1.Object);

            // Act
            logger.Log("Test Content", Models.LogLevel.INFO, "TestNamespace");

            // Assert
            sinkMock1.Verify(s => s.LogMessage(It.Is<LogMessage>(m =>
                m.Content == "Test Content" &&
                m.Level == Models.LogLevel.INFO.ToString() &&
                m.Namespace == "TestNamespace")), Times.Once);
        }


        [Fact]
        public void Handles_Null_Sinks_List()
        {
            // Arrange

            var logger = new Sink.Logger.Lib.Logger();

            logger.AddSink(null);

            // Act & Assert 
            logger.Log("Test Content", Models.LogLevel.INFO, "TestNamespace");
        }

        [Fact]
        public void Does_Not_Send_Logs_Below_Min_Level()
        {
            // Arrange
            var sinkMock = new Mock<ILogSink>();
            var logger = new Sink.Logger.Lib.Logger();
            logger.AddSink(sinkMock.Object);
            logger.SetMinLogLevel(Models.LogLevel.WARN); // Set minimum log level to WARN

            // Act
            logger.Log("Test Content", Models.LogLevel.INFO, "TestNamespace");

            // Assert
            sinkMock.Verify(s => s.LogMessage(It.IsAny<LogMessage>()), Times.Never);
        }

       
    }
}