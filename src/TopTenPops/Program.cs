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
            var countries = csvReader.ReadFirstNCountries(20);
            foreach (var country in countries)
            {
                System.Console.WriteLine($"{country.FormattedPopulation}   {country.Name}");
            }
        }
    }
}
