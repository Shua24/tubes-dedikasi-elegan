using ConfigurationSettings;
using CSVAnalytics;
using Microsoft.Data.Analysis;

namespace UnitTestingStatiks
{
    [TestClass]
    public class StatsTest
    {
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

        [TestMethod]
        public void DataFrameTest()
        {
            // Arrange
            string csv = "polakuman3.csv";
            CSVTable _table = new CSVTable(csv);
            string expected = @"D:\CSV\" + csv;

            // Act
            string csvTest = _table.GetFilePath();

            // Assert
            Assert.AreEqual(expected, csvTest);
        }

        [TestMethod]
        public void TableTest()
        {
            // Arrange
            string csv = "polakuman3.csv";
            string colTest = "Acinetobacter baumannii";
            CSVTable table = new CSVTable(csv);
            DataFrame df = DataFrame.LoadCsv(table.GetFilePath());

            DataFrameColumn[] expected =
            {
                df["Organism"],
                df[colTest]
            };
        }
    }
}