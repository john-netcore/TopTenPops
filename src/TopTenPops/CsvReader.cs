
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

        private Country ReadCountryFromCsvLine(string line)
        {
            string[] parts;
            parts = Regex.Split(line, ",");
            string name = parts[0];
            string code = parts[1];
            string continent = parts[2];
            int population = int.Parse(parts[3]);

            return new Country(name, code, continent, population);
        }
    }
}