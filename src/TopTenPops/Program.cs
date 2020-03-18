using System;

namespace TopTenPops
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] path = new string[]{
                "countries.csv"
            };
            var csvReader = new CsvReader(path);
            var countries = csvReader.ReadFirstNCountries(10);
            foreach (var country in countries)
            {
                System.Console.WriteLine(country.Name);
            }
        }
    }
}
