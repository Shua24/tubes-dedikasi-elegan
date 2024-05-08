using ConfigurationSettings;
using CSVAnalytics;

namespace UnitTestingStatiks
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ParameterizationGenericsTest()
        {
            CSVTable csvTable = new CSVTable("polakuman3.csv"); 
            List<string> expectedAntibiotics = new List<string> { "Amoxicillin", "Ciprofloxacin", "Doxycycline" };

            // Redirect standard output to capture printed output
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            csvTable.CsvStats();
            string consoleOutput = sw.ToString(); // Get the printed output

            // Assert
            foreach (string antibiotic in expectedAntibiotics)
            {
                Assert.IsTrue(consoleOutput.Contains(antibiotic));
            }
        }

        [TestMethod]
        public void RuntimeConfigurationTest()
        {
            // Arrange
            const string expectedOS = "Windows";
            const string expectedDirectory = @"D:\CSV\";

            // Act
            ConfigurationReader reader = new ConfigurationReader();

            // Assert
            Assert.AreEqual(expectedOS, reader.config.os);
            Assert.AreEqual(expectedDirectory, reader.config.directory);
        }
    }
}