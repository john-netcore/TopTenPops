using System;
using System.Collections.Generic;
using System.Globalization;

namespace TopTenPops
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] path = new string[]{
                "src",
                "TopTenPops",
                "data",
                "countries.csv"
                };

            var csvReader = new CsvReader(path);

            foreach (var region in csvReader.Regions)
            {
                System.Console.WriteLine(region);
            }

            System.Console.Write("Enter a region from above for countries to display: ");
            string chosenRegion = System.Console.ReadLine();
            chosenRegion = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(chosenRegion);

            try
            {
                var countries = csvReader.GetCountries(chosenRegion);

                foreach (var country in countries)
                {
                    System.Console.WriteLine($"{country.Name}: {country.FormattedPopulation}");
                }
            }
            catch (KeyNotFoundException)
            {
                System.Console.WriteLine("Chosen region does not exist");
            }
            // System.Console.Write("Enter number of countries to display: ");
            // int.TryParse(Console.ReadLine(), out int displayNumber);
            // if (displayNumber < 1)
            // {
            //     System.Console.WriteLine("You must type a positive int value.");
            //     return;
            // }
            // string[] path = new string[]{
            //     "src",
            //     "TopTenPops",
            //     "data",
            //     "countries.csv"
            // };
            // var csvReader = new CsvReader(path);
            // var countries = csvReader.ReadAllCountries();

            // for (var i = 0; i < countries.Count; i++)
            // {
            //     if (i > 0 && (i % displayNumber == 0))
            //     {
            //         System.Console.WriteLine("Press enter to continue, any other key to quit");
            //         if (Console.ReadLine() != "")
            //         {
            //             return;
            //         }
            //     }
            //     System.Console.WriteLine($"{i + 1} {countries[i].Name}: {countries[i].FormattedPopulation}");
            // }
        }
    }
}
