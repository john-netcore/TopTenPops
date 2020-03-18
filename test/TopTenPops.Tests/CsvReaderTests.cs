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
        public void ReadZeroCountries_Test()
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

        [Fact]
        public void ReadFirstCountry_Test()
        {
            //Arrange
            var csvReader = GetCsvReader();
            int expectedLength = 1;
            //Act
            var countries = csvReader.ReadFirstNCountries(1);
            //Assert
            Assert.IsType<Country>(countries[0]);
            Assert.Equal(expectedLength, countries.Length);
        }

        [Fact]
        public void ReadAllCountries_Test()
        {
            //Arrange
            var csvReader = GetCsvReader();
            int expectedLength = 217;
            //Act
            var countries = csvReader.ReadAllCountries();
            //Assert
            Assert.Equal(expectedLength, countries.Count);
        }
    }
}
