using System;

namespace TopTenPops
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Enter number of countries to display: ");
            int.TryParse(Console.ReadLine(), out int displayNumber);
            if (displayNumber < 1)
            {
                System.Console.WriteLine("You must type a positive int value.");
                return;
            }
            string[] path = new string[]{
                "src",
                "TopTenPops",
                "data",
                "countries.csv"
            };
            var csvReader = new CsvReader(path);
            var countries = csvReader.ReadAllCountries();

            for (var i = 0; i < countries.Count; i++)
            {
                if (i > 0 && (i % displayNumber == 0))
                {
                    System.Console.WriteLine("Press enter to continue, any other key to quit");
                    if (Console.ReadLine() != "")
                    {
                        return;
                    }
                }
                System.Console.WriteLine($"{i + 1} {countries[i].Name}: {countries[i].FormattedPopulation}");
            }
        }
    }
}
