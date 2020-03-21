using System.Collections.Generic;
using Xunit;

namespace TopTenPops.Tests
{
    public class CsvReaderTests
    {
        private string path = "/Users/johnlundgren/Development/netProjects/TopTenPops/src/TopTenPops/data/countries.csv";
        private CsvReader GetCsvReader()
        {
            return new CsvReader(path);
        }

        [Fact]
        public void CreateCsvReaderObject_Test()
        {
            //Arrange
            CsvReader csvReader = null;
            //Act
            csvReader = new CsvReader(path);
            //Assert
            Assert.IsType<CsvReader>(csvReader);
            Assert.IsType<Dictionary<string, List<Country>>>(csvReader.dict);
            Assert.True(csvReader.dict.Count > 0);
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
