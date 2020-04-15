using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System;

namespace CountryCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\NGE Impact\Beginning_C#_Collections\src\Country_C#_Collections\InputFile\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);
            List<Country> countries = reader.ReadAllCountries();  
            //var links = countries.Where(x=>!x.Name.Contains(',')).OrderBy(x=>x.Name);//.Take(10)
            var links = from country in countries
                        where !country.Name.Contains(',')
                        orderby country.Name
                        select country;

            foreach ( Country country in links)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");                
            }

             Console.WriteLine($"{countries.Count} Countries");
        }
    }
}
