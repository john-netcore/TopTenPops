
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace TopTenPops
{
    public class CsvReader
    {
        public string Path
        {
            get;
            set;
        }

        public CsvReader(string[] path)
        {
            Path = System.IO.Path.Combine(path);
        }

        public CsvReader(string path)
        {
            Path = path;
        }

        public Country[] ReadFirstNCountries(int nCountries)
        {
            Country[] countries = new Country[nCountries];
            using (var reader = System.IO.File.OpenText(Path))
            {
                //Title line
                reader.ReadLine();

                string line;
                for (int i = 0; i < nCountries; i++)
                {
                    line = reader.ReadLine();
                    countries[i] = ReadCountryFromCsvLine(line);
                }
            }

            return countries;
        }

        public List<Country> ReadAllCountries()
        {
            var countries = new List<Country>();

            using (var reader = new StreamReader(Path))
            {
                //Title line
                reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var country = ReadCountryFromCsvLine(line);
                    countries.Add(country);
                }
            }

            return countries;
        }

        private Country ReadCountryFromCsvLine(string line)
        {
            string[] parts;
            // Regex for ignoring comas inside quotes.
            parts = Regex.Split(line, ",(?=([^\"]*\"[^\"]*\")*[^\"]*$)");
            string name = parts[0];
            string code = parts[1];
            string continent = parts[2];
            int.TryParse(parts[3], out int population);

            return new Country(name, code, continent, population);
        }
    }
}