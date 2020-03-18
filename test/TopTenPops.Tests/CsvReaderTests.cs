using Xunit;

namespace TopTenPops.Tests
{
    public class CsvReaderTests
    {
        [Fact]
        public void CreateCsvReaderObject_Test()
        {
            //Arrange
            CsvReader csvReader = null;
            //Act
            csvReader = new CsvReader(new string[] { "whatever" });
            //Assert
            Assert.IsType<CsvReader>(csvReader);
        }
    }
}
