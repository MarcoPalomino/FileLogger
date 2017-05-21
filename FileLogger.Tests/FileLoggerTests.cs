using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileLogger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void VerifyPahtNameIsObtainedSuccessfully()
        {
            //Arrange
            var logger = new Logger();

            //Act
            var path = logger.GetPath();

            //Assert
            Assert.IsTrue(!string.IsNullOrEmpty(path));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void VerifyFileLogWasSuccessfullySaved()
        {
            //Arrange
            var logger = new Logger();
            var logType = "LogTypeTest";
            var logMessage = "LogMessageTest";

            //Act
            var wasSuccessfullyLogged = logger.DoLog(logType, logMessage);

            //Assert
            Assert.IsTrue(wasSuccessfullyLogged);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void VerifyLogMessageIsSuccessfullyBuilt()
        {
            var logger = new Logger();
            var logType = "LogType";
            var logMessage = "LogMessage";

            //Act
            var logMessageToSave = logger.PrepareLogMessage(logType, logMessage);

            //Assert
            Assert.IsTrue(!string.IsNullOrEmpty(logMessageToSave));
        }
    }
}
