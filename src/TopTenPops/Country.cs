using System;

namespace TopTenPops
{
    public class Country
    {
        public int Population { get; set; }
        public string Region { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FormattedPopulation
        {
            get
            {
                return String.Format("{0:### ### ### ###}", Population);
            }
        }
        public Country(string name, string code, string region, int population)
        {
            this.Name = name;
            this.Code = code;
            this.Region = region;
            this.Population = population;
        }

    }
}