using Xunit;

namespace TopTenPops.Tests
{
    public class CsvReaderTests
    {
        private CsvReader GetCsvReader()
        {
            string path = "/Users/johnlundgren/Development/netProjects/TopTenPops/src/TopTenPops/countries.csv";
            return new CsvReader(path);
        }

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

        [Fact]
        public void ReadFirstZeroCountries_Test()
        {
            //Arrange
            var csvReader = GetCsvReader();
            int expectedLength = 0;
            //Act
            var countries = csvReader.ReadFirstNCountries(0);
            //Assert
            Assert.NotNull(countries);
            Assert.Equal(expectedLength, countries.Length);
        }
    }
}
